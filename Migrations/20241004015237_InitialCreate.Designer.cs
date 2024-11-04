﻿// <auto-generated />
using System;
using LabSoft.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LabSoft.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20241004015237_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LabSoft.Data.Cliente", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DireccionId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PreferenciaId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DireccionId");

                    b.HasIndex("PreferenciaId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("LabSoft.Data.Direccion", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Calle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Direccion");
                });

            modelBuilder.Entity("LabSoft.Data.Preferencia", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CanalPreferido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("NotificacionPorSms")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("RecibirInformacion")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Preferencia");
                });

            modelBuilder.Entity("LabSoft.Data.Cliente", b =>
                {
                    b.HasOne("LabSoft.Data.Direccion", "Direccion")
                        .WithMany()
                        .HasForeignKey("DireccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LabSoft.Data.Preferencia", "Preferencia")
                        .WithMany()
                        .HasForeignKey("PreferenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Direccion");

                    b.Navigation("Preferencia");
                });
#pragma warning restore 612, 618
        }
    }
}
