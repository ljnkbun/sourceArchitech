﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shopfloor.Barcode.Infrastructure.Contexts;

#nullable disable

namespace Shopfloor.Barcode.Infrastructure.Migrations
{
    [DbContext(typeof(BarcodeContext))]
    [Migration("20231127102728_Add-BarcodeLocation-Constraints")]
    partial class AddBarcodeLocationConstraints
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shopfloor.Barcode.Domain.Entities.ArticleBarcode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Barcode")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid?>("CreatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CurrentLocationId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid?>("ModifiedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ArticleBarcode", (string)null);
                });

            modelBuilder.Entity("Shopfloor.Barcode.Domain.Entities.BarcodeLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticleBarcodeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid?>("CreatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid?>("ModifiedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ArticleBarcodeId");

                    b.HasIndex("LocationId");

                    b.ToTable("BarcodeLocation", (string)null);
                });

            modelBuilder.Entity("Shopfloor.Barcode.Domain.Entities.GDI", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Buyer")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Color")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid?>("CreatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeliveryOc")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("FromSite")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<byte>("GDIStatus")
                        .HasColumnType("tinyint");

                    b.Property<byte>("GDIType")
                        .HasColumnType("tinyint");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("LotNo")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid?>("ModifiedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("SummaryOc")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("UOM")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("GDI", (string)null);
                });

            modelBuilder.Entity("Shopfloor.Barcode.Domain.Entities.GDIWarehouseTransferPackingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Buyer")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Color")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid?>("CreatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeliveryOC")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FromSite")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("GDINo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte?>("GDIType")
                        .HasColumnType("tinyint");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Location")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("LotNo")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid?>("ModifiedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Note")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("Qty")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Size")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SummaryOC")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("TotalKg")
                        .HasColumnType("decimal(28,8)");

                    b.Property<decimal?>("TotalMeters")
                        .HasColumnType("decimal(28,8)");

                    b.Property<decimal?>("TotalYards")
                        .HasColumnType("decimal(28,8)");

                    b.Property<string>("UOM")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("GDIWarehouseTransferPackingList", (string)null);
                });

            modelBuilder.Entity("Shopfloor.Barcode.Domain.Entities.GDIWarehouseTransferSubItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Color")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid?>("CreatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GDIWarehouseTransferPackingListId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid?>("ModifiedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Note")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("Qty")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Size")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("TotalKg")
                        .HasColumnType("decimal(28,8)");

                    b.Property<decimal?>("TotalMeters")
                        .HasColumnType("decimal(28,8)");

                    b.Property<decimal?>("TotalYards")
                        .HasColumnType("decimal(28,8)");

                    b.Property<string>("UOM")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("GDIWarehouseTransferPackingListId");

                    b.ToTable("GDIWarehouseTransferSubItem", (string)null);
                });

            modelBuilder.Entity("Shopfloor.Barcode.Domain.Entities.GDNWarehouseTransferPackingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Color")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid?>("CreatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FromSite")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("GDNNo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Location")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("LotNo")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid?>("ModifiedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Note")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("OC")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Qty")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Size")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte?>("Status")
                        .HasColumnType("tinyint");

                    b.Property<string>("ToSite")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal?>("TotalKg")
                        .HasColumnType("decimal(28,8)");

                    b.Property<decimal?>("TotalMeters")
                        .HasColumnType("decimal(28,8)");

                    b.Property<decimal?>("TotalYards")
                        .HasColumnType("decimal(28,8)");

                    b.Property<string>("UOM")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("GDNWarehouseTransferPackingList", (string)null);
                });

            modelBuilder.Entity("Shopfloor.Barcode.Domain.Entities.GDNWarehouseTransferSubItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Color")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid?>("CreatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GDNWarehouseTransferPackingListId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid?>("ModifiedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Note")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("Qty")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Size")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte?>("Status")
                        .HasColumnType("tinyint");

                    b.Property<decimal?>("TotalKg")
                        .HasColumnType("decimal(28,8)");

                    b.Property<decimal?>("TotalMeters")
                        .HasColumnType("decimal(28,8)");

                    b.Property<decimal?>("TotalYards")
                        .HasColumnType("decimal(28,8)");

                    b.Property<string>("UOM")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("GDNWarehouseTransferPackingListId");

                    b.ToTable("GDNWarehouseTransferSubItem", (string)null);
                });

            modelBuilder.Entity("Shopfloor.Barcode.Domain.Entities.GRNPackingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Buyer")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Color")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid?>("CreatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Location")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("LotNo")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid?>("ModifiedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Note")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("OC")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Qty")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Size")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SourceASNNo")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<byte?>("Status")
                        .HasColumnType("tinyint");

                    b.Property<string>("Supplier")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal?>("TotalKg")
                        .HasColumnType("decimal(28,8)");

                    b.Property<decimal?>("TotalMeters")
                        .HasColumnType("decimal(28,8)");

                    b.Property<decimal?>("TotalYards")
                        .HasColumnType("decimal(28,8)");

                    b.Property<string>("UOM")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("GRNPackingList", (string)null);
                });

            modelBuilder.Entity("Shopfloor.Barcode.Domain.Entities.GRNSubItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Color")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid?>("CreatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GRNPackingListId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid?>("ModifiedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Note")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("Qty")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Size")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte?>("Status")
                        .HasColumnType("tinyint");

                    b.Property<decimal?>("TotalKg")
                        .HasColumnType("decimal(28,8)");

                    b.Property<decimal?>("TotalMeters")
                        .HasColumnType("decimal(28,8)");

                    b.Property<decimal?>("TotalYards")
                        .HasColumnType("decimal(28,8)");

                    b.Property<string>("UOM")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("GRNPackingListId");

                    b.ToTable("GRNSubItem", (string)null);
                });

            modelBuilder.Entity("Shopfloor.Barcode.Domain.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Barcode")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid?>("CreatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<byte>("LevelLocation")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid?>("ModifiedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("ParentLocationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Location", (string)null);
                });

            modelBuilder.Entity("Shopfloor.Barcode.Domain.Entities.TestEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid?>("CreatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid?>("ModifiedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("TestEntity", (string)null);
                });

            modelBuilder.Entity("Shopfloor.Barcode.Domain.Entities.BarcodeLocation", b =>
                {
                    b.HasOne("Shopfloor.Barcode.Domain.Entities.ArticleBarcode", "ArticleBarcode")
                        .WithMany("BarcodeLocations")
                        .HasForeignKey("ArticleBarcodeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Shopfloor.Barcode.Domain.Entities.Location", "Location")
                        .WithMany("BarcodeLocations")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ArticleBarcode");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Shopfloor.Barcode.Domain.Entities.GDIWarehouseTransferSubItem", b =>
                {
                    b.HasOne("Shopfloor.Barcode.Domain.Entities.GDIWarehouseTransferPackingList", "GDIWarehouseTransferPackingList")
                        .WithMany("GDIWarehouseTransferSubItems")
                        .HasForeignKey("GDIWarehouseTransferPackingListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GDIWarehouseTransferPackingList");
                });

            modelBuilder.Entity("Shopfloor.Barcode.Domain.Entities.GDNWarehouseTransferSubItem", b =>
                {
                    b.HasOne("Shopfloor.Barcode.Domain.Entities.GDNWarehouseTransferPackingList", "GDNWarehouseTransferPackingList")
                        .WithMany("GDNWarehouseTransferSubItems")
                        .HasForeignKey("GDNWarehouseTransferPackingListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GDNWarehouseTransferPackingList");
                });

            modelBuilder.Entity("Shopfloor.Barcode.Domain.Entities.GRNSubItem", b =>
                {
                    b.HasOne("Shopfloor.Barcode.Domain.Entities.GRNPackingList", "GRNPackingList")
                        .WithMany("GRNSubItems")
                        .HasForeignKey("GRNPackingListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GRNPackingList");
                });

            modelBuilder.Entity("Shopfloor.Barcode.Domain.Entities.ArticleBarcode", b =>
                {
                    b.Navigation("BarcodeLocations");
                });

            modelBuilder.Entity("Shopfloor.Barcode.Domain.Entities.GDIWarehouseTransferPackingList", b =>
                {
                    b.Navigation("GDIWarehouseTransferSubItems");
                });

            modelBuilder.Entity("Shopfloor.Barcode.Domain.Entities.GDNWarehouseTransferPackingList", b =>
                {
                    b.Navigation("GDNWarehouseTransferSubItems");
                });

            modelBuilder.Entity("Shopfloor.Barcode.Domain.Entities.GRNPackingList", b =>
                {
                    b.Navigation("GRNSubItems");
                });

            modelBuilder.Entity("Shopfloor.Barcode.Domain.Entities.Location", b =>
                {
                    b.Navigation("BarcodeLocations");
                });
#pragma warning restore 612, 618
        }
    }
}
