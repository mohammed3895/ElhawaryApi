﻿// <auto-generated />
using System;
using ElhawaryApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElhawaryApi.Migrations
{
    [DbContext(typeof(AppDbcontext))]
    [Migration("20241020152617_relations")]
    partial class relations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ElhawaryApi.Models.Domain.Accessory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("PurchasePrice")
                        .HasColumnType("float");

                    b.Property<int>("Qantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Accessories");
                });

            modelBuilder.Entity("ElhawaryApi.Models.Domain.AccessoryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccessoryTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Battery"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cover"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Screen Protector"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Data Transfer Kit"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Charge"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("ElhawaryApi.Models.Domain.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ElhawaryApi.Models.Domain.Maintenance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeviceModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("IssueFees")
                        .HasColumnType("float");

                    b.Property<string>("IssueType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaintenanceId")
                        .HasColumnType("int");

                    b.Property<int>("MaintenanceStatuseId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("PieceOrginalFee")
                        .HasColumnType("float");

                    b.Property<DateTime>("RecievedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaintenanceStatuseId");

                    b.HasIndex("StatusId");

                    b.ToTable("MaintenanceDepartment");
                });

            modelBuilder.Entity("ElhawaryApi.Models.Domain.MaintenanceStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MaintenanceId")
                        .HasColumnType("int");

                    b.Property<int>("MaintenanceStatusTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("TechnicanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaintenanceStatusTypeId");

                    b.HasIndex("TechnicanId");

                    b.ToTable("MaintenanceStatus");
                });

            modelBuilder.Entity("ElhawaryApi.Models.Domain.MaintenanceStatusType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MaintenanceStatusTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TypeName = "InProgress"
                        },
                        new
                        {
                            Id = 2,
                            TypeName = "Done"
                        },
                        new
                        {
                            Id = 3,
                            TypeName = "Refused"
                        });
                });

            modelBuilder.Entity("ElhawaryApi.Models.Domain.MaintenanceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("MaintenanceTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = (byte)0
                        },
                        new
                        {
                            Id = 2,
                            Type = (byte)1
                        });
                });

            modelBuilder.Entity("ElhawaryApi.Models.Domain.Technicans", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Technicans");
                });

            modelBuilder.Entity("ElhawaryApi.Models.Domain.Maintenance", b =>
                {
                    b.HasOne("ElhawaryApi.Models.Domain.MaintenanceType", "MaintenanceType")
                        .WithMany()
                        .HasForeignKey("MaintenanceStatuseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElhawaryApi.Models.Domain.MaintenanceStatus", "Status")
                        .WithMany("Maintenances")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaintenanceType");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ElhawaryApi.Models.Domain.MaintenanceStatus", b =>
                {
                    b.HasOne("ElhawaryApi.Models.Domain.MaintenanceStatusType", "MaintenanceStatusType")
                        .WithMany()
                        .HasForeignKey("MaintenanceStatusTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElhawaryApi.Models.Domain.Technicans", "Technican")
                        .WithMany()
                        .HasForeignKey("TechnicanId");

                    b.Navigation("MaintenanceStatusType");

                    b.Navigation("Technican");
                });

            modelBuilder.Entity("ElhawaryApi.Models.Domain.Technicans", b =>
                {
                    b.HasOne("ElhawaryApi.Models.Domain.Department", "Department")
                        .WithMany("Technicans")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ElhawaryApi.Models.Domain.Department", b =>
                {
                    b.Navigation("Technicans");
                });

            modelBuilder.Entity("ElhawaryApi.Models.Domain.MaintenanceStatus", b =>
                {
                    b.Navigation("Maintenances");
                });
#pragma warning restore 612, 618
        }
    }
}
