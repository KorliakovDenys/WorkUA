﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkUA.Data;

#nullable disable

namespace WorkUA.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230723154618_ApplicantExperienceAdded")]
    partial class ApplicantExperienceAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WorkUA.Models.Applicant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfessionId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("ProfessionId");

                    b.ToTable("Applicant");
                });

            modelBuilder.Entity("WorkUA.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("WorkUA.Models.Employer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Employer");
                });

            modelBuilder.Entity("WorkUA.Models.Profession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Profession");
                });

            modelBuilder.Entity("WorkUA.Models.Vacancy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsRemote")
                        .HasColumnType("bit");

                    b.Property<int?>("ProfessionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployerId");

                    b.HasIndex("ProfessionId");

                    b.ToTable("Vacancy");
                });

            modelBuilder.Entity("WorkUA.Models.Applicant", b =>
                {
                    b.HasOne("WorkUA.Models.City", "City")
                        .WithMany("Applicants")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkUA.Models.Profession", "Profession")
                        .WithMany("Applicants")
                        .HasForeignKey("ProfessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Profession");
                });

            modelBuilder.Entity("WorkUA.Models.Employer", b =>
                {
                    b.HasOne("WorkUA.Models.City", "City")
                        .WithMany("Employers")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("WorkUA.Models.Vacancy", b =>
                {
                    b.HasOne("WorkUA.Models.Employer", "Employer")
                        .WithMany("Vacancies")
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkUA.Models.Profession", "Profession")
                        .WithMany("Vacancies")
                        .HasForeignKey("ProfessionId");

                    b.Navigation("Employer");

                    b.Navigation("Profession");
                });

            modelBuilder.Entity("WorkUA.Models.City", b =>
                {
                    b.Navigation("Applicants");

                    b.Navigation("Employers");
                });

            modelBuilder.Entity("WorkUA.Models.Employer", b =>
                {
                    b.Navigation("Vacancies");
                });

            modelBuilder.Entity("WorkUA.Models.Profession", b =>
                {
                    b.Navigation("Applicants");

                    b.Navigation("Vacancies");
                });
#pragma warning restore 612, 618
        }
    }
}
