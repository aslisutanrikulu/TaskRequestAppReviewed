﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskRequestApp.Models;

namespace TaskRequestApp.Migrations
{
    [DbContext(typeof(TaskAppDbContext))]
    [Migration("20211125154119_four")]
    partial class four
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TaskRequestApp.Models.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TaskRequestApp.Models.Employee", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkShift")
                        .HasColumnType("int");

                    b.Property<string>("managerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ticketId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("managerId");

                    b.HasIndex("ticketId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("TaskRequestApp.Models.Manager", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("TaskRequestApp.Models.Ticket", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("AssignedTicket")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ClosedTicket")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CompletedTicket")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DifficultyLevel")
                        .HasColumnType("int");

                    b.Property<string>("MaterialityLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OpenTicket")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TicketType")
                        .HasColumnType("int");

                    b.Property<string>("customerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("customerId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TaskRequestApp.Models.Employee", b =>
                {
                    b.HasOne("TaskRequestApp.Models.Manager", "manager")
                        .WithMany()
                        .HasForeignKey("managerId");

                    b.HasOne("TaskRequestApp.Models.Ticket", "ticket")
                        .WithMany()
                        .HasForeignKey("ticketId");

                    b.Navigation("manager");

                    b.Navigation("ticket");
                });

            modelBuilder.Entity("TaskRequestApp.Models.Ticket", b =>
                {
                    b.HasOne("TaskRequestApp.Models.Customer", null)
                        .WithMany("Tickets")
                        .HasForeignKey("customerId");
                });

            modelBuilder.Entity("TaskRequestApp.Models.Customer", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}