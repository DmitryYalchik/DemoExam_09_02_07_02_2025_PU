using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoExam_09_02_07_02_2025_PU.Models;
/// <summary>
/// Модуль 2
/// </summary>
public partial class DemoExam090207022025PuContext : DbContext
{
    public DemoExam090207022025PuContext()
    {
    }

    public DemoExam090207022025PuContext(DbContextOptions<DemoExam090207022025PuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<MaterialsType> MaterialsTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductsMaterial> ProductsMaterials { get; set; }

    public virtual DbSet<ProductsType> ProductsTypes { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    /// <summary>
    /// Была выполнена команда:
    /// Scaffold-DbContext "Server=ROFOCALE-PC\SQLEXPRESS;Database=DemoExam_09_02_07_02_2025_PU;TrustServerCertificate=True;Trusted_Connection=True" -OutputDir Models Microsoft.EntityFrameworkCore.SqlServer
    /// 
    /// Если у вас не Windows/NTLM аутентификация на сервере SQL, то добавьте параметры "User ID={логин};Password={пароль}"
    /// Чтобы строка подключения была универсальной почти для всех "ROFOCALE-PC" было заменено на "." вручную
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=DemoExam_09_02_07_02_2025_PU;TrustServerCertificate=True;Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Material>(entity =>
        {
            entity.Property(e => e.CostPerUnit)
                .HasDefaultValueSql("((0.00))")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MinimalQuantity)
                .HasDefaultValueSql("((0.00))")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.QuantityInPack)
                .HasDefaultValueSql("((0.00))")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.QuantityInStock)
                .HasDefaultValueSql("((0.00))")
                .HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Type).WithMany(p => p.Materials)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Materials_MaterialsTypes");

            entity.HasOne(d => d.Unit).WithMany(p => p.Materials)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Materials_Units");
        });

        modelBuilder.Entity<MaterialsType>(entity =>
        {
            entity.Property(e => e.LostCoef)
                .HasDefaultValueSql("((0.00))")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Article).HasMaxLength(50);
            entity.Property(e => e.MinimalCost)
                .HasDefaultValueSql("((0.00))")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Name).HasMaxLength(150);

            entity.HasOne(d => d.Type).WithMany(p => p.Products)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_ProductsTypes");
        });

        modelBuilder.Entity<ProductsMaterial>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Coef)
                .HasDefaultValueSql("((0.00))")
                .HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Material).WithMany()
                .HasForeignKey(d => d.MaterialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductsMaterials_Materials");

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductsMaterials_Products");
        });

        modelBuilder.Entity<ProductsType>(entity =>
        {
            entity.Property(e => e.Coef)
                .HasDefaultValueSql("((0.00))")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.Property(e => e.ShortName).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
