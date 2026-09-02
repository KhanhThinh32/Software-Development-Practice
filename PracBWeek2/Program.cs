using System;

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount("Nguyen", 1000m);
        Console.WriteLine("Owner: " + account.Owner);
        Console.WriteLine("Balance: " + account.Balance);

        account.Deposit(50.785);
        Console.WriteLine($"After deposit 50.785 --> Balance: {account.Balance}");

        account.Deposit(100.20m);
         Console.WriteLine($"After deposit 100.20 --> Balance: {account.Balance}");
        
        account.Deposit(200);
        Console.WriteLine($"After deposit 200 --> Balance: {account.Balance}");


        try
        {
            account.Withdraw(10000m);
            Console.WriteLine(account.Balance);
        }

        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}