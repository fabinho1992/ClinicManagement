using ClinicManagement.Domain.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Infrastructure.Reports
{
    public class TesteReport : IDocument
    {
        public Patient Patient { get; set; }

        public TesteReport(Patient patient)
        {
            Patient = patient;
        }

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(30);

                page.Header()
                    .AlignCenter()
                    .Text("Teste")
                    .FontSize(24)
                    .SemiBold();

                page.Content().Column(col =>
                {
                    col.Item().Text("Nome").FontSize(14).Bold();
                    col.Item().PaddingBottom(10).Text(Patient.Name);
                });
            });
        }
    }
}
