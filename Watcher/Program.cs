﻿using System.Diagnostics;
using Watcher;

internal class Program
{
    private static void Main(string[] args)
    {
        Appconfig.Init();
        OpenMenu();
        //csvDumper();

    }
    private static void csvDumper()
    {
        Console.WriteLine("Enter path to csv containing folders:");
        List<string> CsvSource = new List<string>();
        string floder = Console.ReadLine()!;
        while (!string.IsNullOrWhiteSpace(floder))
        {
            if (Directory.Exists(floder)) CsvSource.Add(floder);
            else Console.WriteLine("Invalid floder:"+floder);
            floder = Console.ReadLine()!;
        }
        var timer = Stopwatch.StartNew();
        Console.Clear();
        Console.WriteLine("Starting dump process:");
        Parallel.ForEach(CsvSource, (directory) =>
        {
            var minDate = new DateTime(2018, 01, 01);
            string[] files = Directory.GetFiles(directory, "*.csv");
            foreach (var file in files)
            {

                if (File.GetCreationTime(file) >= minDate && File.GetLastWriteTime(file) >= minDate)
                {
                    string station = Directory.GetParent(directory)!.Name;
                    try
                    {
                        DataParser.parseCsv(file, station);
                        Console.WriteLine("[\u001b[32mOK\u001b[37m]" + file);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[\u001b[31mERR\u001b[37m] {file}");
                        Logger(DateTime.Now, file, ex.Message);
                    }
                }
            }
        });

        timer.Stop();
        Console.WriteLine($"Dump completed in {timer.ElapsedMilliseconds}");
    }

    private static void fileWatcher()
    {
        Console.Write("Enter watching directory:");
        string directory = Console.ReadLine()!;
        while (!Directory.Exists(directory))
        {
            Console.WriteLine($"Directory:{directory} is not found!");
            directory = Console.ReadLine()!;
        }
        Console.Clear();
        Console.WriteLine("Initializing the watcher...");
        
        using FileSystemWatcher watcher = new FileSystemWatcher(directory);
        watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite;
        watcher.Changed += onChange;
        watcher.Filter = "tek.dat";
        watcher.IncludeSubdirectories = true;
        watcher.EnableRaisingEvents = true;
        Console.WriteLine("Press enter to exit.");
        Console.ReadKey();
    }

    private static void onChange(object sender, FileSystemEventArgs e)
    {
        string station = Directory.GetParent(e.FullPath)!.Name;
        if (station == "LocalHost") return;
        try
        {
            DataParser.parseDat(e.FullPath, station);
            Console.WriteLine("[\u001b[32mOK\u001b[37m]" + e.FullPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[\u001b[31mERR\u001b[37m] {e.FullPath}");
            Logger(DateTime.Now, e.FullPath, $"{ex.Message}\n{File.ReadAllText(e.FullPath)}");
        }
    }

    private static void Logger(DateTime timestamp, String file, String Message)
    {
        using (StreamWriter sw = File.AppendText(Appconfig.errorsLog))
        {
            sw.WriteLine(timestamp);
            sw.WriteLine($"File: {file}");
            sw.WriteLine($"Message: {Message}\n");
        }
    }

    private static void OpenMenu()
    {
        Console.Clear();
        Console.CursorVisible = false;
        (int left, int top) = Console.GetCursorPosition();
        int currentOption = 2;

        string active = "\u001b[32m";
        string inactive = "\u001b[0m";

        ConsoleKeyInfo key;
        bool isSelected = false;

        while (!isSelected)
        {
            Console.SetCursorPosition(left, top);
            Console.WriteLine($"{(currentOption == 2 ? active : "")}File Watcher{inactive}");
            Console.WriteLine($"{(currentOption == 1 ? active : "")}CSV Dumper{inactive}");
            Console.WriteLine($"{(currentOption == 0 ? active : "")}Database config{inactive}");
            key = Console.ReadKey(true);
            switch ( key.Key )
            {
                case ConsoleKey.UpArrow:
                    currentOption = (currentOption + 1) % 3;
                    break;

                case ConsoleKey.DownArrow:
                    currentOption = (currentOption - 1) < 0? 2 : (currentOption - 1) % 3;
                    break;

                case ConsoleKey.Enter:
                    isSelected = true;
                    break;
            }
        }
        Console.Clear() ;
        switch ( currentOption )
        {
            case 0:
                Appconfig.CreateConfig();
                break;
            case 1:
                csvDumper();
                break;
            case 2:
                fileWatcher();
                break;
        }
    }
}