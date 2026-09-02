using System.Diagnostics.Contracts;

FullTimeEmployee employee = new FullTimeEmployee
{
    Name = "Khanh",
    AnnualSalary = 5000m
};

Contractor employee1 = new Contractor
{
    Name = "Thinh",
    Rate = 25m,
    Hours = 30m
};
Console.WriteLine("--- Task 1 ---");
Console.WriteLine(employee.CalculatePay());
Console.WriteLine(employee.GenerateReport());
Console.WriteLine(employee1.CalculatePay());
Console.WriteLine(employee1.GenerateReport());
Console.WriteLine("--- Task 2 ---");
List<Employee> employees = new List<Employee>();
employees.Add(employee);
employees.Add(employee1);

foreach (Employee e in employees)
{
    decimal netPay = e.CalculatePay();
    decimal pay = netPay/(1 - Employee.TaxRate);
    decimal tax = pay * Employee.TaxRate;
    Console.WriteLine($"{e.Name}: Pay ${pay}. Tax ${tax}.");
}