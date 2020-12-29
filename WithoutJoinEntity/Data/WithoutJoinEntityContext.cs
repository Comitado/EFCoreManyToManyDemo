using Microsoft.EntityFrameworkCore;
using System;
using WithoutJoinEntity.Models;

namespace WithoutJoinEntity.Data
{
    public class WithoutJoinEntityContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }

        public WithoutJoinEntityContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            optionsBuilder.UseSqlite($"Data Source={userPath}/ManyToManyWithoutJoinEntity.db;");
        }

    }
}
