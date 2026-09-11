using System;
using System.Buffers;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        Stack<BankAccount> stack = new Stack<BankAccount>();
        stack.Push(new BankAccount("Khanh",500));
        stack.Push(new BankAccount("Thinh",1100));
        stack.Push(new BankAccount("Nguyen",1500));
        stack.Push(new BankAccount("Edward",200));
        stack.Push(new BankAccount("Long",300));
        stack.Push(new BankAccount("Phat",900));
        stack.Push(new BankAccount("Hyle",500));
        stack.Push(new BankAccount("Duke",1300));
        stack.Push(new BankAccount("Bryan",2000));
        stack.Push(new BankAccount("Lilian",600));

        Queue<BankAccount> queue = new Queue<BankAccount>();
        queue.Enqueue(new BankAccount("Khanh",500));
        queue.Enqueue(new BankAccount("Thinh",1100));
        queue.Enqueue(new BankAccount("Nguyen",1500));
        queue.Enqueue(new BankAccount("Edward",200));
        queue.Enqueue(new BankAccount("Long",300));
        queue.Enqueue(new BankAccount("Phat",900));
        queue.Enqueue(new BankAccount("Hyle",500));
        queue.Enqueue(new BankAccount("Duke",1300));
        queue.Enqueue(new BankAccount("Bryan",2000));
        queue.Enqueue(new BankAccount("Lilian",600));
        
        task3(stack,queue);
    }

    static void task1()
    {
        List<string> names = new List<string>(){
            "Khanh",
            "Thinh",
            "Nguyen",
            "Edward",
            "Long",
            "Phat",
            "Kyle",
            "Duke",
            "Bryan",
            "Lilian"
        };
        var order = names.OrderBy(x => x);
        List<string> sorted = order.ToList();
        Console.WriteLine("Names in alphabetical order: ");
        foreach(string name in sorted)
        {
            Console.WriteLine(name);
        }
    }

    static void task2()
    {
        Stack<BankAccount> bankAccounts = new Stack<BankAccount>();
        {
            bankAccounts.Push(new BankAccount("Khanh",500));
            bankAccounts.Push(new BankAccount("Thinh",1100));
            bankAccounts.Push(new BankAccount("Nguyen",1500));
            bankAccounts.Push(new BankAccount("Edward",200));
            bankAccounts.Push(new BankAccount("Long",300));
            bankAccounts.Push(new BankAccount("Phat",900));
            bankAccounts.Push(new BankAccount("Hyle",500));
            bankAccounts.Push(new BankAccount("Duke",1300));
            bankAccounts.Push(new BankAccount("Bryan",2000));
            bankAccounts.Push(new BankAccount("Lilian",600));
        }
        Console.WriteLine("Stack: ");
        foreach (BankAccount account in bankAccounts)
        {
            Console.WriteLine(account);
        }

        var stackOwner = bankAccounts
        .OrderBy(x => x.Owner)
        .Select(x => x.Owner);

        Console.WriteLine("\nStack Owners:");
        foreach(var owner in stackOwner)
        {
            Console.WriteLine(owner);
        }

        Queue<BankAccount> bankQueue = StackToQueue(bankAccounts);
        Console.WriteLine("\nQueue: ");
        foreach(BankAccount account in bankQueue)
        {
            Console.WriteLine(account);
        }
        var queueOwner = bankQueue.OrderBy(x=>x.Owner).Select(x=>x.Owner);
        Console.WriteLine("\nQueue Owner:");
        foreach(var owner in queueOwner)
        {
            Console.WriteLine(owner);
        }
    }

    static Queue<BankAccount> StackToQueue(Stack<BankAccount> stack)
    {
        Queue<BankAccount> queue = new Queue<BankAccount>();
        {
            foreach (BankAccount account in stack)
        {
            queue.Enqueue(account);
        }
        return queue;
        }
    }

    static void task3(Stack<BankAccount> stack, Queue<BankAccount> queue)
    {
        var stackResult = stack
        .Where(x => x.Owner.Contains("e"))
        .Select(x => new {x.Owner, x.Balance})
        .OrderBy(x => x.Balance);

        Console.WriteLine("\nStack results:");
        foreach(var account in stackResult)
        {
            Console.WriteLine($"{account.Owner} - {account.Balance}");
        }

        var queueResult = queue
        .Where(x => x.Owner.Contains("e"))
        .Select(x => new {x.Owner, x.Balance})
        .OrderBy(x => x.Balance);

        Console.WriteLine("\nQueue results:");
        foreach(var account in queueResult)
        {
            Console.WriteLine($"{account.Owner} - {account.Balance}");
        }
    }


}