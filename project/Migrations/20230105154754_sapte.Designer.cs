﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using project.Data;

#nullable disable

namespace project.Migrations
{
    [DbContext(typeof(projectContext))]
    [Migration("20230105154754_sapte")]
    partial class sapte
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("project.Models.Angajat", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Angajat");
                });

            modelBuilder.Entity("project.Models.Companie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("DenumireCompanie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Companie");
                });

            modelBuilder.Entity("project.Models.Destinatie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("DenumireOras")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Destinatie");
                });

            modelBuilder.Entity("project.Models.Plecari", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CompanieID")
                        .HasColumnType("int");

                    b.Property<int?>("DestinatieID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OraE")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OraP")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ruta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Statut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CompanieID");

                    b.HasIndex("DestinatieID");

                    b.ToTable("Plecari");
                });

            modelBuilder.Entity("project.Models.Sosiri", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CompanieID")
                        .HasColumnType("int");

                    b.Property<int?>("DestinatieID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OraE")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OraP")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ruta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Statut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CompanieID");

                    b.HasIndex("DestinatieID");

                    b.ToTable("Sosiri");
                });

            modelBuilder.Entity("project.Models.Plecari", b =>
                {
                    b.HasOne("project.Models.Companie", "Companie")
                        .WithMany("ZborP")
                        .HasForeignKey("CompanieID");

                    b.HasOne("project.Models.Destinatie", "Destinatie")
                        .WithMany("ZborP")
                        .HasForeignKey("DestinatieID");

                    b.Navigation("Companie");

                    b.Navigation("Destinatie");
                });

            modelBuilder.Entity("project.Models.Sosiri", b =>
                {
                    b.HasOne("project.Models.Companie", "Companie")
                        .WithMany("ZborS")
                        .HasForeignKey("CompanieID");

                    b.HasOne("project.Models.Destinatie", "Destinatie")
                        .WithMany("ZborS")
                        .HasForeignKey("DestinatieID");

                    b.Navigation("Companie");

                    b.Navigation("Destinatie");
                });

            modelBuilder.Entity("project.Models.Companie", b =>
                {
                    b.Navigation("ZborP");

                    b.Navigation("ZborS");
                });

            modelBuilder.Entity("project.Models.Destinatie", b =>
                {
                    b.Navigation("ZborP");

                    b.Navigation("ZborS");
                });
#pragma warning restore 612, 618
        }
    }
}
