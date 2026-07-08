using System;
using System.Collections.Generic;
using System.Linq;

namespace Week2.Day4
{
    // GENERICS
    // ---------
    // Without generics you'd need a StudentRepository AND a ProductRepository
    // with almost identical code, just the type name swapped. Generics let
    // you write the logic ONCE and plug in the type later, at compile time.
    // T is a placeholder — "I don't know the type yet, but I promise to use
    // it consistently everywhere in this class."
    public class Repository<T> where T : class, new()
    {
        private readonly List<T> items = new();

        public void Add(T item) => items.Add(item);

        // Update takes a predicate to find the item, and an action to modify it.
        // (Simple approach for a learning exercise — real repos usually key by Id.)
        public bool Update(Func<T, bool> match, Action<T> updateAction)
        {
            T? found = items.FirstOrDefault(match);
            if (found is null) return false;
            updateAction(found);
            return true;
        }

        public bool Delete(Func<T, bool> match)
        {
            T? found = items.FirstOrDefault(match);
            if (found is null) return false;
            return items.Remove(found);
        }

        public List<T> GetAll() => new List<T>(items);
    }

    /*
     * ===================================================================
     *  EXPLAINING: where T : class, new()
     * ===================================================================
     * This is a GENERIC CONSTRAINT — it restricts what T is allowed to be.
     *
     *   "class"  -> T must be a reference type (a class), not a struct/int/
     *               bool/etc. This matters because our GetAll() etc. rely on
     *               reference semantics (null checks like "found is null"
     *               only make sense for reference types).
     *
     *   "new()"  -> T must have a public parameterless constructor, i.e. you
     *               must be able to write "new T()". This is required if the
     *               Repository ever needs to CREATE a blank instance of T
     *               itself (for example, a future CreateEmpty() method).
     *               It also acts as documentation: "whatever you plug into
     *               this repo must be a normal instantiable class."
     *
     * Without this constraint, T could be ANYTHING (int, an interface with
     * no constructor, a struct...), and the compiler wouldn't let us safely
     * assume things like "T is a reference type" or "T can be newed up."
     * Constraints are how generics stay both flexible AND type-safe.
     */

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;

        public override string ToString() => $"Student #{Id}: {Name} ({Course})";
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public override string ToString() => $"Product #{Id}: {Name} - {Price:C}";
    }

    public class Task2_11_Demo
    {
        public static void Run()
        {
            Console.WriteLine("---- Task 2.11: Generic Repository<T> ----");

            // Same Repository<T> class, two completely different types plugged in.
            Repository<Student> studentRepo = new Repository<Student>();
            studentRepo.Add(new Student { Id = 1, Name = "Arun", Course = "C#" });
            studentRepo.Add(new Student { Id = 2, Name = "Meena", Course = "SQL" });

            Repository<Product> productRepo = new Repository<Product>();
            productRepo.Add(new Product { Id = 1, Name = "Keyboard", Price = 1200 });
            productRepo.Add(new Product { Id = 2, Name = "Mouse", Price = 500 });

            Console.WriteLine("Students before update:");
            studentRepo.GetAll().ForEach(s => Console.WriteLine($"  {s}"));

            studentRepo.Update(s => s.Id == 2, s => s.Course = "Advanced SQL");
            Console.WriteLine("Students after update:");
            studentRepo.GetAll().ForEach(s => Console.WriteLine($"  {s}"));

            productRepo.Delete(p => p.Id == 1);
            Console.WriteLine("Products after delete:");
            productRepo.GetAll().ForEach(p => Console.WriteLine($"  {p}"));

            Console.WriteLine();
        }
    }
}