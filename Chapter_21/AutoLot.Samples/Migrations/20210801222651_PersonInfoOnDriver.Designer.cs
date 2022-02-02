﻿// <auto-generated />
using System;
using AutoLot.Samples;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoLot.Samples.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210801222651_PersonInfoOnDriver")]
    partial class PersonInfoOnDriver
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.6.21352.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AutoLot.Samples.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("Black");

                    b.Property<DateTime?>("DateBuilt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Display")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComputedColumnSql("[PetName] + ' (' + [Color] + ')'", true);

                    b.Property<bool>("IsDrivable")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("MakeId")
                        .HasColumnType("int");

                    b.Property<string>("PetName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "MakeId" }, "IX_Inventory_MakeId");

                    b.ToTable("Inventory", "dbo");
                });

            modelBuilder.Entity("AutoLot.Samples.Models.CarDriver", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("int")
                        .HasColumnName("InventoryId");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("CarId", "DriverId");

                    b.HasIndex("DriverId");

                    b.ToTable("InventoryToDrivers", "dbo");
                });

            modelBuilder.Entity("AutoLot.Samples.Models.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Drivers", "dbo");
                });

            modelBuilder.Entity("AutoLot.Samples.Models.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Makes", "dbo");
                });

            modelBuilder.Entity("AutoLot.Samples.Models.Radio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int")
                        .HasColumnName("InventoryId");

                    b.Property<bool>("HasSubWoofers")
                        .HasColumnType("bit");

                    b.Property<bool>("HasTweeters")
                        .HasColumnType("bit");

                    b.Property<string>("RadioId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CarId" }, "IX_Radios_CarId")
                        .IsUnique();

                    b.ToTable("Radios", "dbo");
                });

            modelBuilder.Entity("AutoLot.Samples.Models.Car", b =>
                {
                    b.HasOne("AutoLot.Samples.Models.Make", "MakeNavigation")
                        .WithMany("Cars")
                        .HasForeignKey("MakeId")
                        .HasConstraintName("FK_Inventory_Makes_MakeId")
                        .IsRequired();

                    b.Navigation("MakeNavigation");
                });

            modelBuilder.Entity("AutoLot.Samples.Models.CarDriver", b =>
                {
                    b.HasOne("AutoLot.Samples.Models.Car", "CarNavigation")
                        .WithMany("CarDrivers")
                        .HasForeignKey("CarId")
                        .HasConstraintName("FK_InventoryDriver_Inventory_InventoryId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("AutoLot.Samples.Models.Driver", "DriverNavigation")
                        .WithMany("CarDrivers")
                        .HasForeignKey("DriverId")
                        .HasConstraintName("FK_InventoryDriver_Drivers_DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarNavigation");

                    b.Navigation("DriverNavigation");
                });

            modelBuilder.Entity("AutoLot.Samples.Models.Driver", b =>
                {
                    b.OwnsOne("AutoLot.Samples.Models.Person", "PersonInfo", b1 =>
                        {
                            b1.Property<int>("DriverId")
                                .HasColumnType("int");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("LastName");

                            b1.HasKey("DriverId");

                            b1.ToTable("Drivers");

                            b1.WithOwner()
                                .HasForeignKey("DriverId");
                        });

                    b.Navigation("PersonInfo")
                        .IsRequired();
                });

            modelBuilder.Entity("AutoLot.Samples.Models.Radio", b =>
                {
                    b.HasOne("AutoLot.Samples.Models.Car", "CarNavigation")
                        .WithOne("RadioNavigation")
                        .HasForeignKey("AutoLot.Samples.Models.Radio", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarNavigation");
                });

            modelBuilder.Entity("AutoLot.Samples.Models.Car", b =>
                {
                    b.Navigation("CarDrivers");

                    b.Navigation("RadioNavigation");
                });

            modelBuilder.Entity("AutoLot.Samples.Models.Driver", b =>
                {
                    b.Navigation("CarDrivers");
                });

            modelBuilder.Entity("AutoLot.Samples.Models.Make", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
