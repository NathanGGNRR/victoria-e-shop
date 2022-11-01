//-----------------------------------------------------------------------
// <copyright file="VictoriaContext.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Infrastructure.Persistence
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The context of the database.
    /// </summary>
    public partial class VictoriaContext : DbContext, IVictoriaContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VictoriaContext" /> class.
        /// </summary>
        public VictoriaContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VictoriaContext" /> class.
        /// </summary>
        /// <param name="options">DatabaseContextOptions object.</param>
        public VictoriaContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the brands.
        /// </summary>
        public virtual DbSet<Vsbrand> Vsbrands { get; set; }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        public virtual DbSet<Vscategory> Vscategories { get; set; }

        /// <summary>
        /// Gets or sets the colors.
        /// </summary>
        public virtual DbSet<Vscolor> Vscolors { get; set; }

        /// <summary>
        /// Gets or sets the indices.
        /// </summary>
        public virtual DbSet<Vsindex> Vsindices { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public virtual DbSet<Vsproduct> Vsproducts { get; set; }

        /// <summary>
        /// Gets or sets the product's colors.
        /// </summary>
        public virtual DbSet<VsproductColor> VsproductColors { get; set; }

        /// <summary>
        /// Gets or sets the product's prices.
        /// </summary>
        public virtual DbSet<VsproductPrice> VsproductPrices { get; set; }

        /// <summary>
        /// Gets or sets the product's reviews.
        /// </summary>
        public virtual DbSet<VsproductReview> VsproductReviews { get; set; }

        /// <summary>
        /// Gets or sets the product's search indices.
        /// </summary>
        public virtual DbSet<VsproductSearchIndex> VsproductSearchIndices { get; set; }

        /// <summary>
        /// Gets or sets the product's sizes.
        /// </summary>
        public virtual DbSet<VsproductSize> VsproductSizes { get; set; }

        /// <summary>
        /// Gets or sets the retailers.
        /// </summary>
        public virtual DbSet<Vsretailer> Vsretailers { get; set; }

        /// <summary>
        /// Gets or sets the sizes.
        /// </summary>
        public virtual DbSet<Vssize> Vssizes { get; set; }

        /// <summary>
        /// Method to save the changes made in the database.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A integer.</returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Method to create the entities
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder object.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Vsbrand>(entity =>
            {
                entity.ToTable("VSBrand");

                entity.Property(e => e.BrandName).HasMaxLength(50);
            });

            modelBuilder.Entity<Vscategory>(entity =>
            {
                entity.ToTable("VSCategory");

                entity.Property(e => e.CategoryName).HasMaxLength(150);
            });

            modelBuilder.Entity<Vscolor>(entity =>
            {
                entity.ToTable("VSColor");

                entity.Property(e => e.ColorCode)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.ColorName).HasMaxLength(110);
            });

            modelBuilder.Entity<Vsindex>(entity =>
            {
                entity.HasKey(e => e.FakeId);

                entity.ToTable("VSIndex");

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.CategoryName).HasMaxLength(150);

                entity.Property(e => e.ColorName).HasMaxLength(110);

                entity.Property(e => e.Description).HasMaxLength(2500);

                entity.Property(e => e.ImageUrl).HasMaxLength(400);

                entity.Property(e => e.ProductName).HasMaxLength(500);

                entity.Property(e => e.SizeName).HasMaxLength(20);
            });

            modelBuilder.Entity<Vsproduct>(entity =>
            {
                entity.ToTable("VSProduct");

                entity.Property(e => e.Description).HasMaxLength(2500);

                entity.Property(e => e.ImageUrl).HasMaxLength(350);

                entity.Property(e => e.ProductName).HasMaxLength(150);

                entity.Property(e => e.ProductUrl).HasMaxLength(350);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Vsproducts)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_VSProduct_VSBrand");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Vsproducts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_VSProduct_VSCategory");
            });

            modelBuilder.Entity<VsproductColor>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.ColorId });

                entity.ToTable("VSProductColor");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.VsproductColors)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FK_VSProductColor_VSColor");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.VsproductColors)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VSProductColor_VSProduct");
            });

            modelBuilder.Entity<VsproductPrice>(entity =>
            {
                entity.ToTable("VSProductPrice");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.VsproductPrices)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK_VSProductPriceAndReview_VSColor");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.VsproductPrices)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_VSProductPriceAndReview_VSProduct");

                entity.HasOne(d => d.Retailer)
                    .WithMany(p => p.VsproductPrices)
                    .HasForeignKey(d => d.RetailerId)
                    .HasConstraintName("FK_VSProductPriceAndReview_VSRetailer");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.VsproductPrices)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK_VSProductPriceAndReview_VSSize");
            });

            modelBuilder.Entity<VsproductReview>(entity =>
            {
                entity.ToTable("VSProductReview");

                entity.Property(e => e.Rating).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.VsproductReviews)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK_VSProductReview_VSColor");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.VsproductReviews)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_VSProductReview_VSProduct");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.VsproductReviews)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK_VSProductReview_VSSize");
            });

            modelBuilder.Entity<VsproductSearchIndex>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VSProductSearchIndex");

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.CategoryName).HasMaxLength(150);

                entity.Property(e => e.ColorName).HasMaxLength(110);

                entity.Property(e => e.Description).HasMaxLength(2500);

                entity.Property(e => e.ImageUrl).HasMaxLength(381);

                entity.Property(e => e.ProductName).HasMaxLength(282);

                entity.Property(e => e.SizeName).HasMaxLength(20);
            });

            modelBuilder.Entity<VsproductSize>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.SizeId });

                entity.ToTable("VSProductSize");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.VsproductSizes)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VSProductSize_VSProduct");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.VsproductSizes)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VSProductSize_VSSize");
            });

            modelBuilder.Entity<Vsretailer>(entity =>
            {
                entity.ToTable("VSRetailer");

                entity.Property(e => e.RetailerName).HasMaxLength(50);
            });

            modelBuilder.Entity<Vssize>(entity =>
            {
                entity.ToTable("VSSize");

                entity.Property(e => e.SizeName).HasMaxLength(20);
            });
        }
    }
}