using ClinicManagement.Application.Services.EmailServices;
using ClinicManagement.Domain.IRepository;
using ClinicManagement.Domain.Models;
using ClinicManagement.Domain.Services.EmailServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Services.WorkServices
{
    public class Worker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public Worker(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            TimeSpan intervalDay = TimeSpan.FromDays(1);
            using PeriodicTimer timer = new PeriodicTimer(intervalDay);

            while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var emailService = scope.ServiceProvider.GetRequiredService<ISendEmail>();

                    var context = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                    var consults = await context.ConsultRepository.GetEmailWarning();

                    foreach (var item in consults)
                    {
                        await emailService.SendEmailWarning(item.Patient.Email, item.Patient.Name, item.Start.ToString("d"));

                    }
                }

            }
        }
    }
}
