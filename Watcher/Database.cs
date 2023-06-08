using Npgsql;
using Watcher;

static public class PgDatabase{
    static NpgsqlDataSource ds = null!;

    static public void init()
    {
        ds = NpgsqlDataSource.Create(Appconfig.connectionString);
    }

    static public async Task ExecuteAsync(string query)
    {
        await using var command = ds.CreateCommand(query);
        await command.ExecuteNonQueryAsync();
    }
}


