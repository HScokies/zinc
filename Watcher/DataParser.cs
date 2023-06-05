using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Globalization;
using Watcher;

public static class DataParser
{
    public static string CreationDate = null;
    public static string CreationTime = null;
    private static string decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

    public static async void parseCSV(string csvData, string station)
    {
        string[] data = csvData.Split('\n');
        using (AppDBcontext ctx = new AppDBcontext())
        {
            foreach (var row in data)
            {
                switch (station)
                {
                    case "CHPEW2":
                        Console.WriteLine(await ReadSingleRow(row, ';', station, ctx.kec1 ));
                        break;
                    case "CHPEW3":
                        await WriteSingleRow<KEC2>(ctx.kec2, ent.AutoMap<EIBD, KEC2>());
                        break;
                    case "HVP-Station":
                        await WriteSingleRow<HVP>(ctx.hvp, ent.AutoMap<EIBD, HVP>());
                        break;
                    case "IUS_OBG52":
                        await WriteSingleRow<OBG2>(ctx.obg2, ent.AutoMap<EIBD, OBG2>());
                        break;
                    case "IUS_OBG511":
                        await WriteSingleRow<OBG1>(ctx.obg1, ent.AutoMap<EIBD, OBG1>());
                        break;
                    case "IUS_SKC42":
                        await WriteSingleRow<SKC1>(ctx.skc1, ent.AutoMap<EIBD, SKC1>());
                        break;
                    case "IUS_SKC43":
                        await WriteSingleRow<SKC2>(ctx.skc2, ent.AutoMap<EIBD, SKC2>());
                        break;
                    case "IUS_V5":
                        await WriteSingleRow<Vysh>(ctx.vysh, ent.AutoMap<EIBD, Vysh>());
                        break;
                    case "IUS_VELC1":
                        await WriteSingleRow<GMC_Velc1>(ctx.gmc1, ent.AutoMap<EIBD, GMC_Velc1>());
                        break;
                    case "IUS_VELC2":
                        await WriteSingleRow<GMC_Velc2>(ctx.gmc2, ent.AutoMap<EIBD, GMC_Velc2>());
                        break;
                    case "KADMIEVOE":
                        await WriteSingleRow<KEC_Kadmievoe>(ctx.kadmievoe, ent.AutoMap<EIBD, KEC_Kadmievoe>());
                        break;
                    case "KVP61":
                        await WriteSingleRow<Velc_KVP6>(ctx.kvp6, ent.AutoMap<EIBD, Velc_KVP6>());
                        break;
                    case "LAROX":
                        await WriteSingleRow<GMC_Larox>(ctx.larox, ent.AutoMap<EIBD, GMC_Larox>());
                        break;
                    case "VELC5PC21":
                        await WriteSingleRow<Velc_KVP5>(ctx.kvp5, ent.AutoMap<EIBD, Velc_KVP5>());
                        break;
                    default:
                        Console.WriteLine($"Unknown station: {station}");
                        break;
                }
            }
        }
    }
    public static async Task<DateTime> ReadSingleRow<data>(string row, char separator, string station, DbSet<data> ctx)
    {
        string[] data = row.Split(separator);
        try
        {
            CreationDate = data[0]; CreationTime = data[1];
        } catch(IndexOutOfRangeException) { }

        for (int i = 2; i < data.Length; i++)
        {
            if (string.IsNullOrEmpty(data[i])) { continue; }
            var ent = new EIBD() { date = DateOnly.Parse(CreationDate), time = TimeOnly.Parse(CreationTime), num = i - 1, val = Convert.ToDouble(data[i].Replace(",", decimalSeparator)) };
                switch (station)
                {
                    case "CHPEW2":
                        await WriteSingleRow<KEC1>(ctx.kec1, ent.AutoMap<EIBD, KEC1>());
                        break;
                    case "CHPEW3":
                        await WriteSingleRow<KEC2>(ctx.kec2, ent.AutoMap<EIBD, KEC2>());
                        break;
                    case "HVP-Station":
                        await WriteSingleRow<HVP>(ctx.hvp, ent.AutoMap<EIBD, HVP>());
                        break;
                    case "IUS_OBG52":
                        await WriteSingleRow<OBG2>(ctx.obg2, ent.AutoMap<EIBD, OBG2>());
                        break;
                    case "IUS_OBG511":
                        await WriteSingleRow<OBG1>(ctx.obg1, ent.AutoMap<EIBD, OBG1>());
                        break;
                    case "IUS_SKC42":
                        await WriteSingleRow<SKC1>(ctx.skc1, ent.AutoMap<EIBD, SKC1>());
                        break;
                    case "IUS_SKC43":
                        await WriteSingleRow<SKC2>(ctx.skc2, ent.AutoMap<EIBD, SKC2>());
                        break;
                    case "IUS_V5":
                        await WriteSingleRow<Vysh>(ctx.vysh, ent.AutoMap<EIBD, Vysh>());
                        break;
                    case "IUS_VELC1":
                        await WriteSingleRow<GMC_Velc1>(ctx.gmc1, ent.AutoMap<EIBD, GMC_Velc1>());
                        break;
                    case "IUS_VELC2":
                        await WriteSingleRow<GMC_Velc2>(ctx.gmc2, ent.AutoMap<EIBD, GMC_Velc2>());
                        break;
                    case "KADMIEVOE":        
                        await WriteSingleRow<KEC_Kadmievoe>(ctx.kadmievoe, ent.AutoMap<EIBD, KEC_Kadmievoe>());
                        break;
                    case "KVP61":
                        await WriteSingleRow<Velc_KVP6>(ctx.kvp6, ent.AutoMap<EIBD, Velc_KVP6>());
                        break;
                    case "LAROX":
                        await WriteSingleRow<GMC_Larox>(ctx.larox, ent.AutoMap<EIBD, GMC_Larox>());
                        break;
                    case "VELC5PC21":
                        await WriteSingleRow<Velc_KVP5>(ctx.kvp5, ent.AutoMap<EIBD, Velc_KVP5>());
                        break;
                    default:
                        Console.WriteLine($"Unknown station: {station}");
                        break;
                }
        }
        return Convert.ToDateTime(CreationDate+" "+CreationTime);
    }

    public static async Task WriteSingleRow<data>(DbSet<data> ctx, data newData) where data : EIBD
    {
        await ctx.AddAsync(newData);
    }
}
