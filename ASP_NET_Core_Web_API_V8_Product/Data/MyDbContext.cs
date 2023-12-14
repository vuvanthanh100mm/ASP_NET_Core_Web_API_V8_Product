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
        #endregion
    }
}
