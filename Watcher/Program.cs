using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
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
        string[] ExcludeDirectories = new string[] { @"\\ius_ebd_1.zinc.ru\Opros_ST\LocalHost" };
        string[] directories = Directory.GetDirectories(Appconfig.basePath);
        foreach (var directory in directories)
        {
            if (ExcludeDirectories.Contains(directory)) continue;
            string[] files = Directory.GetFiles(Path.Combine(directory, "R"));
            foreach (var file in files)
            {
                if (File.GetCreationTime(file) > new DateTime(2017,12,31)){
                    var station = new DirectoryInfo(directory).Name;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(file);
                    await DataParser.parseCSV(file, station);
                }
            }
        }
        Console.WriteLine("Dump completed!");
    }
    private static void InitWatcher()
    {
        using var watcher = new FileSystemWatcher(Appconfig.basePath);

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
        Console.WriteLine($"Watching: {Appconfig.basePath}");
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