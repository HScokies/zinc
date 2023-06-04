using System;
using System.Globalization;

public static class DataParser
{
    public static string date = null;
    public static string time = null;
    private static string decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

    public static async void parseCSV(string csvData)
    {
        string[] data = csvData.Split('\n');
        foreach (var row in data)
        {
            using (AppDBcontext ctx = new AppDBcontext())
            {
                var res = await ReadSingleRow(row, ';',ctx);
                await ctx.SaveChangesAsync();
                Console.WriteLine(res +" - created");
            }

        }
    }
    public static async Task<DateTime> ReadSingleRow(string row, char separator, AppDBcontext ctx)
    {
        string[] data = row.Split(separator);
        try
        {
            date = data[0]; time = data[1];
        } catch(IndexOutOfRangeException ex) { }
        for (int i = 2; i < data.Length; i++)
        {
            if (string.IsNullOrEmpty(data[i])) { Console.WriteLine(i - 1); continue; }
            KEC1 kec1 = new KEC1() {date = DateOnly.Parse(date),  time = TimeOnly.Parse(time), num = i-1, val = Convert.ToDouble(data[i].Replace(",",decimalSeparator)) };
            await ctx.kec1.AddAsync(kec1);
        }
        return Convert.ToDateTime(date+" "+time);
    }
}
