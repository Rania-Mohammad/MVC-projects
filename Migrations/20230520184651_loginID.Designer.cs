﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projectF.Data;

#nullable disable

namespace projectF.Migrations
{
    [DbContext(typeof(ApplicationDBcontext))]
    [Migration("20230520184651_loginID")]
    partial class loginID
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("projectF.Models.Employee", b =>
                {
                    b.Property<int>("employeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("employeeID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("employeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("employeeimage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("salary")
                        .HasColumnType("float");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("employeeID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("projectF.Models.History", b =>
                {
                    b.Property<int>("HistoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HistoryID"));

                    b.Property<int>("clientID")
                        .HasColumnType("int");

                    b.Property<double>("dollarPrice")
                        .HasColumnType("float");

                    b.Property<double>("egyPrice")
                        .HasColumnType("float");

                    b.Property<int>("employeeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("operationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("operationID")
                        .HasColumnType("int");

                    b.Property<string>("operationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HistoryID");

                    b.HasIndex("employeeID");

                    b.HasIndex("operationID");

                    b.ToTable("history");
                });

            modelBuilder.Entity("projectF.Models.client", b =>
                {
                    b.Property<int>("clientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("clientID"));

                    b.Property<string>("clientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("operationID")
                        .HasColumnType("int");

                    b.Property<string>("operationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("clientID");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("projectF.Models.finance", b =>
                {
                    b.Property<int>("financeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("financeID"));

                    b.Property<double>("maintenanceAmount")
                        .HasColumnType("float");

                    b.Property<double>("operationAmount")
                        .HasColumnType("float");

                    b.Property<int>("operationID")
                        .HasColumnType("int");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("taxes")
                        .HasColumnType("float");

                    b.Property<double>("totalAmount")
                        .HasColumnType("float");

                    b.HasKey("financeID");

                    b.ToTable("finances");
                });

            modelBuilder.Entity("projectF.Models.forgetData", b =>
                {
                    b.Property<int>("employeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("employeeID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("employeeID");

                    b.ToTable("forgetDatas");
                });

            modelBuilder.Entity("projectF.Models.login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Remember")
                        .HasColumnType("bit");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("login");
                });

            modelBuilder.Entity("projectF.Models.operations", b =>
                {
                    b.Property<int>("operationsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("operationsID"));

                    b.Property<int>("clientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("financeID")
                        .HasColumnType("int");

                    b.Property<string>("operationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.HasKey("operationsID");

                    b.HasIndex("clientID");

                    b.ToTable("operations");
                });

            modelBuilder.Entity("projectF.Models.to_do_list", b =>
                {
                    b.Property<int>("to_do_listID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("to_do_listID"));

                    b.Property<DateTime>("deadline")
                        .HasColumnType("datetime2");

                    b.Property<int>("employeeID")
                        .HasColumnType("int");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.Property<int>("taskID")
                        .HasColumnType("int");

                    b.Property<string>("taskName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("to_do_listID");

                    b.HasIndex("employeeID");

                    b.ToTable("to_do_list");
                });

            modelBuilder.Entity("projectF.Models.History", b =>
                {
                    b.HasOne("projectF.Models.Employee", "employee")
                        .WithMany("history")
                        .HasForeignKey("employeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("projectF.Models.operations", "operation")
                        .WithMany("Historys")
                        .HasForeignKey("operationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employee");

                    b.Navigation("operation");
                });

            modelBuilder.Entity("projectF.Models.operations", b =>
                {
                    b.HasOne("projectF.Models.client", "client")
                        .WithMany("operationss")
                        .HasForeignKey("clientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("client");
                });

            modelBuilder.Entity("projectF.Models.to_do_list", b =>
                {
                    b.HasOne("projectF.Models.Employee", "employee")
                        .WithMany("to_do_list")
                        .HasForeignKey("employeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employee");
                });

            modelBuilder.Entity("projectF.Models.Employee", b =>
                {
                    b.Navigation("history");

                    b.Navigation("to_do_list");
                });

            modelBuilder.Entity("projectF.Models.client", b =>
                {
                    b.Navigation("operationss");
                });

            modelBuilder.Entity("projectF.Models.operations", b =>
                {
                    b.Navigation("Historys");
                });
#pragma warning restore 612, 618
        }
    }
}
