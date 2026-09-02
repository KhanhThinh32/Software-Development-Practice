public abstract class Employee
{
    public string Name {get; set;} = "";
    public const decimal TaxRate = 0.2m;
    public abstract decimal CalculatePay();

}