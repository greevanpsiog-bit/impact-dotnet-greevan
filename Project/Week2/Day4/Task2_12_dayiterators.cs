using System;
using System.Collections;
using System.Collections.Generic;

namespace Week2.Day4
{
    public class Book
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;

        public override string ToString() => $"{Title} by {Author}";
    }

    // yield return
    // -------------
    // Normally, a method that returns a list has to build the WHOLE list
    // in memory before returning it. "yield return" instead turns the
    // method into a lazy generator: each value is produced ONE AT A TIME,
    // only when the caller actually asks for the next one (e.g. each loop
    // of a foreach). Nothing runs ahead of what's actually consumed.
    public static class NumberGenerator
    {
        public static IEnumerable<int> GetEvenNumbers(int max)
        {
            Console.WriteLine("  [GetEvenNumbers] method started");
            for (int i = 0; i <= max; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine($"  [GetEvenNumbers] about to yield {i}");
                    yield return i; // pauses here until the caller asks for the next value
                }
            }
            Console.WriteLine("  [GetEvenNumbers] method finished");
        }
    }

    // A custom collection that implements IEnumerable<Book>, so it can be
    // used directly in a foreach loop, just like a List<Book> can.
    public class BookCollection : IEnumerable<Book>
    {
        private readonly List<Book> books = new();

        public void Add(Book book) => books.Add(book);

        // Yields books alphabetically by title, one at a time, lazily.
        public IEnumerator<Book> GetEnumerator()
        {
            List<Book> sorted = new List<Book>(books);
            sorted.Sort((a, b) => string.Compare(a.Title, b.Title, StringComparison.Ordinal));

            foreach (Book book in sorted)
                yield return book;
        }

        // Required by the non-generic IEnumerable interface; just delegates
        // to the generic version above.
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class Task2_12_Demo
    {
        public static void Run()
        {
            Console.WriteLine("---- Task 2.12: yield return / Lazy Iteration ----");

            Console.WriteLine("Calling GetEvenNumbers(6)... (notice nothing prints yet)");
            IEnumerable<int> evens = NumberGenerator.GetEvenNumbers(6);
            Console.WriteLine("Now starting the foreach:");

            foreach (int n in evens)
            {
                Console.WriteLine($"  Consumed: {n}");
                // Each loop iteration pulls exactly ONE value from GetEvenNumbers.
                // You'll see the "[GetEvenNumbers] about to yield" lines interleave
                // with "Consumed" lines — proof the method is lazy, not eager.
            }

            Console.WriteLine();

            BookCollection library = new BookCollection();
            library.Add(new Book { Title = "Zebra Tales", Author = "A. Author" });
            library.Add(new Book { Title = "Apple Stories", Author = "B. Writer" });
            library.Add(new Book { Title = "Mango Chronicles", Author = "C. Novelist" });

            Console.WriteLine("Books in alphabetical order:");
            foreach (Book book in library) // works because BookCollection implements IEnumerable<Book>
                Console.WriteLine($"  {book}");

            Console.WriteLine();
        }
    }
}