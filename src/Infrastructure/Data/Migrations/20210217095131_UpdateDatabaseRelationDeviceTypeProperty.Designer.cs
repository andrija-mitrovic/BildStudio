﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210217095131_UpdateDatabaseRelationDeviceTypeProperty")]
    partial class UpdateDatabaseRelationDeviceTypeProperty
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationCore.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeviceTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("DeviceTypeId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("ApplicationCore.Models.DevicePropertyValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<int>("DeviceTypePropertyId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeviceTypePropertyId")
                        .IsUnique();

                    b.ToTable("DevicePropertyValues");
                });

            modelBuilder.Entity("ApplicationCore.Models.DeviceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("DeviceTypes");
                });

            modelBuilder.Entity("ApplicationCore.Models.DeviceTypeProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeviceTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("DeviceTypeId");

                    b.ToTable("DeviceTypeProperties");
                });

            modelBuilder.Entity("ApplicationCore.Models.Device", b =>
                {
                    b.HasOne("ApplicationCore.Models.DeviceType", "DeviceType")
                        .WithMany("Devices")
                        .HasForeignKey("DeviceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApplicationCore.Models.DevicePropertyValue", b =>
                {
                    b.HasOne("ApplicationCore.Models.DeviceTypeProperty", "DeviceTypeProperty")
                        .WithOne("DevicePropertyValue")
                        .HasForeignKey("ApplicationCore.Models.DevicePropertyValue", "DeviceTypePropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApplicationCore.Models.DeviceType", b =>
                {
                    b.HasOne("ApplicationCore.Models.DeviceType", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("ApplicationCore.Models.DeviceTypeProperty", b =>
                {
                    b.HasOne("ApplicationCore.Models.DeviceType", "DeviceType")
                        .WithMany("DeviceTypeProperties")
                        .HasForeignKey("DeviceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
