public class EmployeeTests
{
[Fact]
    public void FullTimeEmployee_Test()
    {
        FullTimeEmployee employee = new FullTimeEmployee
        {
            Name = "Khanh",
            AnnualSalary = 5000m
        };

    decimal result = employee.CalculatePay();

    Assert.Equal(4000m, result);
    }

[Fact]
public void Contractor_Test()
{
    Contractor employee = new Contractor
    {   
        Name = "Thinh",
        Rate = 25m,
        Hours = 30m
    };

    decimal result = employee.CalculatePay();

    Assert.Equal(600m, result);
}

[Fact]
public void FullTimeEmployee_GenerateReport_Test()
{
    FullTimeEmployee employee = new FullTimeEmployee
    {
        Name = "Khanh",
        AnnualSalary = 5000m
    };

    string result = employee.GenerateReport();

    Assert.Contains("Khanh", result);
    Assert.Contains("4000", result);
}

[Fact]
public void Contractor_GenerateReport_Test()
{
    Contractor employee = new Contractor
    {
        Name = "Thinh",
        Rate = 25m,
        Hours = 30m
    };

    string result = employee.GenerateReport();

    Assert.Contains("Thinh", result);
    Assert.Contains("600", result);
}

[Fact]
public void Polymorphism_Test()
{
    Employee employee1 = new FullTimeEmployee
    {
        Name = "Khanh",
        AnnualSalary = 5000m
    };

    Employee employee2 = new Contractor
    {
        Name = "Thinh",
        Rate = 25m,
        Hours = 30m
    };

    Assert.Equal(4000m, employee1.CalculatePay());
    Assert.Equal(600m, employee2.CalculatePay());
}
}