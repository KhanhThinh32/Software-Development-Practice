using System;
class Program
{
    static void Main()
    {
        Person person = new Person("John", "Smith", 38);

        Console.WriteLine(person.FullName());
        Console.WriteLine(person.IsAdult());
    }
}