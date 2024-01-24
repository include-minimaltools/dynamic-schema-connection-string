using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace WinFormApp.Models
{
    public partial class MinimalDbContext
        : DbContext, IDbModelCacheKeyProvider
    {
        private readonly string _schema;

        string IDbModelCacheKeyProvider.CacheKey
        {
            get => _schema;
        }

        public MinimalDbContext(string connectionString, string schema)
            : base(connectionString) => _schema = schema;

        public virtual DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(_schema);

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 4);
        }
    }
}
