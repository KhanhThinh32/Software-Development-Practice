using System.ComponentModel;
using System.Reflection;
using Xunit;

public class BankAccountTests
{
    [Fact]
    public void DecimalDepositTest()
    {
        BankAccount account = new BankAccount("Nguyen", 1000m);
        account.Deposit(100m);
        Assert.Equal(1100m, account.Balance);
    }

    [Fact]
    public void IntDepositTest()
    {
        BankAccount account = new BankAccount("Nguyen", 1000m);
        account.Deposit(200);
        Assert.Equal(1200m, account.Balance);
    }

    [Fact]
    public void doubleDepositTest()
    {
        BankAccount account = new BankAccount("Nguyen", 1000m);
        account.Deposit(50.75);
        Assert.Equal(1050.75m, account.Balance);
    }

    [Fact]
    public void WithdrawTest()
    {
        BankAccount account = new BankAccount("Nguyen", 1000m);
        Assert.Throws<ArgumentException>(()=> account.Withdraw(20000m));
    }
}
