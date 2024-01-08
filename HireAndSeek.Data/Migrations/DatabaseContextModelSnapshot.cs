﻿// <auto-generated />
using System;
using HireAndSeek.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HireAndSeek.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HireAndSeekEntities.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExperienceLevel")
                        .HasColumnType("int");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("HireAndSeekEntities.CandidateJob", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("JobId");

                    b.ToTable("CandidateJob");
                });

            modelBuilder.Entity("HireAndSeekEntities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("CompanySize")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Industry")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<int?>("JobId")
                        .HasColumnType("int");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("HireAndSeekEntities.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExperienceLevel")
                        .HasColumnType("int");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("HireAndSeekEntities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HireAndSeekEntities.Candidate", b =>
                {
                    b.HasOne("HireAndSeekEntities.User", "User")
                        .WithOne()
                        .HasForeignKey("HireAndSeekEntities.Candidate", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HireAndSeekEntities.CandidateJob", b =>
                {
                    b.HasOne("HireAndSeekEntities.Candidate", "Candidate")
                        .WithMany("Jobs")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HireAndSeekEntities.Job", "Job")
                        .WithMany("Candidates")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("HireAndSeekEntities.Company", b =>
                {
                    b.HasOne("HireAndSeekEntities.User", "User")
                        .WithOne()
                        .HasForeignKey("HireAndSeekEntities.Company", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HireAndSeekEntities.Job", b =>
                {
                    b.HasOne("HireAndSeekEntities.Company", "Company")
                        .WithMany("Job")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("HireAndSeekEntities.Candidate", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("HireAndSeekEntities.Company", b =>
                {
                    b.Navigation("Job");
                });

            modelBuilder.Entity("HireAndSeekEntities.Job", b =>
                {
                    b.Navigation("Candidates");
                });
#pragma warning restore 612, 618
        }
    }
}
