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
            var userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            optionsBuilder.UseSqlite($"Data Source={userPath}/ManyToManyWithJoinEntity.db;");
        }

    }
}
