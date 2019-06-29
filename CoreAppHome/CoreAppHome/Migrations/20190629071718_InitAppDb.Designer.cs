﻿// <auto-generated />
using CoreAppHome.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreAppHome.Migrations
{
    [DbContext(typeof(AppHomeDbContext))]
    [Migration("20190629071718_InitAppDb")]
    partial class InitAppDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreAppHome.Models.Department", b =>
                {
                    b.Property<int>("DeptRowId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity");

                    b.Property<string>("DeptName")
                        .IsRequired();

                    b.Property<string>("DeptNo")
                        .IsRequired();

                    b.Property<string>("Location")
                        .IsRequired();

                    b.HasKey("DeptRowId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("CoreAppHome.Models.Employee", b =>
                {
                    b.Property<int>("EmpRowId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeptRowId");

                    b.Property<string>("Designation")
                        .IsRequired();

                    b.Property<string>("EmpName")
                        .IsRequired();

                    b.Property<string>("EmpNo")
                        .IsRequired();

                    b.Property<int>("Salary");

                    b.HasKey("EmpRowId");

                    b.HasIndex("DeptRowId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CoreAppHome.Models.Employee", b =>
                {
                    b.HasOne("CoreAppHome.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DeptRowId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}