﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Lazada.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Lazada.Migrations
{
    [DbContext(typeof(LazadaDBContext))]
    [Migration("20240325074243_4")]
    partial class _4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.2.24128.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Lazada.Models.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("Address_Default")
                        .HasColumnType("boolean");

                    b.Property<string>("Address_Detail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UsersId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("UsersId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Lazada.Models.Cart", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ShopsId")
                        .HasColumnType("bigint");

                    b.Property<long>("UsersId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ShopsId");

                    b.HasIndex("UsersId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Lazada.Models.CartItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CartsId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("option")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("orderId")
                        .HasColumnType("bigint");

                    b.Property<int>("quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CartsId");

                    b.HasIndex("ProductId");

                    b.HasIndex("orderId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("Lazada.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ParentCategoryId")
                        .HasColumnType("integer");

                    b.Property<long>("ShopsId")
                        .HasColumnType("bigint");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ShopsId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Lazada.Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("CartitemName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("ShopId")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalPrice")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("shoprname_order")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("status")
                        .HasColumnType("integer");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("username_order")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("voucher")
                        .HasColumnType("text[]");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Lazada.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("ProductPrice")
                        .HasColumnType("bigint");

                    b.Property<long>("ShopId")
                        .HasColumnType("bigint");

                    b.Property<int>("Sold")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ShopId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Lazada.Models.Shop", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("Lazada.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Lazada.Models.Voucher", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ShopId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int>("discount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("expire_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<List<string>>("list_product_applied")
                        .HasColumnType("text[]");

                    b.Property<List<string>>("list_user_applied")
                        .HasColumnType("text[]");

                    b.Property<DateTime>("public_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.HasIndex("UserId");

                    b.ToTable("Vouchers");
                });

            modelBuilder.Entity("Lazada.Models.Address", b =>
                {
                    b.HasOne("Lazada.Models.Order", null)
                        .WithMany("Address")
                        .HasForeignKey("OrderId");

                    b.HasOne("Lazada.Models.User", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Lazada.Models.Cart", b =>
                {
                    b.HasOne("Lazada.Models.Shop", "Shops")
                        .WithMany()
                        .HasForeignKey("ShopsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lazada.Models.User", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shops");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Lazada.Models.CartItem", b =>
                {
                    b.HasOne("Lazada.Models.Cart", "Carts")
                        .WithMany("CartItems")
                        .HasForeignKey("CartsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lazada.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lazada.Models.Order", "order")
                        .WithMany("list_cart_item")
                        .HasForeignKey("orderId");

                    b.Navigation("Carts");

                    b.Navigation("Product");

                    b.Navigation("order");
                });

            modelBuilder.Entity("Lazada.Models.Category", b =>
                {
                    b.HasOne("Lazada.Models.Shop", "Shops")
                        .WithMany("Category")
                        .HasForeignKey("ShopsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shops");
                });

            modelBuilder.Entity("Lazada.Models.Order", b =>
                {
                    b.HasOne("Lazada.Models.Shop", "Shop")
                        .WithMany()
                        .HasForeignKey("ShopId");

                    b.HasOne("Lazada.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Shop");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Lazada.Models.Product", b =>
                {
                    b.HasOne("Lazada.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lazada.Models.Shop", "Shop")
                        .WithMany("Product")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("Lazada.Models.Shop", b =>
                {
                    b.HasOne("Lazada.Models.User", "User")
                        .WithMany("shops")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Lazada.Models.Voucher", b =>
                {
                    b.HasOne("Lazada.Models.Shop", "Shop")
                        .WithMany("Voucher")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lazada.Models.User", "User")
                        .WithMany("vouchers")
                        .HasForeignKey("UserId");

                    b.Navigation("Shop");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Lazada.Models.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("Lazada.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Lazada.Models.Order", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("list_cart_item");
                });

            modelBuilder.Entity("Lazada.Models.Shop", b =>
                {
                    b.Navigation("Category");

                    b.Navigation("Product");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("Lazada.Models.User", b =>
                {
                    b.Navigation("shops");

                    b.Navigation("vouchers");
                });
#pragma warning restore 612, 618
        }
    }
}
