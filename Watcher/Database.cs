using Npgsql;
using Octonica.ClickHouseClient;
using Watcher;

static public class ClickhouseDB{
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
    static public ClickHouseConnection connection = new();

    static public void Init(ConfigModel config)
    {
        var ConnectionBuilder = new ClickHouseConnectionStringBuilder();
        ConnectionBuilder.Host = config.SERVER;
        ConnectionBuilder.Port = config.PORT;
        ConnectionBuilder.User = config.USER;
        ConnectionBuilder.Password = config.PASSWORD;
        ConnectionBuilder.Database = config.DATABASE;
        connection = new(ConnectionBuilder);
        connection.Open();
        connection.Close();

    }

    static public void Execute(string query)
    {
        using var cmd = connection.CreateCommand(query);
        cmd.ExecuteNonQuery();
    }

    static public void InitMigration()
    {
        Console.WriteLine("Build started...");
        connection.Open();
        string Engine = "MergeTree";
        string OrderBy = "timestamp";
        foreach(var stationAlias in Stations)
        {
            try
            {
                string cmd = $"CREATE TABLE IF NOT EXISTS {stationAlias.Value}(`timestamp` DateTime,`indices` Array(Int16), `values` Array(DOUBLE)) ENGINE={Engine} ORDER BY `{OrderBy}`;";
                Execute(cmd);
                Console.WriteLine(cmd);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Build failed.\n"+ex.Message);
            }

        }
        connection.Close();
        Console.WriteLine("Build succeeded.\nPress any key ...");
        Console.ReadKey();
    }
}


