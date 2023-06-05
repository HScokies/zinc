using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Globalization;
using Watcher;

public static class DataParser
{
    public static string CreationDate = null;
    public static string CreationTime = null;
    private static string decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

    public static async Task parseCSV(string csvData, string station)
    {
        string[] data = csvData.Split('\n');
        using (AppDBcontext ctx = new AppDBcontext())
        {
            foreach (var row in data)
            {
                await ReadSingleRow(row, ';', station);
            }

        }
    }

    private static async Task ReadSingleRow(string row, char separator, string station)
    {
        string[] data = row.Split(separator);
        try
        {
            CreationDate = data[0]; CreationTime = data[1];
        } catch(IndexOutOfRangeException) { }

        using (AppDBcontext ctx = new AppDBcontext())
        {
            for (int i = 2; i < data.Length; i++)
            {
                if (string.IsNullOrEmpty(data[i])) { continue; }
                var ent = new EIBD() { id = 0, date = DateOnly.Parse(CreationDate), time = TimeOnly.Parse(CreationTime), num = i - 1, val = Convert.ToDouble(data[i].Replace(",", decimalSeparator)) };
                switch (station)
                {
                    case "CHPEW2":
                        await ctx.kec1.AddAsync(ent.AutoMap<EIBD, KEC1>());
                        break;
                    case "CHPEW3":
                        await ctx.kec2.AddAsync(ent.AutoMap<EIBD, KEC2>());
                        break;
                    case "HVP-Station":
                        await ctx.hvp.AddAsync(ent.AutoMap<EIBD, HVP>());
                        break;
                    case "IUS_OBG52":
                        await ctx.obg2.AddAsync(ent.AutoMap<EIBD, OBG2>());
                        break;
                    case "IUS_OBG511":
                        await ctx.obg1.AddAsync(ent.AutoMap<EIBD, OBG1>());
                        break;
                    case "IUS_SKC42":
                        await ctx.skc1.AddAsync(ent.AutoMap<EIBD, SKC1>());
                        break;
                    case "IUS_SKC43":
                        await ctx.skc2.AddAsync(ent.AutoMap<EIBD, SKC2>());
                        break;
                    case "IUS_V5":
                        await ctx.vysh.AddAsync(ent.AutoMap<EIBD, Vysh>());
                        break;
                    case "IUS_VELC1":
                        await ctx.gmc1.AddAsync(ent.AutoMap<EIBD, GMC_Velc1>());
                        break;
                    case "IUS_VELC2":
                        await ctx.gmc2.AddAsync(ent.AutoMap<EIBD, GMC_Velc2>());
                        break;
                    case "KADMIEVOE":
                        await ctx.kadmievoe.AddAsync(ent.AutoMap<EIBD, KEC_Kadmievoe>());
                        break;
                    case "KVP61":
                        await ctx.kvp6.AddAsync(ent.AutoMap<EIBD, Velc_KVP6>());
                        break;
                    case "LAROX":
                        await ctx.larox.AddAsync(ent.AutoMap<EIBD, GMC_Larox>());
                        break;
                    case "VELC5PC21":
                        await ctx.kvp5.AddAsync(ent.AutoMap<EIBD, Velc_KVP5>());
                        break;
                    default:
                        Console.WriteLine($"Unknown station: {station}");
                        break;
                }
            }
            try
            {
                await ctx.SaveChangesAsync();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{CreationDate} {CreationTime} {station}: Created");
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{CreationDate} {CreationTime} {station}: Fail");
            }
        }
    }
}
