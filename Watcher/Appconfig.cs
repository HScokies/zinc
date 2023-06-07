using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watcher
{
    static class Appconfig
    {
        private static string configPath = "appconfig.cfg";
        public static string watchingPath = string.Empty;
        public static string connectionString = string.Empty;

        public static void Init()
        {
            if (!File.Exists(configPath))
            {
                CreateConfig();
            }
            string config = File.ReadAllText(configPath);
            if (config.Trim().Length == 0)
            {
                CreateConfig();
            }
            else
            {
                var cfg = config.Split('\n');
                watchingPath = cfg[0]; connectionString = cfg[1];
                PgDatabase.init();
            }
        }
        private static void CreateConfig()
        {
            Console.Clear();
            Console.Write("Watching directory:");
            watchingPath = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Database connection string builder");
            Console.Write("\n\tHost: ");
            connectionString = $"Host={Console.ReadLine()};";
            Console.Write("\n\tPort: ");
            connectionString += $"Port={Console.ReadLine()};";
            Console.Write("\n\tDatabase: ");
            connectionString += $"Database={Console.ReadLine()};";
            Console.Write("\n\tUser:");
            connectionString += $"Username={Console.ReadLine()};";
            Console.Write("\n\tPassword: ");
            connectionString += $"Password={Console.ReadLine()}";
            Verify();
        }
        private static void Verify()
        {
            Console.Clear();
            Console.WriteLine("Verify configuration");
            Console.WriteLine($"Watching directory: {watchingPath}");
            Console.WriteLine($"Connection string: {connectionString}");
            Console.Write("Is this correct? (y/n)");
            string response = Console.ReadKey().KeyChar.ToString().Trim().ToLower();
            switch (response)
            {
                case "y":
                    File.WriteAllText(configPath, (watchingPath +"\n"+connectionString));
                    Console.Clear();
                    break;
                case "n":
                    CreateConfig();
                    break;
                default:
                    Verify();
                    break;
            }
        }
    }
}
