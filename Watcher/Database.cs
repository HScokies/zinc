using Npgsql;
using Watcher;

static public class PgDatabase{
    static NpgsqlDataSource ds = null!;

    static public void init(string connection)
    {
        ds = NpgsqlDataSource.Create(connection);
        ds.OpenConnection();
    }


    static public void Execute(string query)
    {
        using var command = ds.CreateCommand(query);
        command.ExecuteNonQuery();
    }
}


