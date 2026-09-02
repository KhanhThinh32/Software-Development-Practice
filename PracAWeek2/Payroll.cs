public class Payroll
{
    private double hours;
    private decimal rate;
    private decimal taxRate;

    public double Hours
    {
        get {return hours;}
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Hour cannot be negative.");
            }
            hours = value;
        }
    }

    public decimal Rate
    {
        get {return rate;}
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Rate must be positive.");
            }
            rate = value;
        }
    }

    public decimal TaxRate
    {
        get {return taxRate;}
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Tax Rate must be a positive number");
            }

            taxRate = value;
        }
    }

    public Payroll(double hours, decimal rate, decimal taxRate)
    {
        Hours = hours;
        Rate = rate;
        TaxRate = taxRate;
    }

    public decimal CalculatePay()
    {
        decimal gross =  (decimal)Hours * Rate;
        decimal tax = gross * TaxRate;
        
        return gross - tax;
    }

    public void ChangeTaxRate(decimal newTaxRate)
    {
        TaxRate = newTaxRate;
    }
}