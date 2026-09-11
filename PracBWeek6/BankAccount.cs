public class BankAccount(string owner, decimal balance)
{
  public string Owner { get; set; } = owner;
  public decimal Balance { get; set; } = balance;

  public decimal Deposit(decimal amount)
  {
    if (amount < 0)
    {
      throw new ArgumentException("Amount must not be negative.");
    }
    return Balance += amount;
  }

  public decimal Deposit(int amount)
  {
    return Deposit((decimal)amount);
  }

  public decimal Deposit(double amount)
  {
    return Deposit((decimal)amount);
  }

  public virtual decimal Withdraw(decimal amount)
  {
    if (amount < 0)
    {
      throw new ArgumentException("Amount must not be negative.");
    }
    if (Balance < amount)
    {
      throw new ArgumentException("Balance is less than amount");
    }
    return Balance -= amount;
  }

  public override string ToString()
  {
    string info = $"""
      Account: {nameof(BankAccount)}
      Owner: {Owner}
      Balance: {Balance:F2}
      """;
    return info;
  }
}