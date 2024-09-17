using Microsoft.EntityFrameworkCore;
using ToDoList.DataAccess.Models;

namespace ToDoList.DataAccess
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Note>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(75);
            base.OnModelCreating(modelBuilder);
        }
    }
}
