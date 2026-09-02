class Program
{
    static void Main()
    {
        Console.Write("Enter employee name: ");
        string name = Console.ReadLine();

        Console.Write("Hours worked: ");
        double hours = double.Parse(Console.ReadLine());

        Console.Write("Hourly rate: ");
        decimal rate = decimal.Parse(Console.ReadLine());

        Payroll payroll = new Payroll(hours, rate, 0.2m);

        decimal net_pay = payroll.CalculatePay();
        Console.WriteLine($"{name} earned ${net_pay:F2} after tax.");
    }
}