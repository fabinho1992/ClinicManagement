using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consults_Services_ServiceId",
                table: "Consults");

            migrationBuilder.DropIndex(
                name: "IX_Consults_ServiceId",
                table: "Consults");

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceId",
                table: "Consults",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_Consults_ServiceId",
                table: "Consults",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consults_Services_ServiceId",
                table: "Consults",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consults_Services_ServiceId",
                table: "Consults");

            migrationBuilder.DropIndex(
                name: "IX_Consults_ServiceId",
                table: "Consults");

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceId",
                table: "Consults",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consults_ServiceId",
                table: "Consults",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consults_Services_ServiceId",
                table: "Consults",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
