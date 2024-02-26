using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Dodo_parking
{
    internal class ParkingInfoDBContext : DbContext
    {
        public static bool firstIteration = true;
        public ParkingInfoDBContext()
        {
            

            if (firstIteration)
            {
                
                Database.EnsureDeleted();
                Database.EnsureCreated();
                firstIteration = false;
                

            }


            
        }


        public ParkingInfoDBContext(DbContextOptions<ParkingInfoDBContext> options)
        : base(options) { }
        
        public virtual DbSet<ParkingInfoDBEntity> ParkingLots { get; set; }
        public virtual DbSet<TakenLotsCount> ParkingLotsScale { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
                modelBuilder.Entity<TakenLotsCount>().HasData(new TakenLotsCount() {Id = 1, Small = 0, Medium = 0,Large = 0 });

            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ParkingLotInfo.db");
        }


    }

}
