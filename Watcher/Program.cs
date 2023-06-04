using Watcher;

internal class Program
{
    private static void Main(string[] args)
    {
        Appconfig.Init();
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
        DataParser.parseCSV(File.ReadAllLines(e.FullPath)[0]);
    }

    private static void OnCreated(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"Created: {e.FullPath}");

    }


}