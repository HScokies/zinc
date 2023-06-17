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
        public static string BASE_URL = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "WatcherData");
        private static string dbconfig = "dbconfig.json";

        public static string errorsLog = Path.Combine(BASE_URL, "Errors.log");

        public static ConfigModel dbcfg = new();

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
                        dbcfg = JsonSerializer.Deserialize<ConfigModel>(fs)!;
                    }
                    PgDatabase.Init($"Host={dbcfg.SERVER};Port={dbcfg.PORT};Database={dbcfg.DATABASE};Username={dbcfg.USER};Password={dbcfg.PASSWORD};timeout=1024");
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
                JsonSerializer.Serialize<ConfigModel>(fs, dbcfg);
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
            dbcfg.SERVER = !string.IsNullOrWhiteSpace(input)?  input : "localhost";

            Console.Write("\n\tDatabase [postgres]:");
            input = Console.ReadLine()!;
            dbcfg.DATABASE = !string.IsNullOrWhiteSpace(input) ? input : "postgres";

            Console.Write("\n\tPort [5432]:");
            input = Console.ReadLine()!;
            dbcfg.PORT = !string.IsNullOrWhiteSpace(input) ? input : "5432";

            Console.Write("\n\tUsername [postgres]:");
            input = Console.ReadLine()!;
            dbcfg.USER = !string.IsNullOrWhiteSpace(input) ? input : "postgres";

            Console.Write($"\n\tPassword for user {dbcfg.USER}:");
            input = Console.ReadLine()!;
            dbcfg.PASSWORD = input;

            try
            {
                PgDatabase.Init($"Host={dbcfg.SERVER};Port={dbcfg.PORT};Database={dbcfg.DATABASE};Username={dbcfg.USER};Password={dbcfg.PASSWORD};timeout=1024");
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
        public string SERVER { get; set; } = null!;
        public string PORT { get; set; } = null!;
        public string DATABASE { get; set; } = null!;
        public string USER { get; set; } = null!;
        public string PASSWORD { get; set; } = null!;
        public ConfigModel(string server = "localhost", string port = "5432", string database = "postgres", string user = "postgres", string password = null!)
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
