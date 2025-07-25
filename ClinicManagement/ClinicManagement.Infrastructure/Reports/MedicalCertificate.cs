using ClinicManagement.Domain.IRepository;
using ClinicManagement.Domain.Models;
using ClinicManagement.Domain.ModelsReport;
using Microsoft.Extensions.DependencyInjection;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Infrastructure.Reports
{
    public class MedicalCertificate : IDocument
    {
        public int Days { get; set; }
        public Consult Consult { get; set; }
        private readonly IServiceProvider _serviceScopeFactory;

        public MedicalCertificate(Consult consult, IServiceProvider serviceScopeFactory, int days)
        {
            Consult = consult;
            _serviceScopeFactory = serviceScopeFactory;
            Days = days;
        }

        public void Compose(IDocumentContainer container)
        {
                container.Page(page =>
                {
                    page.Margin(50);

                    page.Header()
                    .AlignCenter()
                    .Text("Clinica Médica")
                    .FontSize(24)
                    .SemiBold();

                    page.Content().Element(e => ComposeContent(e, Consult));
                    page.Footer().Element(e => ComposeFooter(e, Consult));
                });
            
        }

        //void ComposeHeader(IContainer container)
        //{
        //    container.Row(row =>
        //    {
        //        row.RelativeItem().Column(column =>
        //        {
        //            column.Text("Clínica Médica Exemplo").SemiBold().FontSize(16);
        //            column.Text("Rua das Flores, 123").FontSize(12);
        //            column.Text("São Paulo, SP").FontSize(12);
        //        });

        //        // Adicione um logo se tiver
        //        // row.ConstantItem(100).Image("./logo.png");
        //    });
        //}

         void ComposeContent(IContainer container, Consult consult)
        {

            container.PaddingVertical(40).Column(column =>
            {
                // Título
                column.Item().Text("Atestado Médico").FontSize(10).Bold().AlignCenter();

                // Informações do Paciente
                column.Item().PaddingTop(20).Text(text =>
                {
                    text.Span("Paciente: ").Bold();
                    text.Span($"{consult.Patient.Name}");
                });
                column.Item().Text(text =>
                {
                    text.Span("Data de Nascimento: ").Bold();
                    text.Span($"{consult.Patient.DateOfBirth:dd/MM/yyyy}");
                });
                column.Item().Text(text =>
                {
                    text.Span("CPF: ").Bold();
                    text.Span($"{consult.Patient.Cpf}");
                });

                // Declaração do Atestado
                column.Item().PaddingTop(20).Text(text =>
                {
                    text.Span("Atesto, para os devidos fins, que o paciente ");
                    text.Span($"{consult.Patient.Name}").Bold();
                    text.Span(", esteve sob meus cuidados médicos no dia de hoje.");
                });

                // Informações Adicionais (exemplo)
                column.Item().PaddingTop(20).Text(text =>
                {
                    text.Span("Necessita de ");
                    text.Span($"{Days} dias").Bold();
                    text.Span(" de repouso a partir de hoje.");
                });

                // CID (opcional)
                // column.Item().PaddingTop(20).Text("CID: Z00.0 - Exame médico geral");
            });
        }

         void ComposeFooter(IContainer container, Consult consult)
        {

            container.Column(column =>
            {
                column.Item().Text(text =>
                {
                    text.Span("Atenciosamente,");
                });
                column.Item().PaddingTop(5).Text($"Dr.{consult.Doctor.Name}").Bold();
                column.Item().Text($"CRM:{consult.Doctor.CRM}").FontSize(10);
                column.Item().AlignRight().Text(DateTime.Now.ToString("dd/MM/yyyy")).FontSize(10);
            });
        }
    }
}
