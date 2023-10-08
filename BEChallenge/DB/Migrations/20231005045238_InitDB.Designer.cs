﻿// <auto-generated />
using System;
using DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DB.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20231005045238_InitDB")]
    partial class InitDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DB.Operacion", b =>
                {
                    b.Property<int>("idOperacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idOperacion"));

                    b.Property<double>("monto")
                        .HasColumnType("float");

                    b.Property<string>("nroTarjeta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tipoOperacion")
                        .HasColumnType("int");

                    b.HasKey("idOperacion");

                    b.ToTable("Operaciones");
                });

            modelBuilder.Entity("DB.Tarjeta", b =>
                {
                    b.Property<string>("nroTarjeta")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PIN")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaUltimaExtraccion")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("nroCuenta")
                        .HasColumnType("int");

                    b.Property<double>("saldoActual")
                        .HasColumnType("float");

                    b.HasKey("nroTarjeta");

                    b.ToTable("Tarjetas");
                });
#pragma warning restore 612, 618
        }
    }
}
