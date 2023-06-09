﻿using System.Diagnostics;
using System.IO;
using Watcher;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Appconfig.Init();

        var counter = Stopwatch.StartNew();
        await csvDumper();
        counter.Stop();
        Console.WriteLine($"Completed in {counter.ElapsedMilliseconds}ms");
    }
    /*
\\ius_ebd.zinc.ru\Opros_ST\CHPEW2\R
\\ius_ebd.zinc.ru\Opros_ST\CHPEW3\R
\\ius_ebd.zinc.ru\Opros_ST\KADMIEVOE\R
\\ius_ebd.zinc.ru\Opros_ST\IUS_VELC1\R
\\ius_ebd.zinc.ru\Opros_ST\IUS_VELC2\R
\\ius_ebd.zinc.ru\Opros_ST\IUS_SKC42\R
\\ius_ebd.zinc.ru\Opros_ST\IUS_SKC43\R
\\ius_ebd.zinc.ru\Opros_ST\LAROX\R
\\ius_ebd.zinc.ru\Opros_ST\IUS_OBG511\R
\\ius_ebd.zinc.ru\Opros_ST\IUS_OBG52\R
\\ius_ebd.zinc.ru\Opros_ST\VELC5PC21\R
\\ius_ebd.zinc.ru\Opros_ST\KVP61\R
\\ius_ebd.zinc.ru\Opros_ST\IUS_V5\R
\\ius_ebd.zinc.ru\Opros_ST\HVP-station\R
*/
    private static async Task csvDumper()
    {
        Console.WriteLine("Enter path to csv containing folders:");
        List<string> CsvSource = new List<string>();
        string floder = Console.ReadLine()!;
        while (!string.IsNullOrWhiteSpace(floder))
        {
            if (Directory.Exists(floder)) CsvSource.Add(floder);
            else Console.WriteLine("Invalid floder:"+floder);
            floder = Console.ReadLine()!;
        }
        Console.Clear();
        Console.WriteLine("Starting dump process:");
        var minDate = new DateTime(2018, 01, 01);
        foreach (var directory in CsvSource)
        {
            string[] files = Directory.GetFiles(directory, "*.csv");
            foreach (var file in files)
            {
                
                if (File.GetCreationTime(file) >= minDate && File.GetLastWriteTime(file) >= minDate)
                {
                    string station = Directory.GetParent(directory)!.Name;
                    try
                    {
                        await DataParser.parseCSV(file, station);
                        Console.WriteLine("[\u001b[32mOK\u001b[37m]" + file);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[\u001b[31mERR\u001b[37m] {file}");
                        Logger(DateTime.Now, file, ex.Message);
                    }
                }
            }
        }
        Console.WriteLine("Dump completed!");
    }

    private static void Logger(DateTime timestamp, String file, String Message)
    {
        using (StreamWriter sw = File.AppendText(Appconfig.errorsLog))
        {
            sw.WriteLine(timestamp);
            sw.WriteLine($"File: {file}");
            sw.WriteLine($"Message: {Message}\n");
        }
    }

}