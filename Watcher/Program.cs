using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Watcher;

internal class Program
{
    private static async Task<int> Main(string[] args)
    {
        Appconfig.Init();
        //csvDumper();
        DataParser.parseCSV(File.ReadAllText(@"\\ius_ebd_1.zinc.ru\Opros_ST\CHPEW2\R\CHPEW2_2018_12_11.csv"), "CHPEW2");
        Console.WriteLine("End");
        return 1;
    }

    private static async Task test()
    {
        using (AppDBcontext ctx = new AppDBcontext())
        {
            await DataParser.WriteSingleRow<KEC1>(ctx.kec1, new KEC1() { id = 0, date = new DateOnly(2020, 01, 01), time = new TimeOnly(10, 10), num = 1, val = 1 });
            await ctx.SaveChangesAsync();
        }
        Console.WriteLine("end");
    }
    private static void csvDumper()
    {
        string[] ExcludeDirectories = new string[] { @"\\ius_ebd_1.zinc.ru\Opros_ST\LocalHost" };
        string[] directories = Directory.GetDirectories(Appconfig.basePath);
        foreach (var directory in directories)
        {
            if (ExcludeDirectories.Contains(directory)) continue;
            string[] files = Directory.GetFiles(Path.Combine(directory, "R"));
            Console.Write(files[0]);
            foreach (var file in files)
            {
                if (File.GetCreationTime(file) > new DateTime(2017,12,31) && File.GetCreationTime(file) < DateTime.Now){
                    var station = new DirectoryInfo(directory).Name;
                    DataParser.parseCSV(File.ReadAllText(file), station);
                }
            }
        }
        Console.WriteLine("End");
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