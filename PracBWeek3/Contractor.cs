public class Contractor : Employee, IReportable
{
    public decimal Rate {get; set;}
    public decimal Hours{get; set;}

    public override decimal CalculatePay()
    {
        decimal pay = Rate * Hours;
        decimal tax = pay * TaxRate;

        return pay - tax;
    }
    public string GenerateReport()
    {
        return $"{Name}: Pay = {CalculatePay()}";
    }
}