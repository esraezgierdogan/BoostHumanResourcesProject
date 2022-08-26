﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220826092622_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityLayer.Concrete.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("GrossSalary")
                        .HasColumnType("float");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("TCNO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("EntityLayer.Concrete.AppUserAndWorkShift", b =>
                {
                    b.Property<int>("WorkShiftID")
                        .HasColumnType("int");

                    b.Property<int>("AppUserID")
                        .HasColumnType("int");

                    b.HasKey("WorkShiftID", "AppUserID");

                    b.HasIndex("AppUserID");

                    b.ToTable("AppUserAndWorkShift");
                });

            modelBuilder.Entity("EntityLayer.Concrete.DayOff", b =>
                {
                    b.Property<int>("DayOffID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppUserID")
                        .HasColumnType("int");

                    b.Property<bool>("DepartmentApproval")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ManagerApproval")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DayOffID");

                    b.HasIndex("AppUserID");

                    b.ToTable("DayOffs");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Debit", b =>
                {
                    b.Property<int>("DebitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppUserID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GivenDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DebitID");

                    b.HasIndex("AppUserID");

                    b.ToTable("Debits");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppUserID")
                        .HasColumnType("int");

                    b.Property<string>("DepartmentDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentID");

                    b.HasIndex("AppUserID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EntityLayer.Concrete.DepartmentAndWorkShift", b =>
                {
                    b.Property<int>("WorkShiftID")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentAndWorkShiftID")
                        .HasColumnType("int");

                    b.Property<DateTime>("WorkDate")
                        .HasColumnType("datetime2");

                    b.HasKey("WorkShiftID", "DepartmentID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("DepartmentAndWorkShift");
                });

            modelBuilder.Entity("EntityLayer.Concrete.EmploymentDetails", b =>
                {
                    b.Property<int>("EmploymentDetailsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DismissalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EmploymentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("EmploymentDetailsID");

                    b.HasIndex("AppUserID");

                    b.ToTable("EmploymentDetails");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Expense", b =>
                {
                    b.Property<int>("ExpenseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DemandDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("ExpenseDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ManagerApproval")
                        .HasColumnType("bit");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<int>("Urgency")
                        .HasColumnType("int");

                    b.HasKey("ExpenseID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Overtime", b =>
                {
                    b.Property<int>("OvertimeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DermandDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("ManHour")
                        .HasColumnType("float");

                    b.Property<bool>("ManagerApproval")
                        .HasColumnType("bit");

                    b.Property<string>("OvertimeDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Urgency")
                        .HasColumnType("int");

                    b.HasKey("OvertimeID");

                    b.HasIndex("AppUserID");

                    b.ToTable("Overtimes");
                });

            modelBuilder.Entity("EntityLayer.Concrete.WorkHour", b =>
                {
                    b.Property<int>("WorkHourID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("WorkHourID");

                    b.HasIndex("AppUserID");

                    b.ToTable("WorkHours");
                });

            modelBuilder.Entity("EntityLayer.Concrete.WorkShift", b =>
                {
                    b.Property<int>("WorkShiftID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BreakTimeEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BreakTimeStart")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("WorkShiftID");

                    b.ToTable("WorkShifts");
                });

            modelBuilder.Entity("EntityLayer.Concrete.AppUserAndWorkShift", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.WorkShift", "WorkShift")
                        .WithMany()
                        .HasForeignKey("WorkShiftID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("WorkShift");
                });

            modelBuilder.Entity("EntityLayer.Concrete.DayOff", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AppUser", "AppUser")
                        .WithMany("DayOffs")
                        .HasForeignKey("AppUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Debit", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AppUser", "AppUser")
                        .WithMany("Debits")
                        .HasForeignKey("AppUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Department", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AppUser", "AppUser")
                        .WithMany("Departments")
                        .HasForeignKey("AppUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("EntityLayer.Concrete.DepartmentAndWorkShift", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.WorkShift", "WorkShift")
                        .WithMany()
                        .HasForeignKey("WorkShiftID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("WorkShift");
                });

            modelBuilder.Entity("EntityLayer.Concrete.EmploymentDetails", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AppUser", "AppUser")
                        .WithMany("EmploymentDetails")
                        .HasForeignKey("AppUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Expense", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Department", "Department")
                        .WithMany("Expenses")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Overtime", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AppUser", "AppUser")
                        .WithMany("Overtimes")
                        .HasForeignKey("AppUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("EntityLayer.Concrete.WorkHour", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AppUser", "AppUser")
                        .WithMany("WorkHours")
                        .HasForeignKey("AppUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("EntityLayer.Concrete.AppUser", b =>
                {
                    b.Navigation("DayOffs");

                    b.Navigation("Debits");

                    b.Navigation("Departments");

                    b.Navigation("EmploymentDetails");

                    b.Navigation("Overtimes");

                    b.Navigation("WorkHours");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Department", b =>
                {
                    b.Navigation("Expenses");
                });
#pragma warning restore 612, 618
        }
    }
}