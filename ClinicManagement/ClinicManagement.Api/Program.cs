using Academia.WebApi.ErrosMiddleware;
using ClinicManagement.Exxtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Add Extensions
builder.Services.AddDbContextFinancialGoals(builder.Configuration);
builder.Services.AddInjectionDepedencys();
builder.Services.AddExtensionsMediatR();
builder.Services.AddSettingsController();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware(typeof(ErroMiddleware));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
