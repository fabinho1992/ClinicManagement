using Academia.WebApi.ErrosMiddleware;
using ClinicManagement.Domain.Models;
using ClinicManagement.Extensions;
using Microsoft.OpenApi.Models;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Add Extensions
builder.Services.AddDbContextFinancialGoals(builder.Configuration);
builder.Services.AddInjectionDepedencys();
builder.Services.AddExtensionsMediatR();
builder.Services.AddSettingsController();
builder.Services.AddJwtAuthetication(builder.Configuration);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddConfigurationSwagger();

builder.Services.AddSwaggerGen(c =>
{

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "V1",
        Title = "Sistema de garenciamento de Clinica médica",
        Description = "Api que gerencia a criação de cadastro de pacientes e consultas",
        Contact = new OpenApiContact
        {
            Name = "Fabio dos Santos",
            Email = "f.santosdev1992@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/f%C3%A1bio-dos-santos-518612275/")
        }

    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                   {
                      new OpenApiSecurityScheme
                      {
                          Reference = new OpenApiReference
                           {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                           }
                       },
                           new string[] {}
                   }
                });

});
var app = builder.Build();

app.UseCors("AllowNextJS");

QuestPDF.Settings.License = LicenseType.Community;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Habilita o middleware do Swagger
    app.UseSwagger();

    // Habilita o middleware do Swagger UI
    app.UseSwaggerUI();
}

app.UseMiddleware(typeof(ErroMiddleware));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
