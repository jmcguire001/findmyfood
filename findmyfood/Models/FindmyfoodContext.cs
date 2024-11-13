using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace findmyfood.Models;

public partial class FindmyfoodContext : DbContext
{
    public FindmyfoodContext()
    {
    }

    public FindmyfoodContext(DbContextOptions<FindmyfoodContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=findmyfood-db.cdou0c62w3hq.us-east-2.rds.amazonaws.com;database=findmyfood;user=findmyfoodadmin;password=findmyFoodAdmin!", ServerVersion.Parse("8.0.39-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("category");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(450)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PRIMARY");

            entity.ToTable("item");

            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.Description)
                .HasMaxLength(450)
                .HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(45)
                .HasColumnName("image_url");
            entity.Property(e => e.ItemCat)
                .HasMaxLength(45)
                .HasColumnName("item_cat");
            entity.Property(e => e.ItemName)
                .HasMaxLength(45)
                .HasColumnName("item_name");
            entity.Property(e => e.ItemNo).HasColumnName("item_no");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.StoreId).HasColumnName("store_id");
            entity.Property(e => e.Weight).HasColumnName("weight");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PRIMARY");

            entity.ToTable("store");

            entity.Property(e => e.StoreId).HasColumnName("store_id");
            entity.Property(e => e.City)
                .HasMaxLength(45)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(45)
                .HasColumnName("country");
            entity.Property(e => e.State)
                .HasMaxLength(45)
                .HasColumnName("state");
            entity.Property(e => e.StoreName)
                .HasMaxLength(100)
                .HasColumnName("store_name");
            entity.Property(e => e.StreetAddr)
                .HasMaxLength(45)
                .HasColumnName("street_addr");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(45)
                .HasColumnName("zip_code");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.City)
                .HasMaxLength(45)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(45)
                .HasColumnName("country");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(45)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(45)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
            entity.Property(e => e.State)
                .HasMaxLength(45)
                .HasColumnName("state");
            entity.Property(e => e.StreetAddr)
                .HasMaxLength(45)
                .HasColumnName("street_addr");
            entity.Property(e => e.Username)
                .HasMaxLength(45)
                .HasColumnName("username");
            entity.Property(e => e.Zip)
                .HasMaxLength(45)
                .HasColumnName("zip");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
