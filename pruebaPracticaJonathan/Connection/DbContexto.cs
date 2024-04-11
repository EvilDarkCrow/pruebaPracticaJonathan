using Microsoft.EntityFrameworkCore;
using pruebaPracticaJonathan.Models;

namespace pruebaPracticaJonathan.Connection
{
    public class DbContexto:DbContext
    {
        

        public DbContexto(DbContextOptions<DbContexto> options) : base(options)
        {

        }

        public DbSet<Member> members { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Product> products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.member)
                .WithMany()
                .HasForeignKey(o => o.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.product)
                .WithMany()
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
