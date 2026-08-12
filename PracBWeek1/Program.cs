using System; 
using System.Collections.Generic;
using System.ComponentModel;
public class ToDoApp
{
    private static Dictionary<string, List<int>> tags = new Dictionary<string, List<int>>();
    private static List<string> tasks = new List<string>();
    public static void Main()
    {
        Console.WriteLine("==== To Do ====");
        Console.WriteLine("Please input commands: 'add [item]', 'remove [index]', show, clear, " + "tag [index] [name], get-tagged [tag]");
        while (true)
        {
            Console.Write("\n> ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Error: Please input valid command. ");
                continue;
            }
            string[] parts = input.Trim().Split(' ',2);
            string command = parts[0].ToLower();
            switch(command)
            {
                case "add":
                AddTask(parts);
                break;
                
                case "show":
                ShowTasks();
                break;

                case "remove":
                RemoveTask(parts);
                break;

                case "clear":
                ClearTasks();
                break;

                case "tag":
                TagTask(input);
                break;

                case "get-tagged":
                GetTaggedTasks(parts);
                break;

                case "exit":
                return;

                default:
                Console.WriteLine("Error: Invalid command.");
                break;
            }
        }
    }

    private static void AddTask(string[] parts)
    {
        if (parts.Length < 2 || string.IsNullOrWhiteSpace(parts[1]))
        {
            Console.WriteLine("Error: Please input task.");
            Console.WriteLine("Example: add doing C#");
            return;
        }
        string task = parts[1].Trim();
        tasks.Add(task);
        Console.WriteLine($"Added {task}");
    }
    private static void ShowTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("There is no tasks.");
            return;
        }
        Console.WriteLine("Tasks:");
        
        for (int i=0; i<tasks.Count; i++)
        {
            Console.WriteLine($"{i}: {tasks[i]}");
        }
    }
    private static void RemoveTask(string[] parts)
    {
        if (parts.Length < 2 )
        {
            Console.WriteLine("Error: Please input an index.");
            Console.WriteLine("Example: remove 0");
            return;
        }
        if (!int.TryParse(parts[1], out int index))
        {
            Console.WriteLine("Index must be a number");
            return;
        }
        if (index < 0 || index > tasks.Count)
        {
            Console.WriteLine("Error: Index is out of range.");
            return;
        }
        string removedTasks = tasks[index];
        tasks.RemoveAt(index);
        Console.WriteLine($"Removed: {removedTasks}"); 
    }
    private static void ClearTasks()
    {
        tasks.Clear();
        Console.WriteLine("All tasks and tags are cleared");
    }

    private static void TagTask(string input)
    {
        try
        {
            string[] parts = input.Trim().Split(' ',3);
            if(parts.Length < 3)
            {
                throw new ArgumentException("Usage: tag [index] [name]");
            }

            if(!int.TryParse(parts[1], out int index))
            {
                throw new ArgumentException("Task index must be a number.");
            }

            if(index < 0 || index >= tasks.Count)
            {
                throw new ArgumentOutOfRangeException("Task index is out of range.");
            }
            
            string tagName = parts[2].Trim();
            if(string.IsNullOrEmpty(tagName))
            {
                throw new ArgumentException("Tag name cannot be empty");
            }
            
            if(!tags.ContainsKey(tagName))
            {
                tags[tagName] = new List<int>();
            }

            if(tags[tagName].Contains(index))
            {
                throw new InvalidOperationException($"Task {index} already has tag '{tagName}'");
            }

            tags[tagName].Add(index);

            Console.WriteLine($"Tagged task {index} with '{tagName}'.");
        }

        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void GetTaggedTasks(string[] parts)
    {
        try
        {
            if(parts.Length < 2 || string.IsNullOrWhiteSpace(parts[1]))
            {
                throw new ArgumentException("Usage: get-tagged [tag]");
            }

            string tagName = parts[1].Trim();

            if(!tags.ContainsKey(tagName))
            {
                throw new KeyNotFoundException($"Tag '{tagName}' does not exist.");
            }
            Console.WriteLine($"Task Tagged '{tagName}'.");

            foreach (int index in tags[tagName])
            {
                Console.WriteLine($"{index}: {tasks[index]}");
            }
        }
        
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        catch (KeyNotFoundException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}