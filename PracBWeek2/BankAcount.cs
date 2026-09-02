using System;

public class BankAccount
{
    public string Owner {get; set; }
    public decimal Balance {get; set; }
    public BankAccount(string owner, decimal balance)
    {
        Owner = owner;
        Balance = balance;
    }

    public void Deposit(decimal amount)
    {
        try
        {
            if(amount < 0)
            {
                throw new InvalidOperationException("The amount must be a positive number.");
            }

            Balance = Balance + amount;

        }

        catch(InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        } 
    }

    public void Deposit(int amount)
    {
        try
        {
            if(amount < 0)
            {
                throw new InvalidOperationException("The amount must be a positive number.");
            }

            Balance = Balance + amount;

        }

        catch(InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        } 
    }


    public void Deposit(double amount)
    {
        try
        {
            if((decimal)amount < 0)
            {
                throw new InvalidOperationException("The amount must be a positive number.");
            }

            Balance = Balance + (decimal)amount;

        }

        catch(InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        } 
    }
    public void Withdraw(decimal amount)
    {
            if (amount > Balance)
            {
                throw new ArgumentException("Your balance is too low.");  
            }

            Balance = Balance - amount; 
    }
}