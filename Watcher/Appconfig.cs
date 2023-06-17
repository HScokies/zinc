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
        #region Station aliases
                public static Dictionary<string, string> Stations = new Dictionary<string, string>()
                {
                    { "CHPEW2", "kec1"},
                    { "CHPEW3", "kec2" },
                    { "KADMIEVOE", "kec_kadmievoe" },
                    { "IUS_VELC1", "gmc_velc1" },
                    { "IUS_VELC2", "gmc_velc2" },
                    { "IUS_SKC42", "skc1" },
                    { "IUS_SKC43", "skc2" },
                    { "LAROX", "gmc_larox" },
                    { "IUS_OBG511", "obg1" },
                    { "IUS_OBG52", "obg2" },
                    { "VELC5PC21", "velc_kvp5" },
                    { "KVP61", "velc_kvp6" },
                    { "IUS_V5", "vysh" },
                    { "HVP-Station", "hvp" }
                };
                #endregion
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
                    ClickhouseDB.Init(dbcfg);
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
        #region DB Config creator
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
            dbcfg.SERVER = !string.IsNullOrWhiteSpace(input) ? input : "localhost";

            Console.Write("\n\tDatabase [default]:");
            input = Console.ReadLine()!;
            dbcfg.DATABASE = !string.IsNullOrWhiteSpace(input) ? input : "default";

            Console.Write("\n\tPort [8123]:");
            input = Console.ReadLine()!;
            dbcfg.PORT = !string.IsNullOrWhiteSpace(input) ? Convert.ToUInt16(input) : (ushort)8123;

            Console.Write("\n\tUsername [default]:");
            input = Console.ReadLine()!;
            dbcfg.USER = !string.IsNullOrWhiteSpace(input) ? input : "default";

            Console.Write($"\n\tPassword for user {dbcfg.USER}:");
            input = Console.ReadLine()!;
            dbcfg.PASSWORD = input;

            try
            {
                ClickhouseDB.Init(dbcfg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                DbConfig();
            }
        }

    }
#endregion
        #region DB config model
    public class ConfigModel
    {
        public string SERVER { get; set; } = null!;
        public ushort PORT { get; set; }
        public string DATABASE { get; set; } = null!;
        public string USER { get; set; } = null!;
        public string PASSWORD { get; set; } = null!;
        public ConfigModel(string server = "localhost", ushort port = 8123, string database = "default", string user = "default", string password = null!)
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