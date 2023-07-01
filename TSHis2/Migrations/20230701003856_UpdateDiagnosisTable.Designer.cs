﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TSHis2.Models;

#nullable disable

namespace TSHis2.Migrations
{
    [DbContext(typeof(HisContext))]
    [Migration("20230701003856_UpdateDiagnosisTable")]
    partial class UpdateDiagnosisTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TSHis2.Models.Diagnosis", b =>
                {
                    b.Property<int>("DiagnosisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("diagnosis_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiagnosisId"));

                    b.Property<string>("Diagnosis1")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnName("diagnosis");

                    b.Property<DateTime>("DiagnosisDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("diagnosis_date");

                    b.Property<string>("DiagnosisLocation")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("diagnosis_location");

                    b.Property<string>("DoctorDecision")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("doctor_decision");

                    b.Property<string>("Drugs")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("drugs");

                    b.Property<int?>("EmployeeEmpId")
                        .HasColumnType("int");

                    b.Property<string>("Examiation")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnName("examiation");

                    b.Property<string>("Tests")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("tests");

                    b.Property<int?>("VisitId")
                        .HasColumnType("int")
                        .HasColumnName("visit_id");

                    b.HasKey("DiagnosisId");

                    b.HasIndex("EmployeeEmpId");

                    b.HasIndex("VisitId");

                    b.ToTable("diagnosis", (string)null);
                });

            modelBuilder.Entity("TSHis2.Models.DiagnosisDrug", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DiagnosisId")
                        .HasColumnType("int")
                        .HasColumnName("diagnosis_id");

                    b.Property<int?>("DrugId")
                        .HasColumnType("int")
                        .HasColumnName("drug_id");

                    b.HasKey("Id");

                    b.HasIndex("DiagnosisId");

                    b.ToTable("diagnosis_drugs", (string)null);
                });

