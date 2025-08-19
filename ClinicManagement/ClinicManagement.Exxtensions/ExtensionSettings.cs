using BloodDonationDataBase.Domain.IServices;
using BloodDonationDataBase.Infrastructure.Services;
using BookReviewManager.Domain.IServices.Autentication;
using BookReviewManager.Infrastructure.Service.Identity;
using ClinicManagement.Application.FluentValidation.PatientsValidation;
using ClinicManagement.Application.Services.EmailServices;
using ClinicManagement.Application.Services.WorkServices;
using ClinicManagement.Domain.IRepository;
using ClinicManagement.Domain.Services.EmailServices;
using ClinicManagement.Domain.Services.IAuthService;
using ClinicManagement.Infrastructure.Context;
using ClinicManagement.Infrastructure.Context.User;
using ClinicManagement.Infrastructure.Reports;
using ClinicManagement.Infrastructure.Repository;
using ClinicManagement.Infrastructure.Services.AuthService;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Converters;
using System.Text;
using System.Text.Json.Serialization;

namespace ClinicManagement.Extensions
{
    public static class ExtensionSettings
    {

        public static IServiceCollection AddDbContextFinancialGoals(this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ClinicDbContext>(options =>
             options.UseNpgsql(connectionString));

            services.AddDbContext<DbContextIdentity>(options =>
             options.UseNpgsql(connectionString));

            //Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DbContextIdentity>()
                .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddInjectionDepedencys(this IServiceCollection services)
        {
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IConsulRepository, ConsultRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepositoryUser, RepositoryUser>();
            services.AddScoped<IAddressZipCode, AddressZipCode>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ISendEmail, SendEmail>();
            services.AddScoped<ICreateUser, CreateUser>();
            services.AddScoped<ICreateRole, CreateRole>();
            services.AddScoped<ILoginUser, LoginUser>();
            services.AddScoped<IAddRole, AddRole>();
            services.AddScoped<ITokenService, TokenService>();
            //services.AddTransient<MedicalCertificate>();

            //Worker
            services.AddHostedService<Worker>();

            //Memory Cache
            services.AddMemoryCache();

            //Cors
            services.AddCors(options =>
            {
                options.AddPolicy("AllowNextJS",
                    policy => policy
                        .WithOrigins("http://localhost:3000") // URL do seu Next.js
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()); // Se usar cookies/auth
            });

            return services;
        }

        public static IServiceCollection AddSettingsController(this IServiceCollection services)
        {
            services.AddControllers()
               .AddJsonOptions(op =>
               {
                   op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());// mostra no Schemas do swagger os valores do enum
                   op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
               })
               .AddNewtonsoftJson(op => op.SerializerSettings.Converters.Add(new StringEnumConverter()));


            return services;
        }

        public static IServiceCollection AddExtensionsMediatR(this IServiceCollection services)
        {
            var myHandlers = AppDomain.CurrentDomain.Load("ClinicManagement.Application");
            services.AddMediatR(config =>
                config.RegisterServicesFromAssembly(myHandlers));

            return services;
        }

        public static IServiceCollection AddJwtAuthetication(this IServiceCollection services, IConfiguration configuration)
        {
            //Jwt Token
            var secretKey = configuration["Jwt:SecretKey"] ?? throw new ArgumentException("Invalid secret Key ..");

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // desafio de solicitar o token
            }).AddJwtBearer(opt =>
            {
                opt.SaveToken = true; // salvar o token
                opt.RequireHttpsMetadata = true; // se é preciso https para transmitir o token , em produçao é true
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidAudience = configuration["Jwt:ValidAudience"],
                    ValidIssuer = configuration["Jwt:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))

                };
            });

            //Politicas que serão usadas para acessar os endpoints
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("Medico", policy => policy.RequireRole("Medico"));

                opt.AddPolicy("Admin", policy => policy.RequireRole("Admin"));

                opt.AddPolicy("Recepcionista", policy => policy.RequireRole("Recepcionista"));
            }
            );

            return services;
        }

        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<CreatePatientValidation>();

            return services;
        }
    }
}
