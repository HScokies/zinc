using System.Globalization;
using System.Text;
using Watcher;

public static class DataParser
{

    public static void parseDat(string datPath, string station)
    {
        string query = $"INSERT INTO {Appconfig.Stations[station]}(num, timestamp, val) VALUES ";

        using (var fs = File.OpenRead(datPath))
        using (BufferedStream bs = new BufferedStream(fs))
        {
            using (var sr = new StreamReader(bs))
            {
                string[] rowData = sr.ReadLine()!.Split(';');
                query += ReadSingleRow(rowData[0], rowData[1], rowData);
            }
        }
        ClickhouseDB.Execute(query.Substring(0, query.Length - 1));
    }

    public static void parseCsv(string csvPath, string station)
    {
        using (var fs = File.OpenRead(csvPath))
        using (BufferedStream bs = new BufferedStream(fs))
        {
            using (var sr = new StreamReader(bs))
            {
                string query = $"INSERT INTO {Appconfig.Stations[station]}(num, timestamp, val) VALUES ";
                string csvData;
                while ((csvData = sr.ReadLine()!) != null)
                {
                    IEnumerable<string> data = csvData.Split('\n');
                    foreach (var row in data)
                    {
                        string[] rowData = row.Split(';');
                        try
                        {
                            query+=ReadSingleRow(rowData[0], rowData[1], rowData);
                        }
                        catch
                        {
                            break;
                        }

                    }
                }
                Console.WriteLine(query.Substring(0, query.Length - 1));
                //PgDatabase.Execute(query.Substring(0, query.Length - 1));
            }
        }
    }

    private static string ReadSingleRow(string CreationDate, string CreationTime, string[] data)
    {
        string query = null!;
        for (int i = 2; i < data.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(data[i])) { continue; }
            query += $"({i-1}, '{CreationDate} {CreationTime}', {data[i].Replace(",",".")}),";
        }
        return query;
    }
}
