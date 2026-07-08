using System;
using System.Collections.Generic;

public class BankAccount
{
    // 1. CONST: Fixed, unchangeable error messages known at compile-time
    private const string NegativeInitialBalanceMsg = "Initial balance cannot be negative.";
    private const string NonPositiveAmountMsg = "Amount must be positive.";
    private const string InsufficientFundsMsg = "Overdraw not allowed.";

    // 2. READONLY: The list pointer is locked. It can never be overwritten or set to null.
    private readonly List<string> _history = new List<string>();

    private decimal _balance;

    // 3. INIT: Captured at creation and locked down forever as a historical record.
    public decimal CreatedWithBalance { get; init; }

    public BankAccount(decimal initialBalance = 0)
    {
        if (initialBalance < 0)
            throw new ArgumentException(NegativeInitialBalanceMsg);

        _balance = initialBalance;
        CreatedWithBalance = initialBalance; // Set during initialization

        _history.Add($"Account created. Initial Balance: {_balance:C}");
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException(NonPositiveAmountMsg);

        _balance += amount;
        _history.Add($"Deposited: {amount:C}. New Balance: {_balance:C}");
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException(NonPositiveAmountMsg);

        if (amount > _balance)
        {
            _history.Add($"FAILED Withdrawal of {amount:C}. Insufficient funds. Balance: {_balance:C}");
            throw new InvalidOperationException(InsufficientFundsMsg);
        }

        _balance -= amount;
        _history.Add($"Withdrew: {amount:C}. New Balance: {_balance:C}");
    }

    public decimal GetBalance() => _balance;

    public void PrintHistory()
    {
        Console.WriteLine($"\n--- Account History (Opened with: {CreatedWithBalance:C}) ---");
        foreach (var entry in _history)
        {
            Console.WriteLine(entry);
        }
        Console.WriteLine("-------------------------------------------------------\n");
    }
}