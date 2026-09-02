using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("---- Task 1----");
        string[] names =
        {
            "Thinh",
            "Khanh",
            "Long",
            "Phat",
            "Diep",
        };
        Console.WriteLine("\nAll the name in arrays is: ");
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
        string longestName = names[0];
        string shortestName = names[0];

        foreach (string name in names)
        {
            if (name.Length > longestName.Length)
            {
                longestName = name;
            }
            if (name.Length < shortestName.Length)
            {
                shortestName = name;
            }
        }
        Console.WriteLine("\nLongest name: " + longestName);
        Console.WriteLine("\nShortest Name: " + shortestName);
        Console.WriteLine("\nArrays before sorting: ");
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
        Array.Sort(names);
        Console.WriteLine("\nArray after sorting: ");
        {
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }
        }
        Console.WriteLine("\nArrays before reversing: ");
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
        Console.WriteLine("\nArray after reversing: ");
        Array.Reverse(names);
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
        Console.WriteLine("---- Task 2 ----");
        List<string> StudentName = new List<string>();
        StudentName.Add("Thinh");
        StudentName.Add("Khanh");
        StudentName.Add("Phat");
        StudentName.Add("Long");
        StudentName.Add("Diep");
        Console.WriteLine("\nList after add: ");
        foreach (string student in StudentName)
        {
            Console.WriteLine(student);
        }
        StudentName.Remove("Khanh");
        Console.WriteLine("\nList after remove 'Khanh': ");
        foreach(string student in StudentName)
        {
            Console.WriteLine(student);
        }
        StudentName.Insert(4,"Nguyen");
        Console.WriteLine("\nList after insert: ");
        foreach (string student in StudentName)
        {
            Console.WriteLine(student);
        }
        string[] MoreStudent =
        {
            "Alex Nguyen",
            "Cian Tran",
            "Dylan Le",
            "Empire nguyen",
            "Vamos Thanh",
        };
        StudentName.AddRange(MoreStudent);
        Console.WriteLine("\nList after add range: ");
        foreach(string student in StudentName)
        {
            Console.WriteLine(student);
        }
        Console.WriteLine("Total student: "+ StudentName.Count);
        Console.WriteLine("Search for name");
        string SearchName = "Khanh";
        int index = StudentName.IndexOf(SearchName);
        if (index != -1)
        {
            Console.WriteLine($"Name: {SearchName} was found in list at index: {index}");
        }
        else
        {
            Console.WriteLine($"Name: {SearchName} was not found in list at index: {index}");
        }
        Console.WriteLine("\n Search for a partial name");
        string PartialName = "Nguyen";
        List<string> MatchName = StudentName.FindAll(name => name.Contains(PartialName,StringComparison.OrdinalIgnoreCase));
        Console.WriteLine($"Name contains partial '{PartialName}: '");
        foreach (string name in MatchName)
        {
            Console.WriteLine(name);
        }

        int totalLength = 0;
        foreach (string name in StudentName)
        {
            totalLength += name.Length;
        }
        Console.WriteLine("\nTotal length of all name in the list is: " + totalLength);



        List<string> Task1 = new List<string>(names);
        Console.WriteLine("Task 1 convert to list: ");
        Printlist(Task1);
        StudentName.AddRange(Task1);
        Console.WriteLine("The combine 2 tasks: ");
        Printlist(StudentName);
        Console.WriteLine("Total number of names: " + StudentName.Count);
        int finalcount = 0;
        foreach (string name in StudentName)
        {
            finalcount += name.Length;
        }
        Console.WriteLine("Total length: " + finalcount);
        Console.ReadKey();
    }
    static void Printlist(List<string> names)
    {
        for (int i = 0; i < names.Count; i++)
        {
            Console.WriteLine(i + ":" + names[i]);
        }
    }
}