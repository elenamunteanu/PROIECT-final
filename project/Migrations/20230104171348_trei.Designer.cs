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
    [Migration("20230104171348_trei")]
    partial class trei
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

                    b.ToTable("Plecari");
                });

            modelBuilder.Entity("project.Models.Sosiri", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

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

                    b.HasIndex("DestinatieID");

                    b.ToTable("Sosiri");
                });

            modelBuilder.Entity("project.Models.Sosiri", b =>
                {
                    b.HasOne("project.Models.Destinatie", "Destinatie")
                        .WithMany("ZborS")
                        .HasForeignKey("DestinatieID");

                    b.Navigation("Destinatie");
                });

            modelBuilder.Entity("project.Models.Destinatie", b =>
                {
                    b.Navigation("ZborS");
                });
#pragma warning restore 612, 618
        }
    }
}
