using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TSHis2.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDiagnosisTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_diagnosis_employees",
                table: "diagnosis");

            migrationBuilder.DropColumn(
                name: "diagnosis_hour",
                table: "diagnosis");

            migrationBuilder.RenameColumn(
                name: "emp_id",
                table: "diagnosis",
                newName: "EmployeeEmpId");

            migrationBuilder.RenameIndex(
                name: "IX_diagnosis_emp_id",
                table: "diagnosis",
                newName: "IX_diagnosis_EmployeeEmpId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "diagnosis_date",
                table: "diagnosis",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "drugs",
                table: "diagnosis",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tests",
                table: "diagnosis",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_diagnosis_employees_EmployeeEmpId",
                table: "diagnosis",
                column: "EmployeeEmpId",
                principalTable: "employees",
                principalColumn: "emp_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_diagnosis_employees_EmployeeEmpId",
                table: "diagnosis");

            migrationBuilder.DropColumn(
                name: "drugs",
                table: "diagnosis");

            migrationBuilder.DropColumn(
                name: "tests",
                table: "diagnosis");

            migrationBuilder.RenameColumn(
                name: "EmployeeEmpId",
                table: "diagnosis",
                newName: "emp_id");

            migrationBuilder.RenameIndex(
                name: "IX_diagnosis_EmployeeEmpId",
                table: "diagnosis",
                newName: "IX_diagnosis_emp_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "diagnosis_date",
                table: "diagnosis",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "diagnosis_hour",
                table: "diagnosis",
                type: "time",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_diagnosis_employees",
                table: "diagnosis",
                column: "emp_id",
                principalTable: "employees",
                principalColumn: "emp_id");
        }
    }
}
