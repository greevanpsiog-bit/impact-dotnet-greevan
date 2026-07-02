using System;
using System.Collections.Generic;
using System.Linq;

namespace BridgeCourse.Week1;

// 1. Define the Category Enum
public enum Category
{
    Electronics,
    Groceries,
    Clothing,
    Books
}

// 2. Define the Product Record (Positional record for concise syntax & built-in equality)
public record Product(string Name, decimal Price, Category Category);

public class MiniQ1_ProductCatalog
{
    public static void Run()
    {
        // 3. Create 5 Product objects
        var products = new List<Product>
        {
            new("Wireless Mouse", 25.50m, Category.Electronics),
            new("Organic Apples", 3.99m, Category.Groceries),
            new("Denim Jeans", 49.99m, Category.Clothing),
            new("Mechanical Keyboard", 89.00m, Category.Electronics),
            new("Whole Wheat Bread", 2.50m, Category.Groceries)
        };

        // 4. Group by Category using LINQ, and order alphabetically by Category name
        var groupedProducts = products
            .GroupBy(p => p.Category)
            .OrderBy(g => g.Key);

        // 5. Print the grouped output
        Console.WriteLine("=== Product Catalog (Grouped by Category) ===\n");

        foreach (var group in groupedProducts)
        {
            Console.WriteLine($"[{group.Key}]");
            
            foreach (var product in group)
            {
                // Formatted string alignment for clean console output
                Console.WriteLine($"  - {product.Name,-25} ${product.Price,8:F2}");
            }
            Console.WriteLine();
        }
    }
}