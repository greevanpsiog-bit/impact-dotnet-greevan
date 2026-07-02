using System;

namespace BridgeCourse.Week1;

// 1. Define the struct (Value Type)
// Best practice: Structs should be immutable (readonly properties)
public readonly struct ContactCard
{
    public string Name { get; }
    public string Phone { get; }
    public string Email { get; }

    public ContactCard(string name, string phone, string email)
    {
        Name = name;
        Phone = phone;
        Email = email;
    }

    // Override ToString for clean console output
    public override string ToString() => $"Name: {Name,-15} | Phone: {Phone} | Email: {Email}";
}

public class MiniQ3_ContactCard
{
    public static void Run()
    {
        // 2. Create an array of 5 ContactCards with intentionally mixed casing
        ContactCard[] contacts = new ContactCard[]
        {
            new ContactCard("Alice Smith", "555-0101", "alice@example.com"),
            new ContactCard("bOb jOnEs", "555-0102", "bob@example.com"),
            new ContactCard("CHARLIE BROWN", "555-0103", "charlie@example.com"),
            new ContactCard("dAvId WiLsOn", "555-0104", "david@example.com"),
            new ContactCard("Eve Davis", "555-0105", "eve@example.com")
        };

        // 3. The Search Query (all lowercase)
        string searchTerm = "bob"; 

        Console.WriteLine($"--- Searching for: '{searchTerm}' ---\n");

        bool found = false;

        // 4. Iterate and perform Case-Insensitive Search
        foreach (var contact in contacts)
        {
            // StringComparison.OrdinalIgnoreCase is the safest way to ignore case in C#
            if (contact.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"[MATCH FOUND] {contact}");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No contacts found matching the query.");
        }
    }
}