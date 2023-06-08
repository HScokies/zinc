﻿using System.Diagnostics;
using Watcher;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Appconfig.Init();

        var counter = Stopwatch.StartNew();
        await csvDumper();
        counter.Stop();
        Console.WriteLine($"Completed in {counter.ElapsedMilliseconds}ms");
    }
    
    private static async Task csvDumper()
    {
        Console.WriteLine("Enter path to csv containing folders:");
        List<string> CsvSource = new List<string>();
        string floder = Console.ReadLine()!;
        while (!string.IsNullOrWhiteSpace(floder))
        {
            if (Directory.Exists(floder)) CsvSource.Add(floder);
            else Console.WriteLine("Invalid floder:"+floder);
            floder = Console.ReadLine();
        }
        Console.Clear();
        Console.WriteLine("Starting dump process:");
        var minDate = new DateTime(2018, 01, 01);
        foreach (var directory in CsvSource)
        {
            string[] files = Directory.GetFiles(directory, "*.csv");
            foreach (var file in files)
            {
                
                if (File.GetCreationTime(file) >= minDate && File.GetLastWriteTime(file) >= minDate)
                {
                    string station = Directory.GetParent(directory).Name;
                    try
                    {
                        await DataParser.parseCSV(file, station);
                        Console.WriteLine("[\u001b[32mOK\u001b[37m]" + file);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("[\u001b[31mERR\u001b[37m] " + ex.Message);
                    }
                }
            }
        }
        Console.WriteLine("Dump completed!");
    }
    private static void InitWatcher()
    {
        using var watcher = new FileSystemWatcher(Appconfig.watchingPath);

        watcher.NotifyFilter = NotifyFilters.Attributes
                             | NotifyFilters.CreationTime
                             | NotifyFilters.DirectoryName
                             | NotifyFilters.FileName
                             | NotifyFilters.LastAccess
                             | NotifyFilters.LastWrite
                             | NotifyFilters.Security
                             | NotifyFilters.Size;

        watcher.Changed += OnChanged;
        watcher.Created += OnCreated;


        watcher.Filter = "*";
        watcher.IncludeSubdirectories = true;
        watcher.EnableRaisingEvents = true;
        Console.WriteLine($"Watching: {Appconfig.watchingPath}");
        Console.ReadKey();
    }
    private static void OnChanged(object sender, FileSystemEventArgs e)
    {
        if (e.ChangeType != WatcherChangeTypes.Changed)
        {
            return;
        }
        Console.WriteLine($"Changed: {e.FullPath}");
        //DataParser.parseCSV(File.ReadAllLines(e.FullPath)[0]);
    }

    private static void OnCreated(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"Created: {e.FullPath}");

    }


}
