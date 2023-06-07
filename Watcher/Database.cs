using Npgsql;
using Watcher;

static public class PgDatabase{
    static NpgsqlDataSource ds;

    static public async void init()
    {
        ds = NpgsqlDataSource.Create(Appconfig.connectionString);
    }

    static public async Task ExecuteAsync(string query)
    {
        await using var command = ds.CreateCommand(query);
        await command.ExecuteNonQueryAsync();
    }
}


