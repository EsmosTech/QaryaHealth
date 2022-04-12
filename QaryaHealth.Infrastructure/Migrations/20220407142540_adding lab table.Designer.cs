﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QaryaHealth.Infrastructure;

namespace QaryaHealth.Infrastructure.Migrations
{
    [DbContext(typeof(QaryaHealthDbContext))]
    [Migration("20220407142540_adding lab table")]
    partial class addinglabtable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QaryaHealth.Core.Entities.Lab", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndWorkingHour")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("image");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<DateTime>("StartWorkingHour")
                        .HasColumnType("datetime2")
                        .HasColumnName("end-working-hour");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("WorkingDays")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("working-days");

                    b.HasKey("Id");

                    b.ToTable("lab");
                });

            modelBuilder.Entity("QaryaHealth.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("phone-number");

                    b.Property<int>("Role")
                        .HasColumnType("int")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("user");
                });

            modelBuilder.Entity("QaryaHealth.Core.Entities.Volunteer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birth-date");

                    b.Property<int>("BloodType")
                        .HasColumnType("int")
                        .HasColumnName("blood-type");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("volunteer");
                });
#pragma warning restore 612, 618
        }
    }
}
