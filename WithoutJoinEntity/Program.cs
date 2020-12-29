using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WithoutJoinEntity.Data;
using WithoutJoinEntity.Models;

namespace WithoutJoinEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            PupulateDatabase();
            PrintBooksFromReaders();
        }

        static void PrintBooksFromReaders()
        {
            using var context = new WithoutJoinEntityContext();

            var readers = context.Readers.Include(n => n.Books);

            foreach (var reader in readers)
            {
                Console.WriteLine($"Books read by {reader.Name}:");
                foreach (var book in reader.Books)
                {
                    Console.WriteLine($"\t{book.Title}");
                }
            }
        }

        static void PupulateDatabase()
        {
            using var context = new WithoutJoinEntityContext();

            if (!context.Readers.Any())
            {
                var cleanCode = new Book() { Title = "Clean Code" };
                context.Books.Add(cleanCode);
                var ddd = new Book() { Title = "Domain Driven Design" };
                context.Books.Add(ddd);

                var alexandre = new Reader() { Name = "Alexandre", Books = new List<Book>() { cleanCode, ddd} };
                context.Readers.Add(alexandre);

                var michelle = new Reader() { Name = "Michelle", Books = new List<Book>() { cleanCode} };
                context.Readers.Add(michelle);

                context.SaveChanges();
            }
        }
    }
}
