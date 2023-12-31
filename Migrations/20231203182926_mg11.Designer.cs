﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Pfeapp2.Migrations
{
    [DbContext(typeof(SoutenanceContext))]
    [Migration("20231203182926_mg11")]
    partial class mg11
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PfeApp.Models.Enseignant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Enseignant");
                });

            modelBuilder.Entity("PfeApp.Models.Etudiant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateN")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Etudiant");
                });

            modelBuilder.Entity("PfeApp.Models.Pfe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateD")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateF")
                        .HasColumnType("datetime2");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("EncadrantID")
                        .HasColumnType("int");

                    b.Property<int>("SocieteID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("EncadrantID");

                    b.HasIndex("SocieteID");

                    b.ToTable("Pfe");
                });

            modelBuilder.Entity("PfeApp.Models.Pfe_etudiant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EtudiantID")
                        .HasColumnType("int");

                    b.Property<int>("PfeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EtudiantID");

                    b.HasIndex("PfeId");

                    b.ToTable("Pfe_etudiant");
                });

            modelBuilder.Entity("PfeApp.Models.Societe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Lib")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Societe");
                });

            modelBuilder.Entity("PfeApp.Models.Soutenance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Heure")
                        .HasColumnType("datetime2");

                    b.Property<int>("PfeId")
                        .HasColumnType("int");

                    b.Property<int>("PresidentId")
                        .HasColumnType("int");

                    b.Property<int>("RapporteurId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PfeId");

                    b.HasIndex("PresidentId");

                    b.HasIndex("RapporteurId");

                    b.ToTable("Soutenance");
                });

            modelBuilder.Entity("PfeApp.Models.Pfe", b =>
                {
                    b.HasOne("PfeApp.Models.Enseignant", "Encadrant")
                        .WithMany()
                        .HasForeignKey("EncadrantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PfeApp.Models.Societe", "Societe")
                        .WithMany()
                        .HasForeignKey("SocieteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Encadrant");

                    b.Navigation("Societe");
                });

            modelBuilder.Entity("PfeApp.Models.Pfe_etudiant", b =>
                {
                    b.HasOne("PfeApp.Models.Etudiant", "Etudiant")
                        .WithMany()
                        .HasForeignKey("EtudiantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PfeApp.Models.Pfe", "Pfe")
                        .WithMany()
                        .HasForeignKey("PfeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Etudiant");

                    b.Navigation("Pfe");
                });

            modelBuilder.Entity("PfeApp.Models.Soutenance", b =>
                {
                    b.HasOne("PfeApp.Models.Pfe", "Pfe")
                        .WithMany("SoutenancesPfe")
                        .HasForeignKey("PfeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PfeApp.Models.Enseignant", "President")
                        .WithMany("SoutenancesPresident")
                        .HasForeignKey("PresidentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PfeApp.Models.Enseignant", "Rapporteur")
                        .WithMany("SoutenancesRapporteur")
                        .HasForeignKey("RapporteurId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pfe");

                    b.Navigation("President");

                    b.Navigation("Rapporteur");
                });

            modelBuilder.Entity("PfeApp.Models.Enseignant", b =>
                {
                    b.Navigation("SoutenancesPresident");

                    b.Navigation("SoutenancesRapporteur");
                });

            modelBuilder.Entity("PfeApp.Models.Pfe", b =>
                {
                    b.Navigation("SoutenancesPfe");
                });
#pragma warning restore 612, 618
        }
    }
}
