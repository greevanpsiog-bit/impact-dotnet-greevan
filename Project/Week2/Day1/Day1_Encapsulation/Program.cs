// Example test code to verify Task 2.1
var account = new BankAccount(1000);
account.Deposit(500);
account.Withdraw(200);

try
{
    account.Withdraw(5000); // This should fail
}
catch (Exception ex)
{
    Console.WriteLine($"Caught Error: {ex.Message}");
}

account.PrintHistory();