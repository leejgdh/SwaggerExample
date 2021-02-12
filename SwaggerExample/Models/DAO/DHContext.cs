using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SwaggerExample.Models.Enums;

namespace SwaggerExample.Models.DAO
{

    public class DHContext : DbContext
    {

        public DHContext(DbContextOptions<DHContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Todo>()
                .Property(e => e.Status)
                .HasConversion(new EnumToStringConverter<ETodoStatus>())
                .HasMaxLength(20);
        }
    }
}