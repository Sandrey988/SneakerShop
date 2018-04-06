﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Sneaker.Models;
using System;

namespace Sneaker.Migrations
{
    [DbContext(typeof(ModelContext))]
    [Migration("20180402173423_HelpMe")]
    partial class HelpMe
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sneaker.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrandName")
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .HasMaxLength(2000);

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Sneaker.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName")
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .HasMaxLength(2000);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Sneaker.Models.Img", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImgUrl");

                    b.Property<int>("SneakerId");

                    b.HasKey("Id");

                    b.HasIndex("SneakerId");

                    b.ToTable("Imgs");
                });

            modelBuilder.Entity("Sneaker.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(2000);

                    b.Property<string>("MaterialName")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("Sneaker.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<decimal>("Price");

                    b.Property<string>("ProductName")
                        .HasMaxLength(50);

                    b.Property<int>("SneakerId");

                    b.HasKey("ProductId");

                    b.HasIndex("SneakerId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Sneaker.Models.ProductSize", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("SizeId");

                    b.HasKey("ProductId", "SizeId");

                    b.HasIndex("SizeId");

                    b.ToTable("ProductSize");
                });

            modelBuilder.Entity("Sneaker.Models.Size", b =>
                {
                    b.Property<int>("SizeId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Number");

                    b.HasKey("SizeId");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("Sneaker.Models.Sneaker", b =>
                {
                    b.Property<int>("SneakerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrandId");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description")
                        .HasMaxLength(2000);

                    b.Property<int>("MaterialId");

                    b.Property<string>("SneakerName")
                        .HasMaxLength(50);

                    b.HasKey("SneakerId");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MaterialId");

                    b.ToTable("Sneakers");
                });

            modelBuilder.Entity("Sneaker.Models.Img", b =>
                {
                    b.HasOne("Sneaker.Models.Sneaker", "Sneaker")
                        .WithMany("Img")
                        .HasForeignKey("SneakerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Sneaker.Models.Product", b =>
                {
                    b.HasOne("Sneaker.Models.Sneaker", "Sneaker")
                        .WithMany("Products")
                        .HasForeignKey("SneakerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Sneaker.Models.ProductSize", b =>
                {
                    b.HasOne("Sneaker.Models.Product", "Product")
                        .WithMany("SneakerSizes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Sneaker.Models.Size", "Size")
                        .WithMany("SneakerSizes")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Sneaker.Models.Sneaker", b =>
                {
                    b.HasOne("Sneaker.Models.Brand", "Brand")
                        .WithMany("Sneaker")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Sneaker.Models.Category", "Category")
                        .WithMany("Sneakers")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Sneaker.Models.Material", "Material")
                        .WithMany("Sneakers")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
