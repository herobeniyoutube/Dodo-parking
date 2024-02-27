using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Dodo_parking.DAL
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

            modelBuilder.Entity<TakenLotsCount>().HasData(new TakenLotsCount() { Id = 1, Small = 0, Medium = 0, Large = 0 });
            var config = TakenLotsCount.GetParkingConfigures();
            int sheetScale = config.LargeCarLotsCount + config.SmallCarLotsCount + config.MediumCarLotsCount;
            int lotCounter = 1;
            List<ParkingInfoDBEntity> sheet = new List<ParkingInfoDBEntity>();
            for (int i = 0; i < config.SmallCarLotsCount; i++)
            {
                sheet.Add(new ParkingInfoDBEntity("Small", "") { Id = lotCounter, ParkingTicketId = "", parkingLotId = $"S{lotCounter}" });
                lotCounter++;
            }
            for (int i = 0; i < config.MediumCarLotsCount; i++)
            {
                sheet.Add(new ParkingInfoDBEntity("Medium", "") { Id = lotCounter, ParkingTicketId = "", parkingLotId = $"M{lotCounter}" });
                lotCounter++;
            }
            for (int i = 0; i < config.LargeCarLotsCount; i++)
            {
                sheet.Add(new ParkingInfoDBEntity("Large", "") { Id = lotCounter, ParkingTicketId = "", parkingLotId = $"L{lotCounter}" });
                lotCounter++;
            }
            lotCounter = 1;

            modelBuilder.Entity<ParkingInfoDBEntity>().HasData(sheet);


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ParkingLotInfo.db");
        }


    }

}
