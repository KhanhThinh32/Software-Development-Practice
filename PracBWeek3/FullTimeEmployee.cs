public class FullTimeEmployee : Employee, IReportable
{
    public decimal AnnualSalary {get; set;}
    public override decimal CalculatePay()
    {
        decimal tax = AnnualSalary * TaxRate;
        return AnnualSalary - tax; 
    }

    public string GenerateReport()
    {
        decimal tax = AnnualSalary * TaxRate;
        decimal netPay = CalculatePay();

        return $"{Name} - Pay: {CalculatePay()}";
    }
}