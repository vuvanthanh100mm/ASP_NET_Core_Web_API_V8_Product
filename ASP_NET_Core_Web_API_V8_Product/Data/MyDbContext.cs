using Microsoft.EntityFrameworkCore;

namespace ASP_NET_Core_Web_API_V8_Product.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { 
        }

        #region
        public DbSet<HangHoa> hangHoas { get; set; }
        public DbSet<Loai> loais { get; set; }
        public DbSet<DonHang> donHangs { get; set; }
        public DbSet<DonHangChiTiet> donHangChiTiets { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDH);
                e.Property(dh => dh.NgatDat).HasDefaultValueSql("getutcdate()");
                e.Property(dh => dh.NguoiNhan).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<DonHangChiTiet>(entity =>
            {
                entity.ToTable("ChiTietDonHang");
                entity.HasKey(e => new { e.MaDH, e.MaHH });

                entity.HasOne(e => e.DonHang)
                .WithMany(e => e.DonHangChiTiets)
                .HasForeignKey(e => e.MaDH)
                .HasConstraintName("FK_DonHangCT_DonHang");

                entity.HasOne(e => e.HangHoa)
               .WithMany(e => e.DonHangChiTiets)
               .HasForeignKey(e => e.MaDH)
               .HasConstraintName("FK_DonHangCT_HangHoa");
            });
        }
    }
}
