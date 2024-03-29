﻿// <auto-generated />
using System;
using ArtsofteTestProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArtsofteTestProject.Migrations
{
    [DbContext(typeof(ArtsofteTestProjectContext))]
    [Migration("20221226123209_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArtsofteTestProject.Models.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Department");

                    b.HasData(
                        new
                        {
                            Id = new Guid("99d8e7af-aad8-4c37-ac95-bf1186670d95"),
                            Floor = 1,
                            Name = "First"
                        });
                });

            modelBuilder.Entity("ArtsofteTestProject.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("ArtsofteTestProject.Models.EmployeePlace", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProgrammingLanguageId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProgrammingLanguageId");

                    b.ToTable("EmployeePlace");
                });

            modelBuilder.Entity("ArtsofteTestProject.Models.GetAllDepartmentsResult", b =>
                {
                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView(null, (string)null);
                });

            modelBuilder.Entity("ArtsofteTestProject.Models.GetAllEmployeeResult", b =>
                {
                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView(null, (string)null);
                });

            modelBuilder.Entity("ArtsofteTestProject.Models.GetAllProgrammingLanguagesResult", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView(null, (string)null);
                });

            modelBuilder.Entity("ArtsofteTestProject.Models.GetEmployeePlaceResult", b =>
                {
                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProgrammingLanguageId")
                        .HasColumnType("uniqueidentifier");

                    b.ToTable((string)null);

                    b.ToView(null, (string)null);
                });

            modelBuilder.Entity("ArtsofteTestProject.Models.GetEmployeeResult", b =>
                {
                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView(null, (string)null);
                });

            modelBuilder.Entity("ArtsofteTestProject.Models.ProgrammingLanguage", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ProgrammingLanguage");

                    b.HasData(
                        new
                        {
                            Id = new Guid("651e9bd9-cfe8-42a1-b47b-a48b89f3e556"),
                            Name = "Fortran"
                        });
                });

            modelBuilder.Entity("ArtsofteTestProject.Models.EmployeePlace", b =>
                {
                    b.HasOne("ArtsofteTestProject.Models.Department", "Department")
                        .WithMany("EmployeePlace")
                        .HasForeignKey("DepartmentId")
                        .IsRequired()
                        .HasConstraintName("FK_EmployeePlace_Department");

                    b.HasOne("ArtsofteTestProject.Models.Employee", "Employee")
                        .WithMany("EmployeePlace")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK_EmployeePlace_Employee");

                    b.HasOne("ArtsofteTestProject.Models.ProgrammingLanguage", "ProgrammingLanguage")
                        .WithMany("EmployeePlace")
                        .HasForeignKey("ProgrammingLanguageId")
                        .IsRequired()
                        .HasConstraintName("FK_EmployeePlace_ProgrammingLanguage");

                    b.Navigation("Department");

                    b.Navigation("Employee");

                    b.Navigation("ProgrammingLanguage");
                });

            modelBuilder.Entity("ArtsofteTestProject.Models.Department", b =>
                {
                    b.Navigation("EmployeePlace");
                });

            modelBuilder.Entity("ArtsofteTestProject.Models.Employee", b =>
                {
                    b.Navigation("EmployeePlace");
                });

            modelBuilder.Entity("ArtsofteTestProject.Models.ProgrammingLanguage", b =>
                {
                    b.Navigation("EmployeePlace");
                });
#pragma warning restore 612, 618
        }
    }
}
