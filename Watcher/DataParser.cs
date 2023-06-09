using System.Globalization;
using System.Text;
using Watcher;

public static class DataParser
{

    private static Dictionary<string, string> Stations = new Dictionary<string, string>()
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
        { "HVP-station", "hvp" }

    };


    public static async Task parse(string csvPath, string station)
    {
        using (var fs = File.OpenRead(csvPath))
        using (BufferedStream bs = new BufferedStream(fs))
        {
            using (var sr = new StreamReader(bs))
            {
                string query = $"INSERT INTO {Stations[station]}(num, timestamp, val) VALUES ";
                string csvData;
                while ((csvData = sr.ReadLine()!) != null)
                {
                    IEnumerable<string> data = csvData.Split('\n');
                    foreach (var row in data)
                    {
                        string[] rowData = row.Split(';');
                        try
                        {
                            query+=ReadSingleRow(rowData[0], rowData[1], rowData, ';', station);
                        }
                        catch
                        {
                            break;
                        }

                    }
                }
                await PgDatabase.ExecuteAsync(query.Substring(0, query.Length - 1));
            }
        }
    }

    private static string ReadSingleRow(string CreationDate, string CreationTime, string[] data, char separator, string station)
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
