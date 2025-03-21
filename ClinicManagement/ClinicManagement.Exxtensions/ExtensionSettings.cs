﻿using BloodDonationDataBase.Domain.IServices;
using BloodDonationDataBase.Infrastructure.Services;
using ClinicManagement.Domain.IRepository;
using ClinicManagement.Infrastructure.Context;
using ClinicManagement.Infrastructure.Repository;
using FinancialGoalsManager.Application.ServicesEmail;
using FinancialGoalsManager.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace ClinicManagement.Exxtensions
{
    public static class ExtensionSettings
    {
        public static IServiceCollection AddDbContextFinancialGoals(this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ClinicDbContext>(options =>
             options.UseNpgsql(connectionString));

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
            services.AddScoped<IAddressZipCode, AddressZipCode>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ISendEmail, SendEmail>();

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
    }
}
