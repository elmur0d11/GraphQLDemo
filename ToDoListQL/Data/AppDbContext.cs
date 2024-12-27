using Microsoft.EntityFrameworkCore;
using ToDoListQL.Models;

namespace ToDoListQL.Data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<ItemData> Items { get; set; }

        public virtual DbSet<ItemList> Lists { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemData>(entity =>
            {
                entity.HasOne(d => d.ItemList)
                    .WithMany(p => p.ItemDatas)
                    .HasForeignKey(d => d.ListId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ItemData_ItemList");

            });
        }
    }
}
