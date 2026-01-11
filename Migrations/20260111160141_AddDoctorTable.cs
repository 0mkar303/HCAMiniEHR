using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCAMiniEHR.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                schema: "Healthcare",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Doctors",
                schema: "Healthcare",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                schema: "Healthcare",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                schema: "Healthcare",
                table: "Appointments",
                column: "DoctorId",
                principalSchema: "Healthcare",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                schema: "Healthcare",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "Doctors",
                schema: "Healthcare");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_DoctorId",
                schema: "Healthcare",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                schema: "Healthcare",
                table: "Appointments");
        }
    }
}
