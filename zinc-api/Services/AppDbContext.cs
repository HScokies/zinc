﻿using Microsoft.EntityFrameworkCore;
using zinc_api.Models.Entities;

namespace zinc_api.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //Сущности БД
        public DbSet<Department> departments { get; set; }
        public DbSet<Station> stations { get; set; }
        public DbSet<Tech_pok> tech_poks { get; set; }
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>().HasData(new {id=1, name="OBG" });
            modelBuilder.Entity<Department>().HasData(new { id = 2, name = "VELC" });
            modelBuilder.Entity<Department>().HasData(new { id = 3, name = "GMC" });
            modelBuilder.Entity<Department>().HasData(new { id = 4, name = "SKC" });
            modelBuilder.Entity<Department>().HasData(new { id = 5, name = "HVP" });
            modelBuilder.Entity<Department>().HasData(new { id = 6, name = "VYSH" });
            modelBuilder.Entity<Department>().HasData(new { id = 7, name = "KEC" });

            modelBuilder.Entity<Station>().HasData(new {id=1, name= "IUS_OBG511", dep_id=1, name_table = "OBG1" });
            modelBuilder.Entity<Station>().HasData(new { id = 2, name = "IUS_OBG52", dep_id = 1, name_table = "OBG2" });
            modelBuilder.Entity<Station>().HasData(new { id = 3, name = "IUS_VELC1", dep_id = 2, name_table = "GMC_Velc1" });
            modelBuilder.Entity<Station>().HasData(new { id = 4, name = "IUS_VELC2", dep_id = 2, name_table = "GMC_Velc2" });
            modelBuilder.Entity<Station>().HasData(new { id = 5, name = "VELC5PC21", dep_id = 2, name_table = "Velc_KVP5" });
            modelBuilder.Entity<Station>().HasData(new { id = 6, name = "KVP61", dep_id = 2, name_table = "Velc_KVP6" });
            modelBuilder.Entity<Station>().HasData(new { id = 7, name = "IUS_VELC1", dep_id = 3, name_table = "GMC_Velc1" });
            modelBuilder.Entity<Station>().HasData(new { id = 8, name = "IUS_VELC2", dep_id = 3, name_table = "GMC_Velc2" });
            modelBuilder.Entity<Station>().HasData(new { id = 9, name = "LAROX", dep_id = 3, name_table = "GMC_Larox" });
            modelBuilder.Entity<Station>().HasData(new { id = 10, name = "IUS_SKC42", dep_id = 4, name_table = "SKC1" });
            modelBuilder.Entity<Station>().HasData(new { id = 11, name = "IUS_SKC43", dep_id = 4, name_table = "SKC2" });
            modelBuilder.Entity<Station>().HasData(new { id = 12, name = "HVP_station", dep_id = 5, name_table = "HVP" });
            modelBuilder.Entity<Station>().HasData(new { id = 13, name = "IUS_V5", dep_id = 6, name_table = "Vysh" });
            modelBuilder.Entity<Station>().HasData(new { id = 14, name = "CHPEW2", dep_id = 7, name_table = "KEC1" });
            modelBuilder.Entity<Station>().HasData(new { id = 15, name = "CHPEW3", dep_id = 7, name_table = "KEC2" });
            modelBuilder.Entity<Station>().HasData(new { id = 16, name = "KADMIEVOE", dep_id = 7, name_table = "KEC_Kadmievoe" });
        }
    }
}