            modelBuilder.Entity("TSHis2.Models.DiagnosisTest", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("DiagnosisId")
                        .HasColumnType("int")
                        .HasColumnName("diagnosis_id");

                    b.Property<int?>("TestId")
                        .HasColumnType("int")
                        .HasColumnName("test_id");

                    b.HasKey("Id");

                    b.HasIndex("DiagnosisId");

                    b.HasIndex("TestId");

                    b.ToTable("diagnosis_tests", (string)null);
                });

            modelBuilder.Entity("TSHis2.Models.Drug", b =>
                {
                    b.Property<int>("DrugId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("drug_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DrugId"));

                    b.Property<string>("Concentration")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("concentration");

                    b.Property<string>("GenericName")
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("generic_name");

                    b.Property<int>("TreatmentId")
                        .HasColumnType("int")
                        .HasColumnName("treatment_id");

                    b.Property<string>("Type")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("type");

                    b.HasKey("DrugId");

                    b.ToTable("drugs", (string)null);
                });

            modelBuilder.Entity("TSHis2.Models.Employee", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("emp_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpId"));

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("address");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("EmpName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("emp_name");

                    b.Property<string>("EmpSsn")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("emp_ssn");

                    b.Property<int?>("Gender")
                        .HasColumnType("int")
                        .HasColumnName("gender");

                    b.Property<string>("JobTitle")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("job_title");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("phone");

                    b.HasKey("EmpId");

                    b.ToTable("employees", (string)null);
                });

            modelBuilder.Entity("TSHis2.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("patient_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientId"));

                    b.Property<string>("NationalId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("national_id");

                    b.Property<string>("PatientAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("patient_address");

                    b.Property<int>("PatientAge")
                        .HasColumnType("int")
                        .HasColumnName("patient_age");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("patient_name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("phone_number");

                    b.Property<string>("Umn")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("umn");

                    b.HasKey("PatientId")
                        .HasName("PK_patient_1");

                    b.HasIndex(new[] { "PatientId" }, "UNQ_National_id")
                        .IsUnique();

                    b.HasIndex(new[] { "Umn" }, "UNQ_Patient_UMN")
                        .IsUnique();

                    b.ToTable("patient", (string)null);
                });

            modelBuilder.Entity("TSHis2.Models.TestsXRay", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("test_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestId"));

                    b.Property<string>("Category")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("category");

                    b.Property<string>("TestName")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("test_name");

                    b.HasKey("TestId");

                    b.ToTable("tests_x-rays", (string)null);
                });

            modelBuilder.Entity("TSHis2.Models.Visit", b =>
                {
                    b.Property<int>("VisitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("visit_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VisitId"));

                    b.Property<string>("CurrentLocation")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("current_location");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("entry_date");

                    b.Property<string>("EntryPlace")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("entry_place");

                    b.Property<int>("PatientId")
                        .HasColumnType("int")
                        .HasColumnName("patient_id");

                    b.Property<string>("PaymentType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("payment_type");

                    b.Property<int?>("TicketNumber")
                        .HasColumnType("int")
                        .HasColumnName("ticket_number");

                    b.Property<string>("Umn")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("umn");

                    b.HasKey("VisitId");

                    b.HasIndex("PatientId");

                    b.ToTable("visits", (string)null);
                });

            modelBuilder.Entity("TSHis2.Models.Diagnosis", b =>
                {
                    b.HasOne("TSHis2.Models.Employee", null)
                        .WithMany("Diagnoses")
                        .HasForeignKey("EmployeeEmpId");

                    b.HasOne("TSHis2.Models.Visit", "Visit")
                        .WithMany("Diagnoses")
                        .HasForeignKey("VisitId")
                        .HasConstraintName("FK_diagnosis_visits");

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("TSHis2.Models.DiagnosisDrug", b =>
                {
                    b.HasOne("TSHis2.Models.Diagnosis", "Diagnosis")
                        .WithMany("DiagnosisDrugs")
                        .HasForeignKey("DiagnosisId")
                        .HasConstraintName("FK_diagnosisDrugs_diagnosis");

                    b.HasOne("TSHis2.Models.Drug", "DiagnosisNavigation")
                        .WithMany("DiagnosisDrugs")
                        .HasForeignKey("DiagnosisId")
                        .HasConstraintName("FK_diagnosisDrugs_drugs");

                    b.Navigation("Diagnosis");

                    b.Navigation("DiagnosisNavigation");
                });

            modelBuilder.Entity("TSHis2.Models.DiagnosisTest", b =>
                {
                    b.HasOne("TSHis2.Models.Diagnosis", "Diagnosis")
                        .WithMany("DiagnosisTests")
                        .HasForeignKey("DiagnosisId")
                        .HasConstraintName("FK_diagnosisTests_diagnosis");

                    b.HasOne("TSHis2.Models.TestsXRay", "Test")
                        .WithMany("DiagnosisTests")
                        .HasForeignKey("TestId")
                        .HasConstraintName("FK_diagnosisTests_tests_x-rays");

                    b.Navigation("Diagnosis");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("TSHis2.Models.Visit", b =>
                {
                    b.HasOne("TSHis2.Models.Patient", "Patient")
                        .WithMany("Visits")
                        .HasForeignKey("PatientId")
                        .IsRequired()
                        .HasConstraintName("FK_visits_patient");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("TSHis2.Models.Diagnosis", b =>
                {
                    b.Navigation("DiagnosisDrugs");

                    b.Navigation("DiagnosisTests");
                });

            modelBuilder.Entity("TSHis2.Models.Drug", b =>
                {
                    b.Navigation("DiagnosisDrugs");
                });

            modelBuilder.Entity("TSHis2.Models.Employee", b =>
                {
                    b.Navigation("Diagnoses");
                });

            modelBuilder.Entity("TSHis2.Models.Patient", b =>
                {
                    b.Navigation("Visits");
                });

            modelBuilder.Entity("TSHis2.Models.TestsXRay", b =>
                {
                    b.Navigation("DiagnosisTests");
                });

            modelBuilder.Entity("TSHis2.Models.Visit", b =>
                {
                    b.Navigation("Diagnoses");
                });
#pragma warning restore 612, 618
        }
    }
}
