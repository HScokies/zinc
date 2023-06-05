using System;
using Microsoft.EntityFrameworkCore;
using Watcher;

public class EIBD // Абстрактная модель сущности для последующего наследования
{
    public int id { get; set; }
    public int num { get; set; } //Индекс столбца дампа (0 = 3)
    public DateOnly date { get; set; }
    public TimeOnly time { get; set; }
    public double val { get; set; } //Знч-е столбца дампа
}
public class KEC1 : EIBD { }//CHPEW2
public class KEC2 : EIBD { }//CHPEW3
public class KEC_Kadmievoe : EIBD { }//KADMIEVOE
public class GMC_Velc1 : EIBD { }//IUS_VELC1
public class GMC_Velc2 : EIBD { }//IUS_VELC2
public class SKC1 : EIBD { }//IUS_SKC42
public class SKC2 : EIBD { }//IUS_SKC43
public class GMC_Larox : EIBD { }//LAROX
public class OBG1 : EIBD { }//IUS_OBG511
public class OBG2 : EIBD { }//IUS_OBG52
public class Velc_KVP5 : EIBD { }//VELC5PC21
public class Velc_KVP6 : EIBD { }//KVP61
public class Vysh : EIBD { }//IUS_V5
public class HVP : EIBD { }//HVP_station

public class AppDBcontext : DbContext
{
    public DbSet<KEC1> kec1 { get; set; }
    public DbSet<KEC2> kec2 { get; set; }
    public DbSet<KEC_Kadmievoe> kadmievoe { get; set; }
    public DbSet<GMC_Velc1> gmc1 { get; set; }
    public DbSet<GMC_Velc2> gmc2 { get; set; }
    public DbSet<SKC1> skc1 { get; set; }
    public DbSet<SKC2> skc2 { get; set; }
    public DbSet<GMC_Larox> larox { get; set; }
    public DbSet<OBG1> obg1 { get; set; }
    public DbSet<OBG2> obg2 { get; set; }
    public DbSet<Velc_KVP5> kvp5 { get; set; }
    public DbSet<Velc_KVP6> kvp6 { get; set; }
    public DbSet<Vysh> vysh { get; set; }
    public DbSet<HVP> hvp { get; set; }

    public AppDBcontext()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Appconfig.connectionString);
    }
}


