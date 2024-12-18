﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using findmyfood.Models;

#nullable disable

namespace findmyfood.Migrations
{
    [DbContext(typeof(FindmyfoodContext))]
    [Migration("20241113221004_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");
            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("findmyfood.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("varchar(450)")
                        .HasColumnName("category_name");

                    b.HasKey("CategoryId")
                        .HasName("PRIMARY");

                    b.ToTable("category", (string)null);
                });

            modelBuilder.Entity("findmyfood.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("item_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<string>("Description")
                        .HasMaxLength(450)
                        .HasColumnType("varchar(450)")
                        .HasColumnName("description");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("image_url");

                    b.Property<string>("ItemCat")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("item_cat");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("item_name");

                    b.Property<int>("ItemNo")
                        .HasColumnType("int")
                        .HasColumnName("item_no");

                    b.Property<float>("Price")
                        .HasColumnType("float")
                        .HasColumnName("price");

                    b.Property<int>("StoreId")
                        .HasColumnType("int")
                        .HasColumnName("store_id");

                    b.Property<float>("Weight")
                        .HasColumnType("float")
                        .HasColumnName("weight");

                    b.HasKey("ItemId")
                        .HasName("PRIMARY");

                    b.ToTable("item", (string)null);
                });

            modelBuilder.Entity("findmyfood.Models.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("store_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("StoreId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("country");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("state");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("store_name");

                    b.Property<string>("StreetAddr")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("street_addr");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("zip_code");

                    b.HasKey("StoreId")
                        .HasName("PRIMARY");

                    b.ToTable("store", (string)null);
                });

            modelBuilder.Entity("findmyfood.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("City")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("country");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("password");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int")
                        .HasColumnName("phone_number");

                    b.Property<string>("State")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("state");

                    b.Property<string>("StreetAddr")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("street_addr");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("username");

                    b.Property<string>("Zip")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("zip");

                    b.HasKey("UserId")
                        .HasName("PRIMARY");

                    b.ToTable("user", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
