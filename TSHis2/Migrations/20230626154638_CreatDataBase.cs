using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TSHis2.Migrations
{
    /// <inheritdoc />
    public partial class CreatDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "drugs",
                columns: table => new
                {
                    drug_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    treatment_id = table.Column<int>(type: "int", nullable: false),
                    generic_name = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    concentration = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    type = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drugs", x => x.drug_id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    emp_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_ssn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    emp_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    gender = table.Column<int>(type: "int", nullable: true),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    phone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    job_title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.emp_id);
                });

            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    patient_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    national_id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    umn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    patient_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    patient_age = table.Column<int>(type: "int", nullable: false),
                    patient_address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phone_number = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_1", x => x.patient_id);
                });

            migrationBuilder.CreateTable(
                name: "tests_x-rays",
                columns: table => new
                {
                    test_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    test_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    category = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tests_x-rays", x => x.test_id);
                });

            migrationBuilder.CreateTable(
                name: "visits",
                columns: table => new
                {
                    visit_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patient_id = table.Column<int>(type: "int", nullable: false),
                    umn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ticket_number = table.Column<int>(type: "int", nullable: true),
                    entry_place = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    payment_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    entry_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    current_location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visits", x => x.visit_id);
                    table.ForeignKey(
                        name: "FK_visits_patient",
                        column: x => x.patient_id,
                        principalTable: "patient",
                        principalColumn: "patient_id");
                });

            migrationBuilder.CreateTable(
                name: "diagnosis",
                columns: table => new
                {
                    diagnosis_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    visit_id = table.Column<int>(type: "int", nullable: true),
                    emp_id = table.Column<int>(type: "int", nullable: true),
                    examiation = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    diagnosis = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    doctor_decision = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    diagnosis_date = table.Column<DateTime>(type: "date", nullable: true),
                    diagnosis_hour = table.Column<TimeSpan>(type: "time", nullable: true),
                    diagnosis_location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diagnosis", x => x.diagnosis_id);
                    table.ForeignKey(
                        name: "FK_diagnosis_employees",
                        column: x => x.emp_id,
                        principalTable: "employees",
                        principalColumn: "emp_id");
                    table.ForeignKey(
                        name: "FK_diagnosis_visits",
                        column: x => x.visit_id,
                        principalTable: "visits",
                        principalColumn: "visit_id");
                });

            migrationBuilder.CreateTable(
                name: "diagnosis_drugs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diagnosis_id = table.Column<int>(type: "int", nullable: true),
                    drug_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diagnosis_drugs", x => x.id);
                    table.ForeignKey(
                        name: "FK_diagnosisDrugs_diagnosis",
                        column: x => x.diagnosis_id,
                        principalTable: "diagnosis",
                        principalColumn: "diagnosis_id");
                    table.ForeignKey(
                        name: "FK_diagnosisDrugs_drugs",
                        column: x => x.diagnosis_id,
                        principalTable: "drugs",
                        principalColumn: "drug_id");
                });

            migrationBuilder.CreateTable(
                name: "diagnosis_tests",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    diagnosis_id = table.Column<int>(type: "int", nullable: true),
                    test_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diagnosis_tests", x => x.id);
                    table.ForeignKey(
                        name: "FK_diagnosisTests_diagnosis",
                        column: x => x.diagnosis_id,
                        principalTable: "diagnosis",
                        principalColumn: "diagnosis_id");
                    table.ForeignKey(
                        name: "FK_diagnosisTests_tests_x-rays",
                        column: x => x.test_id,
                        principalTable: "tests_x-rays",
                        principalColumn: "test_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_diagnosis_emp_id",
                table: "diagnosis",
                column: "emp_id");

            migrationBuilder.CreateIndex(
                name: "IX_diagnosis_visit_id",
                table: "diagnosis",
                column: "visit_id");

            migrationBuilder.CreateIndex(
                name: "IX_diagnosis_drugs_diagnosis_id",
                table: "diagnosis_drugs",
                column: "diagnosis_id");

            migrationBuilder.CreateIndex(
                name: "IX_diagnosis_tests_diagnosis_id",
                table: "diagnosis_tests",
                column: "diagnosis_id");

            migrationBuilder.CreateIndex(
                name: "IX_diagnosis_tests_test_id",
                table: "diagnosis_tests",
                column: "test_id");

            migrationBuilder.CreateIndex(
                name: "UNQ_National_id",
                table: "patient",
                column: "patient_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UNQ_Patient_UMN",
                table: "patient",
                column: "umn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_visits_patient_id",
                table: "visits",
                column: "patient_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "diagnosis_drugs");

            migrationBuilder.DropTable(
                name: "diagnosis_tests");

            migrationBuilder.DropTable(
                name: "drugs");

            migrationBuilder.DropTable(
                name: "diagnosis");

            migrationBuilder.DropTable(
                name: "tests_x-rays");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "visits");

            migrationBuilder.DropTable(
                name: "patient");
        }
    }
}
