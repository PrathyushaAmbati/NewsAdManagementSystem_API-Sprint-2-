﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewsAdManagementSystem_DAL.Data;

namespace NewsAdManagementSystem_DAL.Migrations
{
    [DbContext(typeof(ConnectionString))]
    [Migration("20220204142358_m")]
    partial class m
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NewsAdManagementSystem_Entity.Models.AdvertisementDetailsClass", b =>
                {
                    b.Property<int>("AdCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BWColorCost")
                        .HasColumnType("int");

                    b.Property<int>("ColorCost")
                        .HasColumnType("int");

                    b.Property<string>("PageLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageNo")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdCode");

                    b.ToTable("AdvertisementDetails");
                });

            modelBuilder.Entity("NewsAdManagementSystem_Entity.Models.CustomerAdDetailsClass", b =>
                {
                    b.Property<int>("SNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdCode")
                        .HasColumnType("int");

                    b.Property<int>("AdvtSizesqcm")
                        .HasColumnType("int");

                    b.Property<int>("CustID")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerDetailsCustID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DOI")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DOP")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmpID")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeDetailsEmpID")
                        .HasColumnType("int");

                    b.Property<string>("PageStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalCost")
                        .HasColumnType("int");

                    b.Property<int>("UnitCost")
                        .HasColumnType("int");

                    b.Property<int?>("advertisementDetailsAdCode")
                        .HasColumnType("int");

                    b.HasKey("SNo");

                    b.HasIndex("CustomerDetailsCustID");

                    b.HasIndex("EmployeeDetailsEmpID");

                    b.HasIndex("advertisementDetailsAdCode");

                    b.ToTable("CustomerAdDetails");
                });

            modelBuilder.Entity("NewsAdManagementSystem_Entity.Models.CustomerDetailsClass", b =>
                {
                    b.Property<int>("CustID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOR")
                        .HasColumnType("datetime2");

                    b.HasKey("CustID");

                    b.ToTable("CustomerDetails");
                });

            modelBuilder.Entity("NewsAdManagementSystem_Entity.Models.EmployDetails", b =>
                {
                    b.Property<int>("EmpID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmpContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmpName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pwd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpID");

                    b.ToTable("EmployeeDetails");
                });

            modelBuilder.Entity("NewsAdManagementSystem_Entity.Models.CustomerAdDetailsClass", b =>
                {
                    b.HasOne("NewsAdManagementSystem_Entity.Models.CustomerDetailsClass", "CustomerDetails")
                        .WithMany()
                        .HasForeignKey("CustomerDetailsCustID");

                    b.HasOne("NewsAdManagementSystem_Entity.Models.EmployDetails", "EmployeeDetails")
                        .WithMany()
                        .HasForeignKey("EmployeeDetailsEmpID");

                    b.HasOne("NewsAdManagementSystem_Entity.Models.AdvertisementDetailsClass", "advertisementDetails")
                        .WithMany()
                        .HasForeignKey("advertisementDetailsAdCode");

                    b.Navigation("advertisementDetails");

                    b.Navigation("CustomerDetails");

                    b.Navigation("EmployeeDetails");
                });
#pragma warning restore 612, 618
        }
    }
}