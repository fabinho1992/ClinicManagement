using ClinicManagement.Domain.IRepository;
using ClinicManagement.Domain.Models;
using ClinicManagement.Domain.ModelsReport;
using ClinicManagement.Infrastructure.Reports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using QuestPDF.Fluent;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClinicManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CertificatesController : ControllerBase
{
    private readonly IServiceProvider _serviceProvider;

    public CertificatesController(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [HttpGet("Certificates")]
    public async Task<IActionResult> CertificatesMedical([FromQuery] PatientCertificate patient)
    {
        
        var utcDate = DateTime.SpecifyKind(patient.Date, DateTimeKind.Utc);
        using (var scope = _serviceProvider.CreateScope())
        {
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            var consult = await unitOfWork.ConsultRepository.GetByCertificate(utcDate, patient.Cpf);

            if (consult == null)
            {
                return NotFound("Consulta não encontrada.");
            }

            var report = new MedicalCertificate(consult, _serviceProvider, patient.Days);

            var pdf = report.GeneratePdf();

            return File(pdf, "application/pdf", "CertificateMedical.pdf");
        }
    }
       
} 
