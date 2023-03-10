using Microsoft.EntityFrameworkCore;

namespace POS_Accessories.Models;

public partial class AccessoriesDbContext : DbContext
{
    public AccessoriesDbContext()
    {
    }

    public AccessoriesDbContext(DbContextOptions<AccessoriesDbContext> options)
        : base(options)
    {
    }

    

    public virtual DbSet<User> user { get; set; }
    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Colour> Colours { get; set; }

    public virtual DbSet<Configuration> Configurations { get; set; }

    public virtual DbSet<Coupon> Coupons { get; set; }

    public virtual DbSet<CouponMap> CouponMaps { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetailsMap> OrderDetailsMaps { get; set; }

    public virtual DbSet<OrderHistoryMap> OrderHistoryMaps { get; set; }

    public virtual DbSet<OrderPaymentMap> OrderPaymentMaps { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductBundleMap> ProductBundleMaps { get; set; }

    public virtual DbSet<ProductColourMap> ProductColourMaps { get; set; }

    public virtual DbSet<ProductImageMap> ProductImageMaps { get; set; }

    public virtual DbSet<ProductPriceMap> ProductPriceMaps { get; set; }

    public virtual DbSet<ProductSizeMap> ProductSizeMaps { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }
    public virtual DbSet<ConfigurationType> ConfigurationType { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<StockAllocation> StockAllocations { get; set; }

    public virtual DbSet<StockAllocationHistory> StockAllocationHistories { get; set; }

    public virtual DbSet<StockInventory> StockInventories { get; set; }

    public virtual DbSet<SubCategory> SubCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=122.175.6.200,1486;Database=AccessoriesDB;User ID=sa;Password=angel#123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>();
        modelBuilder.Entity<ConfigurationType>();

        modelBuilder.Entity<Configuration>(entity =>
        {
            entity.HasKey(e => e.ConfigId);

            entity.ToTable("Configuration");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FromDate).HasColumnType("date");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ToDate).HasColumnType("date");
        });


        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Image)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Colour>(entity =>
        {
            entity.ToTable("Colour");

            entity.Property(e => e.ColourCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ColourName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        

        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.ToTable("Coupon");

            entity.Property(e => e.CouponCode)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CouponType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ValidFrom).HasColumnType("date");
            entity.Property(e => e.ValidTo).HasColumnType("date");
        });

        modelBuilder.Entity<CouponMap>(entity =>
        {
            entity.ToTable("CouponMap");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.CouponCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeliveryCharges).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ItemTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ShippingAddress).IsUnicode(false);
            entity.Property(e => e.ShippingMode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TotalWithVATAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalWithOutVATAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrackNumber).HasMaxLength(30);
            entity.Property(e => e.VatAmount).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<OrderDetailsMap>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK_OrderDetails");

            entity.ToTable("OrderDetailsMap");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.SalePrice).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<OrderHistoryMap>(entity =>
        {
            entity.HasKey(e => e.OrderHistoryId).HasName("PK_OrderHistory");

            entity.ToTable("OrderHistoryMap");

            entity.Property(e => e.Comments).IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OrderPaymentMap>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OrderPaymentMap");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Specification).IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProductBundleMap>(entity =>
        {
            entity.HasKey(e => e.ProductBundleId).HasName("PK_Table_1");

            entity.ToTable("ProductBundleMap");

            entity.Property(e => e.ProductBundleId).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FromDate).HasColumnType("date");
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.SalePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ToDate).HasColumnType("date");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductBundleMaps)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Table_1_Product");
        });

        modelBuilder.Entity<ProductColourMap>(entity =>
        {
            entity.HasKey(e => e.ProductColourId).HasName("PK_ProductColour");

            entity.ToTable("ProductColourMap");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Colour).WithMany(p => p.ProductColourMaps)
                .HasForeignKey(d => d.ColourId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductColourMap_Colour");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductColourMaps)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductColour_Product");
        });

        modelBuilder.Entity<ProductImageMap>(entity =>
        {
            entity.HasKey(e => e.ProductImageId).HasName("PK_ProductImage");

            entity.ToTable("ProductImageMap");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ImageName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ImagePath)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ImageType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImageMaps)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductImage_Product");
        });

        modelBuilder.Entity<ProductPriceMap>(entity =>
        {
            entity.HasKey(e => e.ProductPriceMapId).HasName("PK_ProductPrice");

            entity.ToTable("ProductPriceMap");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.SalePrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductPriceMaps)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductPrice_Product");
        });

        modelBuilder.Entity<ProductSizeMap>(entity =>
        {
            entity.HasKey(e => e.ProductSizeId).HasName("PK_ProductSize");

            entity.ToTable("ProductSizeMap");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductSizeMaps)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductSize_Product");

            entity.HasOne(d => d.Size).WithMany(p => p.ProductSizeMaps)
                .HasForeignKey(d => d.SizeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductSizeMap_Size");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.ToTable("Size");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK_Stock");

            entity.ToTable("Stock");

            entity.Property(e => e.ProductId).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.StockId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<StockAllocation>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK_StockAllocationHistory");

            entity.ToTable("StockAllocation");

            entity.Property(e => e.ProductId).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Doa)
                .HasColumnType("date")
                .HasColumnName("DOA");
            entity.Property(e => e.StockAllocatationId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<StockAllocationHistory>(entity =>
        {
            entity.HasKey(e => e.StockAllocationHistoryId).HasName("PK_StockAllocationHistory1");

            entity.ToTable("StockAllocationHistory");

            entity.Property(e => e.AllocationType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("date");
            entity.Property(e => e.Doa)
                .HasColumnType("date")
                .HasColumnName("DOA");
        });

        modelBuilder.Entity<StockInventory>(entity =>
        {
            entity.HasKey(e => e.StockInventoryId).HasName("PK_StockInventory");
            entity.ToTable("StockInventory");

            entity.Property(e => e.BuyPrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.StockInventoryId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SubCategory>(entity =>
        {
            entity.ToTable("SubCategory");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Image)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SubCategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);

            
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
