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
        public static string basePath = string.Empty;
        public static string connectionString = string.Empty;

        public static void Init()
        {
            if (!File.Exists(configPath))
            {
                Console.WriteLine("Файл конфигурации не обнаружен!\n Создаем новый…");
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
                basePath = cfg[0]; connectionString = cfg[1];
            }

        }
        private static void CreateConfig()
        {
            Console.Clear();
            Console.Write("Watching directory:");
            basePath = Console.ReadLine();
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
            Console.WriteLine($"Watching directory: {basePath}");
            Console.WriteLine($"Connection string: {connectionString}");
            Console.Write("Is this correct? (y/n)");
            string response = Console.ReadKey().KeyChar.ToString().Trim().ToLower();
            switch (response)
            {
                case "y":
                    File.WriteAllText(configPath, (basePath+"\n"+connectionString));
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
