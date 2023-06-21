using System.Globalization;
using System.Text;
using Watcher;

public static class DataParser
{
    static NumberFormatInfo nfi = new NumberFormatInfo();

    public static void parseDat(string datPath, string station)
    {
        nfi.NumberDecimalSeparator = ",";
        string query = $"INSERT INTO `{ClickhouseDB.Stations[station]}`(`timestamp`, `indices`, `values`) VALUES ";

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
        nfi.NumberDecimalSeparator = ",";
        using (var fs = File.OpenRead(csvPath))
        using (BufferedStream bs = new BufferedStream(fs))
        {
            using (var sr = new StreamReader(bs))
            {
                string query = $"INSERT INTO `{ClickhouseDB.Stations[station]}`(`timestamp`, `indices`, `values`) VALUES ";
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
                ClickhouseDB.Execute(query.Substring(0, query.Length - 1));
            }
        }
    }

    private static string ReadSingleRow(string CreationDate, string CreationTime, string[] data)
    {
        string query = $"('{Convert.ToDateTime(CreationDate +" "+ CreationTime).ToString("yyyy-MM-dd hh:mm:ss")}', ";
        string indices = null!;
        string values = null!;
        for (int i = 2; i < data.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(data[i])) { continue; }
            indices += $"{i},";
            values += $"{double.Parse(data[i],nfi)},";
        }
        if (indices != null)
        {
            values = values.Substring(0, values.Length - 1);
            indices = indices.Substring(0, indices.Length - 1);
        }

        query += "["+indices + "],[" + values + "]),";
        return query;
    }
}
