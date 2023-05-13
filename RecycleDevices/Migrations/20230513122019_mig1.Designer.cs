﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecycleDevices.Data;

#nullable disable

namespace RecycleDevices.Migrations
{
    [DbContext(typeof(ApointmentContext))]
    [Migration("20230513122019_mig1")]
    partial class mig1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RecycleDevices.Models.Apointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeliveryID")
                        .HasColumnType("int");

                    b.Property<string>("Departament")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Municipality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("ProductCategoryID")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Apointment");
                });

            modelBuilder.Entity("RecycleDevices.Models.Domiciliario", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Day")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HourEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HourInitial")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdDom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Domiciliarios");
                });

            modelBuilder.Entity("RecycleDevices.Models.Funcionario", b =>
                {
                    b.Property<string>("IdFun")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NivelEstudio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdFun");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("RecycleDevices.Models.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Package");
                });

            modelBuilder.Entity("RecycleDevices.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("RecycleDevices.Models.Token", b =>
                {
                    b.Property<int>("id_token")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_token"));

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ffin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("finicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("id_user")
                        .HasColumnType("int");

                    b.HasKey("id_token");

                    b.HasIndex("id_user");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("RecycleDevices.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("cc")
                        .HasColumnType("bigint");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("phoneNumber")
                        .HasColumnType("bigint");

                    b.Property<float>("points")
                        .HasColumnType("real");

                    b.Property<int>("roll")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("RecycleDevices.Models.Vehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IDDomiciliario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("RecycleDevices.Models.Token", b =>
                {
                    b.HasOne("RecycleDevices.Models.User", "USUARIO")
                        .WithMany()
                        .HasForeignKey("id_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("USUARIO");
                });
#pragma warning restore 612, 618
        }
    }
}
