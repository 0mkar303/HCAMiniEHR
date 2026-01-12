using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCAMiniEHR.Migrations
{
    /// <inheritdoc />
    public partial class AddRealWorldPatientFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                schema: "Healthcare",
                table: "Patients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "BloodGroup",
                schema: "Healthcare",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "Healthcare",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContact",
                schema: "Healthcare",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                schema: "Healthcare",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisteredOn",
                schema: "Healthcare",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                schema: "Healthcare",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodGroup",
                schema: "Healthcare",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "Healthcare",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "EmergencyContact",
                schema: "Healthcare",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                schema: "Healthcare",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "RegisteredOn",
                schema: "Healthcare",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Healthcare",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                schema: "Healthcare",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
