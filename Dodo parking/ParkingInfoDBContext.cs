using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Dodo_parking
{
    internal class ParkingInfoDBContext : DbContext
    {
        public static bool firstIteration = true;   
        public ParkingInfoDBContext() 
        {
            var count = this.ParkingLotsScale.Count();
           
            if (firstIteration)
            {
                Database.EnsureDeleted();
                firstIteration = false;
            }

            
            Database.EnsureCreated();
        }


        public ParkingInfoDBContext(DbContextOptions<ParkingInfoDBContext> options)
        : base(options)
        {
        }
        public virtual DbSet<ParkingInfoDBEntity> ParkingLots { get; set; }
        public virtual DbSet<TakenLotsForEachCarScale> ParkingLotsScale { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=ParkingLotInfo.db");
         
    }

}
