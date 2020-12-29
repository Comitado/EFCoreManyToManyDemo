using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WithJoinEntity.Data;
using WithJoinEntity.Models;

namespace WithJoinEntity
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
            using var context = new WithJoinEntityContext();

            var readers = context.Readers.Include( n => n.ReaderBooks ).ThenInclude( n => n.Book ).ToList();

            foreach (var reader in readers)
            {
                Console.WriteLine($"Books read by {reader.Name}:");
                foreach (var readerBooks in reader.ReaderBooks)
                {
                    Console.WriteLine($"\t{readerBooks.Book.Title}");
                }
            }
        }

        static void PupulateDatabase()
        {
            using var context = new WithJoinEntityContext();

            if (!context.Set<ReaderBook>().Any())
            {
                var cleanCode = new Book() { Title = "Clean Code" };
                context.Books.Add(cleanCode);
                var ddd = new Book() { Title = "Domain Driven Design" };
                context.Books.Add(ddd);

                var alexandre = new Reader() { Name = "Alexandre" };
                context.Readers.Add(alexandre);

                var michelle = new Reader() { Name = "Michelle" };
                context.Readers.Add(michelle);

                context.Set<ReaderBook>().Add(new ReaderBook() { Reader = alexandre, Book = cleanCode });
                context.Set<ReaderBook>().Add(new ReaderBook() { Reader = alexandre, Book = ddd });

                context.Set<ReaderBook>().Add(new ReaderBook() { Reader = michelle, Book = cleanCode });
                context.SaveChanges();
            }
        }
    }
}
