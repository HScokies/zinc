using Npgsql;
using Octonica.ClickHouseClient;
using Watcher;

static public class ClickhouseDB{
    static ClickHouseConnection connection = new();

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
        connection.Open();
        string table, data;
        #region Departments migration
        table = "CREATE TABLE IF NOT EXISTS `departments`(`id` Int8, `name` String) ENGINE=MergeTree PRIMARY KEY(id);";
        data = "INSERT INTO `departments`(`id`, `name`) VALUES (1, 'OBG'),(2,'VELC'),(3,'GMC'),(4, 'SKC'),(5,'HVP'),(6,'VYSH'),(7,'KEC');";
        Execute(table);
        Execute(data);
        #endregion
        #region Stations migration
        table = "CREATE TABLE IF NOT EXISTS `stations`(`id` Int8, `name` String) ENGINE=MergeTree PRIMARY KEY(id);";
        data = "INSERT INTO `departments`(`id`, `name`) VALUES (1, 'OBG'),(2,'VELC'),(3,'GMC'),(4, 'SKC'),(5,'HVP'),(6,'VYSH'),(7,'KEC');";
        #endregion
        connection.Close();
    }
}


