﻿// <auto-generated />
using System;
using CarRental.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRental.Migrations
{
    [DbContext(typeof(RentalContext))]
    [Migration("20230324151651_FixNameType")]
    partial class FixNameType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("CarRental.Models.ContactInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("email")
                        .HasColumnType("TEXT");

                    b.Property<string>("phone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ContactInfo");
                });

            modelBuilder.Entity("CarRental.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContactInfoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ContactInfoId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("CarRental.Models.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Days")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("RentDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("VehicleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Rental");
                });

            modelBuilder.Entity("CarRental.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PricePerDay")
                        .HasColumnType("TEXT");

                    b.Property<string>("Registration")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("VehicleType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("CarRental.Models.Customer", b =>
                {
                    b.HasOne("CarRental.Models.ContactInfo", "ContactInfo")
                        .WithMany()
                        .HasForeignKey("ContactInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactInfo");
                });

            modelBuilder.Entity("CarRental.Models.Rental", b =>
                {
                    b.HasOne("CarRental.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRental.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Vehicle");
                });
#pragma warning restore 612, 618
        }
    }
}
