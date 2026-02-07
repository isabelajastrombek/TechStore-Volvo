using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TechStore.Domain.Entities;


namespace TechStore.Infrastructure.Data;

public partial class ECommerceTechContext : DbContext
{
    public ECommerceTechContext()
    {
    }

    public ECommerceTechContext(DbContextOptions<ECommerceTechContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddressTb> AddressTbs { get; set; }

    public virtual DbSet<CardTb> CardTbs { get; set; }

    public virtual DbSet<CategoryTb> CategoryTbs { get; set; }

    public virtual DbSet<ClientTb> ClientTbs { get; set; }

    public virtual DbSet<ItemOrderTb> ItemOrderTbs { get; set; }

    public virtual DbSet<OrderTb> OrderTbs { get; set; }

    public virtual DbSet<ProductTb> ProductTbs { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddressTb>(entity =>
        {
            entity.HasKey(e => e.IdAddress).HasName("PK__Address___F1CFF37FDB5333E5");

            entity.ToTable("Address_tb", "Client");

            entity.Property(e => e.CityAddress)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.ComplementAddress)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NumberAddress)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.StateAddress)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.StreetAddress)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.TypeAddress)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.AddressTbs)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Address_Client");
        });

        modelBuilder.Entity<CardTb>(entity =>
        {
            entity.HasKey(e => e.IdCard).HasName("PK__Card_tb__3B7B33C2C00C6990");

            entity.ToTable("Card_tb", "Sales");

            entity.Property(e => e.CpfCard)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.MaskedNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NameOnCard)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NicknameCard)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PaymentToken).IsUnicode(false);
            entity.Property(e => e.TypeCard)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.CardTbs)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Card_Client");
        });

        modelBuilder.Entity<CategoryTb>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PK__Category__CBD74706B6DDF11B");

            entity.ToTable("Category_tb", "Catalog");

            entity.Property(e => e.NameCategory)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ClientTb>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("PK__Client_t__C1961B3381C3287C");

            entity.ToTable("Client_tb", "Client");

            entity.HasIndex(e => e.EmailClient, "UQ__Client_t__25C496EDC2494DC6").IsUnique();

            entity.HasIndex(e => e.CpfClient, "UQ__Client_t__E9D8CD8CE032E98A").IsUnique();

            entity.Property(e => e.CpfClient)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.EmailClient)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.NameClient)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PasswordClient)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneClient)
                .HasMaxLength(16)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ItemOrderTb>(entity =>
        {
            entity.HasKey(e => e.IdItemOrder).HasName("PK__ItemOrde__37B36224D4F3D7DF");

            entity.ToTable("ItemOrder_tb", "Sales");

            entity.Property(e => e.PriceUnitItem).HasColumnType("money");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.ItemOrderTbs)
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("FK_Item_Order");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ItemOrderTbs)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK_Item_Product");
        });

        modelBuilder.Entity<OrderTb>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PK__Order_tb__C38F3009234CE112");

            entity.ToTable("Order_tb", "Sales");

            entity.Property(e => e.DateOrder).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IdAddress).HasColumnName("idAddress");
            entity.Property(e => e.IdCard).HasColumnName("idCard");
            entity.Property(e => e.StatusOrder)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalPrice).HasColumnType("money");
            entity.Property(e => e.TotalShipping).HasColumnType("money");

            entity.HasOne(d => d.IdAddressNavigation).WithMany(p => p.OrderTbs)
                .HasForeignKey(d => d.IdAddress)
                .HasConstraintName("FK_Order_Address");

            entity.HasOne(d => d.IdCardNavigation).WithMany(p => p.OrderTbs)
                .HasForeignKey(d => d.IdCard)
                .HasConstraintName("FK_Order_Card");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.OrderTbs)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("FK_Order_Client");
        });

        modelBuilder.Entity<ProductTb>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK__Product___2E8946D4D4B312D6");

            entity.ToTable("Product_tb", "Catalog");

            entity.Property(e => e.BrandProduct)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DescriptionProduct)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.NameProduct)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PriceProduct).HasColumnType("money");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.ProductTbs)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
