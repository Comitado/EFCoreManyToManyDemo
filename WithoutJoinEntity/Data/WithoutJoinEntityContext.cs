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
            optionsBuilder.UseSqlServer("Server=localhost;Database=EFDemoWithoutJoinEntity;Trusted_Connection=True;")
                .LogTo(Console.WriteLine);
        }

    }
}
