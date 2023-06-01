using Microsoft.EntityFrameworkCore;
using zinc_api.Models.Entities;

namespace zinc_api.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

        //Сущности БД
        public DbSet<Department> departments { get; set; }
        public DbSet<Station> stations { get; set; }
        public DbSet<Tech_pok> tech_poks { get; set; }
        public DbSet<KEC1> kec1 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>().HasData(new {id=0, name="OBG" });
            modelBuilder.Entity<Department>().HasData(new { id = 1, name = "VELC" });
            modelBuilder.Entity<Department>().HasData(new { id = 2, name = "GMC" });
            modelBuilder.Entity<Department>().HasData(new { id = 3, name = "SKC" });
            modelBuilder.Entity<Department>().HasData(new { id = 4, name = "HVP" });
            modelBuilder.Entity<Department>().HasData(new { id = 5, name = "VYSH" });
            modelBuilder.Entity<Department>().HasData(new { id = 6, name = "KEC" });
        }
    }
}
