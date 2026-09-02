using Xunit;

public class UnitTest1
{
    [Fact]
    public void Constructor_WithValidValues_CreatesPayroll()
    {
        Payroll payroll = new Payroll(40, 25m, 0.2m);

        Assert.Equal(40, payroll.Hours);
        Assert.Equal(25m, payroll.Rate);
        Assert.Equal(0.2m, payroll.TaxRate);
    }

    [Fact]
    public void NegativeHoursCheck()
    {
        Assert.Throws<ArgumentException>(() =>
            new Payroll(-1, 25m, 0.2m));
    }

    [Fact]
    public void NegativeRateCheck()
    {
        Assert.Throws<ArgumentException>(() =>
            new Payroll(40, -25m, 0.2m));
    }

    [Fact]
    public void NegativeTaxRateCheck()
    {
        Assert.Throws<ArgumentException>(() =>
            new Payroll(40, 25m, -0.2m));
    }

    [Fact]
    public void CalculateNetPayCheck()
    {
        Payroll payroll = new Payroll(40, 25m, 0.2m);

        decimal net_pay = payroll.CalculatePay();

        Assert.Equal(800m, net_pay);
    }

    [Fact]
    public void ChangeTaxRateCheck()
    {
        Payroll payroll = new Payroll(40, 25m, 0.2m);

        payroll.ChangeTaxRate(0.1m);

        Assert.Equal(0.1m, payroll.TaxRate);
    }

    [Fact]
    public void ChangeTaxRate_WithNegativeValueCheck()
    {
        Payroll payroll = new Payroll(40, 25m, 0.2m);

        Assert.Throws<ArgumentException>(() =>
            payroll.ChangeTaxRate(-0.1m));
    }
}