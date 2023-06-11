using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Watcher
{
    static class Appconfig
    {
        private static string BASE_URL = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "WatcherData");
        private static string dbconfig = "dbconfig.json";

        public static string errorsLog = Path.Combine(BASE_URL, "Errors.log");


        public static ConfigModel cfg = new();
        
        public static void Init()
        {
            if (!Directory.Exists(BASE_URL))
            {
                Directory.CreateDirectory(BASE_URL);
                CreateConfig();
            }
            if (!File.Exists(Path.Combine(BASE_URL, dbconfig)))
            {
                CreateConfig();
            }
            else
            {
                try
                {
                    using (FileStream fs = new FileStream(Path.Combine(BASE_URL, dbconfig), FileMode.OpenOrCreate))
                    {
                        cfg = JsonSerializer.Deserialize<ConfigModel>(fs)!;
                    }
                    PgDatabase.init($"Host={cfg.SERVER};Port={cfg.PORT};Database={cfg.DATABASE};Username={cfg.USER};Password={cfg.PASSWORD};timeout=1024");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    CreateConfig();
                }
            }

            if (!File.Exists(errorsLog)) File.Create(errorsLog);
        }

        #region Config creation
        public static void CreateConfig()
        {
            DbConfig();
            using (FileStream fs = new FileStream(Path.Combine(BASE_URL, dbconfig), FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize<ConfigModel>(fs, cfg);
                Console.WriteLine($"Created: {Path.Combine(BASE_URL, dbconfig)}");
            }
        }

        private static void DbConfig()
        {
            Console.Clear();
            Console.WriteLine("Database connection configuration");
            string input = null!;
            
            Console.Write("\n\tServer [localhost]:");
            input = Console.ReadLine()!;
            cfg.SERVER = !string.IsNullOrWhiteSpace(input)?  input : "localhost";

            Console.Write("\n\tDatabase [postgres]:");
            input = Console.ReadLine()!;
            cfg.DATABASE = !string.IsNullOrWhiteSpace(input) ? input : "postgres";

            Console.Write("\n\tPort [5432]:");
            input = Console.ReadLine()!;
            cfg.PORT = !string.IsNullOrWhiteSpace(input) ? input : "5432";

            Console.Write("\n\tUsername [postgres]:");
            input = Console.ReadLine()!;
            cfg.USER = !string.IsNullOrWhiteSpace(input) ? input : "postgres";

            Console.Write($"\n\tPassword for user {cfg.USER}:");
            input = Console.ReadLine()!;
            cfg.PASSWORD = input;

            try
            {
                PgDatabase.init($"Host={cfg.SERVER};Port={cfg.PORT};Database={cfg.DATABASE};Username={cfg.USER};Password={cfg.PASSWORD};timeout=1024");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                DbConfig();
            }
        }
    
    }
        class ConfigModel
        {
            public string SERVER {get; set;}
            public string PORT { get; set; }
            public string DATABASE { get; set; }
            public string USER { get; set; }
            public string PASSWORD { get; set; }
        public ConfigModel(string server = "localhost", string port = "5432", string database = "postgres", string user = "postgres", string password =  null!)
            {
                SERVER = server;
                PORT = port;
                DATABASE = database;
                USER = user;
                PASSWORD = password;
            }
    }
    #endregion
}
