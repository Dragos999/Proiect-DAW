﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_DAW.Data;

#nullable disable

namespace ProiectDAW.Migrations
{
    [DbContext(typeof(proContext))]
    [Migration("20240119011417_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proiect_DAW.Models.Distributor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Distributor");
                });

            modelBuilder.Entity("Proiect_DAW.Models.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<Guid?>("distributorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("distributorId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Proiect_DAW.Models.Order", b =>
                {
                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("itemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId", "itemId");

                    b.HasIndex("itemId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Proiect_DAW.Models.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NrOfStars")
                        .HasColumnType("int");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("userId")
                        .IsUnique();

                    b.ToTable("Review");
                });

            modelBuilder.Entity("Proiect_DAW.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Proiect_DAW.Models.Item", b =>
                {
                    b.HasOne("Proiect_DAW.Models.Distributor", "distributor")
                        .WithMany("items")
                        .HasForeignKey("distributorId");

                    b.Navigation("distributor");
                });

            modelBuilder.Entity("Proiect_DAW.Models.Order", b =>
                {
                    b.HasOne("Proiect_DAW.Models.Item", "item")
                        .WithMany("orders")
                        .HasForeignKey("itemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_DAW.Models.User", "user")
                        .WithMany("orders")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("item");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Proiect_DAW.Models.Review", b =>
                {
                    b.HasOne("Proiect_DAW.Models.User", "user")
                        .WithOne("review")
                        .HasForeignKey("Proiect_DAW.Models.Review", "userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Proiect_DAW.Models.Distributor", b =>
                {
                    b.Navigation("items");
                });

            modelBuilder.Entity("Proiect_DAW.Models.Item", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("Proiect_DAW.Models.User", b =>
                {
                    b.Navigation("orders");

                    b.Navigation("review");
                });
#pragma warning restore 612, 618
        }
    }
}