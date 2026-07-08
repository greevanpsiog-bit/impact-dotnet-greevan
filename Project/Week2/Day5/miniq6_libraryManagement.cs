using System;
using System.Collections.Generic;
using System.Linq;

namespace Week2.Day5.Library
{
    public class Book
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int Year { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class Task_MiniQ6_Demo
    {
        public static List<Book> BuildSampleBooks()
        {
            return new List<Book>
            {
                new() { Title = "The Silent Patient", Author = "Alex Michaelides", Genre = "Thriller", Year = 2019, IsAvailable = true },
                new() { Title = "Atomic Habits", Author = "James Clear", Genre = "Self-Help", Year = 2018, IsAvailable = true },
                new() { Title = "Dune", Author = "Frank Herbert", Genre = "Sci-Fi", Year = 1965, IsAvailable = false },
                new() { Title = "Project Hail Mary", Author = "Andy Weir", Genre = "Sci-Fi", Year = 2021, IsAvailable = true },
                new() { Title = "The Hobbit", Author = "J.R.R. Tolkien", Genre = "Fantasy", Year = 1937, IsAvailable = true },
                new() { Title = "1984", Author = "George Orwell", Genre = "Dystopian", Year = 1949, IsAvailable = false },
                new() { Title = "Sapiens", Author = "Yuval Noah Harari", Genre = "Non-Fiction", Year = 2011, IsAvailable = true },
                new() { Title = "The Martian", Author = "Andy Weir", Genre = "Sci-Fi", Year = 2011, IsAvailable = true },
                new() { Title = "Educated", Author = "Tara Westover", Genre = "Memoir", Year = 2018, IsAvailable = false },
                new() { Title = "Brave New World", Author = "Aldous Huxley", Genre = "Dystopian", Year = 1932, IsAvailable = true },
                new() { Title = "The Alchemist", Author = "Paulo Coelho", Genre = "Fiction", Year = 1988, IsAvailable = true },
                new() { Title = "Gone Girl", Author = "Gillian Flynn", Genre = "Thriller", Year = 2012, IsAvailable = false },
                new() { Title = "Circe", Author = "Madeline Miller", Genre = "Fantasy", Year = 2018, IsAvailable = true },
                new() { Title = "The Lord of the Rings", Author = "J.R.R. Tolkien", Genre = "Fantasy", Year = 1954, IsAvailable = true },
                new() { Title = "Thinking, Fast and Slow", Author = "Daniel Kahneman", Genre = "Non-Fiction", Year = 2011, IsAvailable = true },
                new() { Title = "The Silmarillion", Author = "J.R.R. Tolkien", Genre = "Fantasy", Year = 1977, IsAvailable = false },
            };
        }

        public static void Run()
        {
            Console.WriteLine("---- Mini Q6: Library Management (LINQ) ----");
            List<Book> books = BuildSampleBooks();

            // Query 1: available books grouped by author (only authors with
            // at least one available book, showing their available titles)
            var availableByAuthor = books
                .Where(b => b.IsAvailable)
                .GroupBy(b => b.Author)
                .Select(g => new { Author = g.Key, Titles = g.Select(b => b.Title).ToList() });

            Console.WriteLine("\nQuery 1 - Available books by author:");
            foreach (var group in availableByAuthor)
                Console.WriteLine($"  {group.Author}: {string.Join(", ", group.Titles)}");

            // Query 2: group by genre with count
            var byGenre = books
                .GroupBy(b => b.Genre)
                .Select(g => new { Genre = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count);

            Console.WriteLine("\nQuery 2 - Count by genre:");
            foreach (var g in byGenre)
                Console.WriteLine($"  {g.Genre}: {g.Count}");

            // Query 3: oldest book
            Book oldest = books.OrderBy(b => b.Year).First();
            Console.WriteLine($"\nQuery 3 - Oldest book: {oldest.Title} ({oldest.Year}) by {oldest.Author}");

            // Query 4: books after 2010, sorted by title
            var recentBooks = books
                .Where(b => b.Year > 2010)
                .OrderBy(b => b.Title);

            Console.WriteLine("\nQuery 4 - Books after 2010, sorted by title:");
            foreach (Book b in recentBooks)
                Console.WriteLine($"  {b.Title} ({b.Year})");

            Console.WriteLine();
        }
    }
}