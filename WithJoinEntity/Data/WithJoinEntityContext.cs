using Microsoft.EntityFrameworkCore;
using System;
using WithJoinEntity.Models;

namespace WithJoinEntity.Data
{
    public class WithJoinEntityContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }

        public WithJoinEntityContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReaderBook>().HasKey(e => new { e.BookId, e.ReaderId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=EFDemoWithJoinEntity;Trusted_Connection=True;")
                .LogTo(Console.WriteLine);
        }

    }
}
