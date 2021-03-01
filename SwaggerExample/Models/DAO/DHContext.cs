using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using DHDashBoardSDK.Models.Enums;

namespace SwaggerExample.Models.DAO
{

    public class DHContext : DbContext
    {

        public DHContext(DbContextOptions<DHContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ShoppingHistory> ShoppingHistories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Todo>()
                .Property(e => e.Status)
                .HasConversion(new EnumToStringConverter<ETodoStatus>())
                .HasMaxLength(20);


            modelBuilder.Entity<ShoppingHistory>()
            .HasOne(e => e.Shop)
            .WithMany(e => e.ShopHistories)
            .HasForeignKey(e => e.ShopId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ShoppingHistory>()
            .HasOne(e => e.Product)
            .WithMany(e => e.ShopHistories)
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        }
    }
}