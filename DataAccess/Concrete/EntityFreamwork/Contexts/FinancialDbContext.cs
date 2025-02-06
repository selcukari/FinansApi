using Core.Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFreamwork.Contexts
{
    public class FinancialDbContext: DbContext
    {
        public FinancialDbContext(DbContextOptions<FinancialDbContext> options)
        : base(options)
        {
        }
        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<FinancialAsset> FinancialAssets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<FinancialAsset>(entity =>
            {
                // Tablo adını belirt
                entity.ToTable("financial_assets");

                // Primary Key
                entity.HasKey(e => e.AssetId);

                // Kolon isimlendirmeleri ve özellikleri
                entity.Property(e => e.AssetId)
                    .HasColumnName("asset_id");

                entity.Property(e => e.AssetTypeId)
                    .HasColumnName("asset_type_id")
                    .HasMaxLength(10)
                    .IsRequired();

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("unit_price")
                    .HasPrecision(10, 2)
                    .IsRequired();

                entity.Property(e => e.PriceDate)
                    .HasColumnName("price_date")
                    .IsRequired();

                // Foreign Key ilişkisi
                entity.HasOne(e => e.AssetType)
                    .WithMany(a => a.FinancialAssets)
                    .HasForeignKey(e => e.AssetTypeId)
                    .HasConstraintName("FK_financial_assets_asset_types");
            });

            modelBuilder.Entity<AssetType>(entity =>
            {
                entity.ToTable("asset_types");

                entity.HasKey(e => e.AssetTypeId);

                entity.Property(e => e.AssetTypeId)
                    .HasColumnName("asset_type_id")
                    .HasMaxLength(10)
                    .IsRequired();

                entity.Property(e => e.AssetName)
                    .HasColumnName("asset_name")
                    .IsRequired();

            });

            base.OnModelCreating(modelBuilder);

        }
    }
}
