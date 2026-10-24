
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Diagnostics;

class Test
{
    public static void Main()
    {
        Directory.CreateDirectory("Attachments");


        List<Player> players = new List<Player>();

        for (int i = 0; i < 10000; i++)
        {
            players.Add(new Player("Player" + i, 100, 20));
        }

        string listPath = @"Attachments/ListPlayers.txt";
        FileWriter(listPath, players);

        List<Player> loadedPlayers =
            FileReader<List<Player>>(listPath);

        GC.Collect();

        long listHeapSizeBytes =
            GC.GetGCMemoryInfo().HeapSizeBytes;

        long listPeakWorkingSet64 =
            Process.GetCurrentProcess().PeakWorkingSet64;

        Console.WriteLine("List<Player> Memory Usage:");
        Console.WriteLine("HeapSizeBytes: " + listHeapSizeBytes);
        Console.WriteLine("PeakWorkingSet64: " + listPeakWorkingSet64);

        GC.KeepAlive(players);
        GC.KeepAlive(loadedPlayers);


        LinkedList<Player> linkedPlayers =
            new LinkedList<Player>();

        for (int i = 0; i < 10000; i++)
        {
            linkedPlayers.AddLast(
                new Player("Player" + i, 100, 20));
        }


        string linkedPath = @"Attachments/LinkedListPlayers.txt";
        FileWriter(linkedPath, linkedPlayers);


        LinkedList<Player> loadedLinkedPlayers =
            FileReader<LinkedList<Player>>(linkedPath);


        GC.Collect();

        long linkedHeapSizeBytes =
            GC.GetGCMemoryInfo().HeapSizeBytes;

        long linkedPeakWorkingSet64 =
            Process.GetCurrentProcess().PeakWorkingSet64;

        Console.WriteLine("\nLinkedList<Player> Memory Usage:");
        Console.WriteLine("HeapSizeBytes: " + linkedHeapSizeBytes);
        Console.WriteLine("PeakWorkingSet64: " + linkedPeakWorkingSet64);

        GC.KeepAlive(linkedPlayers);
        GC.KeepAlive(loadedLinkedPlayers);
    }

    public static void FileWriter<T>(
        string path, T objectToWrite) where T : class
    {
        string jsonString =
            JsonSerializer.Serialize(objectToWrite);

        using (StreamWriter sw = File.CreateText(path))
        {
            sw.WriteLine(jsonString);
        }
    }

    public static T FileReader<T>(
        string path) where T : class
    {
        using (StreamReader sr = File.OpenText(path))
        {
            string jsonString = sr.ReadToEnd();

            return JsonSerializer.Deserialize<T>(jsonString)!;
        }
    }
}
