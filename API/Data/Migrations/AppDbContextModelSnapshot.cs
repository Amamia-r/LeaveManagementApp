﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.15");

            modelBuilder.Entity("API.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("JoiningDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Department = "IT",
                            FullName = "Harry Potter",
                            JoiningDate = new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Department = "HR",
                            FullName = "Hermione Granger",
                            JoiningDate = new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Department = "Finance",
                            FullName = "Ron Weasley",
                            JoiningDate = new DateTime(2019, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("API.Models.LeaveRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("LeaveType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Reason")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("LeaveRequests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 4, 17, 16, 20, 21, 114, DateTimeKind.Local).AddTicks(7486),
                            EmployeeId = 1,
                            EndDate = new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LeaveType = "Annual",
                            Reason = "Vacation",
                            StartDate = new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Approved"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 4, 17, 16, 20, 21, 114, DateTimeKind.Local).AddTicks(7502),
                            EmployeeId = 1,
                            EndDate = new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LeaveType = "Annual",
                            Reason = "Family trip",
                            StartDate = new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Pending"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2025, 4, 17, 16, 20, 21, 114, DateTimeKind.Local).AddTicks(7506),
                            EmployeeId = 2,
                            EndDate = new DateTime(2024, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LeaveType = "Sick",
                            Reason = "Flu symptoms",
                            StartDate = new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Approved"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2025, 4, 17, 16, 20, 21, 114, DateTimeKind.Local).AddTicks(7509),
                            EmployeeId = 2,
                            EndDate = new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LeaveType = "Other",
                            Reason = "Personal business trip",
                            StartDate = new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Rejected"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2025, 4, 17, 16, 20, 21, 114, DateTimeKind.Local).AddTicks(7512),
                            EmployeeId = 3,
                            EndDate = new DateTime(2024, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LeaveType = "Annual",
                            Reason = "Europe trip",
                            StartDate = new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Approved"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2025, 4, 17, 16, 20, 21, 114, DateTimeKind.Local).AddTicks(7515),
                            EmployeeId = 3,
                            EndDate = new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LeaveType = "Annual",
                            Reason = "Staycation",
                            StartDate = new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Approved"
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2025, 4, 17, 16, 20, 21, 114, DateTimeKind.Local).AddTicks(7518),
                            EmployeeId = 3,
                            EndDate = new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LeaveType = "Sick",
                            Reason = "",
                            StartDate = new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Pending"
                        });
                });

            modelBuilder.Entity("API.Models.LeaveRequest", b =>
                {
                    b.HasOne("API.Models.Employee", "Employee")
                        .WithMany("LeaveRequests")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("API.Models.Employee", b =>
                {
                    b.Navigation("LeaveRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
