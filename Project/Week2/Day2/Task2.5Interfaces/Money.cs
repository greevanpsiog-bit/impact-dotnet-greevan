using System;

namespace Week2.Day2
{
    // OPERATOR OVERLOADING
    // ---------------------
    // Normally + == > < only work on built-in types like int and double.
    // Overloading lets YOUR class define what those symbols mean for it.
    // Under the hood it's just a specially-named static method.
    public class Money
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        // Defines what "moneyA + moneyB" means.
        public static Money operator +(Money a, Money b)
        {
            if (a.Currency != b.Currency)
                throw new InvalidOperationException(
                    $"Cannot add {a.Currency} and {b.Currency} — currencies must match.");

            return new Money(a.Amount + b.Amount, a.Currency);
        }

        public static bool operator ==(Money a, Money b)
        {
            if (ReferenceEquals(a, b)) return true;   // same object, or both null
            if (a is null || b is null) return false; // one is null, other isn't
            return a.Amount == b.Amount && a.Currency == b.Currency;
        }

        // Whenever you overload ==, C# requires you to also overload !=
        public static bool operator !=(Money a, Money b) => !(a == b);

        public static bool operator >(Money a, Money b)
        {
            if (a.Currency != b.Currency)
                throw new InvalidOperationException("Cannot compare Money with different currencies.");
            return a.Amount > b.Amount;
        }

        public static bool operator <(Money a, Money b)
        {
            if (a.Currency != b.Currency)
                throw new InvalidOperationException("Cannot compare Money with different currencies.");
            return a.Amount < b.Amount;
        }

        // Good practice: if you overload ==, also override Equals/GetHashCode.
        // The compiler will warn CS0660/CS0661 if you skip this.
        public override bool Equals(object obj) => obj is Money other && this == other;

        public override int GetHashCode() => HashCode.Combine(Amount, Currency);

        public override string ToString() => $"{Amount} {Currency}";
    }

    public class Task2_7_Demo
    {
        public static void Run()
        {
            Console.WriteLine("---- Task 2.7: Money Operator Overloading ----");

            Money m1 = new Money(100, "USD");
            Money m2 = new Money(50, "USD");
            Money m3 = new Money(30, "EUR");

            Money total = m1 + m2;
            Console.WriteLine($"Total: {total}"); // 150 USD

            Console.WriteLine(m1 == new Money(100, "USD")); // True
            Console.WriteLine(m1 != m2);                    // True
            Console.WriteLine(m1 > m2);                     // True
            Console.WriteLine(m2 < m1);                     // True

            try
            {
                Money mismatch = m1 + m3; // different currencies -> throws
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine();
        }
    }
}