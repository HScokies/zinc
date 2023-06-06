using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Globalization;
using Watcher;

public static class DataParser
{

    private static string decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

    public static async Task parseCSV(string csvData, string station)
    {
        IEnumerable<string> data = csvData.Split('\n');
        foreach (var row in data)
        {
            string[] rowData = row.Split(';');
            try
            {
                DateOnly CreationDate = DateOnly.Parse(rowData[0]); TimeOnly CreationTime = TimeOnly.Parse(rowData[1]);
                await ReadSingleRow(CreationDate, CreationTime, rowData, ';', station);
            }
            catch
            {
                break;
            }

        }


    }

    private static async Task ReadSingleRow(DateOnly CreationDate, TimeOnly CreationTime, string[] data, char separator, string station)
    {

        try
        {
        } catch(Exception ex) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(ex.Message);  return; }
        using (AppDBcontext ctx = new AppDBcontext())
        {
            

            for (int i = 2; i < data.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(data[i])) { continue; }
                switch (station)
                {
                    case "CHPEW2":
                        await ctx.kec1.AddAsync(new KEC1() { id = 0, date = CreationDate, time = CreationTime, num = i - 1, val = Convert.ToDouble(data[i].Replace(",", decimalSeparator)) });
                        break;
                    case "CHPEW3":
                        await ctx.kec2.AddAsync(new KEC2() { id = 0, date = CreationDate, time = CreationTime, num = i - 1, val = Convert.ToDouble(data[i].Replace(",", decimalSeparator)) });
                        break;
                    case "HVP-Station":
                        await ctx.hvp.AddAsync(new HVP() { id = 0, date = CreationDate, time = CreationTime, num = i - 1, val = Convert.ToDouble(data[i].Replace(",", decimalSeparator)) });
                        break;
                    case "IUS_OBG52":
                        await ctx.obg2.AddAsync(new OBG2() { id = 0, date = CreationDate, time = CreationTime, num = i - 1, val = Convert.ToDouble(data[i].Replace(",", decimalSeparator)) });
                        break;
                    case "IUS_OBG511":
                        await ctx.obg1.AddAsync(new OBG1() { id = 0, date = CreationDate, time = CreationTime, num = i - 1, val = Convert.ToDouble(data[i].Replace(",", decimalSeparator)) });
                        break;
                    case "IUS_SKC42":
                        await ctx.skc1.AddAsync(new SKC1() { id = 0, date = CreationDate, time = CreationTime, num = i - 1, val = Convert.ToDouble(data[i].Replace(",", decimalSeparator)) });
                        break;
                    case "IUS_SKC43":
                        await ctx.skc2.AddAsync(new SKC2() { id = 0, date = CreationDate, time = CreationTime, num = i - 1, val = Convert.ToDouble(data[i].Replace(",", decimalSeparator)) });
                        break;
                    case "IUS_V5":
                        await ctx.vysh.AddAsync(new Vysh() { id = 0, date = CreationDate, time = CreationTime, num = i - 1, val = Convert.ToDouble(data[i].Replace(",", decimalSeparator)) });
                        break;
                    case "IUS_VELC1":
                        await ctx.gmc1.AddAsync(new GMC_Velc1() { id = 0, date = CreationDate, time = CreationTime, num = i - 1, val = Convert.ToDouble(data[i].Replace(",", decimalSeparator)) });
                        break;
                    case "IUS_VELC2":
                        await ctx.gmc2.AddAsync(new GMC_Velc2() { id = 0, date = CreationDate, time = CreationTime, num = i - 1, val = Convert.ToDouble(data[i].Replace(",", decimalSeparator)) });
                        break;
                    case "KADMIEVOE":
                        await ctx.kadmievoe.AddAsync(new KEC_Kadmievoe() { id = 0, date = CreationDate, time = CreationTime, num = i - 1, val = Convert.ToDouble(data[i].Replace(",", decimalSeparator)) });
                        break;
                    case "KVP61":
                        await ctx.kvp6.AddAsync(new Velc_KVP6() { id = 0, date = CreationDate, time = CreationTime, num = i - 1, val = Convert.ToDouble(data[i].Replace(",", decimalSeparator)) });
                        break;
                    case "LAROX":
                        await ctx.larox.AddAsync(new GMC_Larox() { id = 0, date = CreationDate, time = CreationTime, num = i - 1, val = Convert.ToDouble(data[i].Replace(",", decimalSeparator)) });
                        break;
                    case "VELC5PC21":
                        await ctx.kvp5.AddAsync(new Velc_KVP5() { id = 0, date = CreationDate, time = CreationTime, num = i - 1, val = Convert.ToDouble(data[i].Replace(",", decimalSeparator)) });
                        break;
                    default:
                        Console.WriteLine($"Unknown station: {station}");
                        break;
                }
            }
            await ctx.SaveChangesAsync();
        }
    }
}
