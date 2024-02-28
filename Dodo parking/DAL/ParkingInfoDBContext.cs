using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Dodo_parking.DAL
{
    public class ParkingInfoDBContext : DbContext
    {
        public ParkingInfoDBContext()
        {
            if (IsFirstIteration)
            {
                Database.EnsureDeleted();
                Database.EnsureCreated();
                IsFirstIteration = false;
            }
        }

        public ParkingInfoDBContext(DbContextOptions<ParkingInfoDBContext> options) : base(options) { }

        public virtual DbSet<ParkingInfoDBEntity> ParkingLots { get; set; }
        public virtual DbSet<TakenLotsCount> ParkingLotsScale { get; set; }

        public static bool IsFirstIteration = true;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var config = TakenLotsCount.GetParkingConfigures();
            int sheetScale = config.LargeCarLotsCount + config.SmallCarLotsCount + config.MediumCarLotsCount;
            int lotCounter = 1;
            List<ParkingInfoDBEntity> sheet = new List<ParkingInfoDBEntity>();

            for (int i = 0; i < config.SmallCarLotsCount; i++)
            {
                sheet.Add(new ParkingInfoDBEntity("Small", "") { Id = lotCounter, ParkingTicketId = "", ParkingLotId = $"S{lotCounter}" });
                lotCounter++;
            }

            for (int i = 0; i < config.MediumCarLotsCount; i++)
            {
                sheet.Add(new ParkingInfoDBEntity("Medium", "") { Id = lotCounter, ParkingTicketId = "", ParkingLotId = $"M{lotCounter}" });
                lotCounter++;
            }

            for (int i = 0; i < config.LargeCarLotsCount; i++)
            {
                sheet.Add(new ParkingInfoDBEntity("Large", "") { Id = lotCounter, ParkingTicketId = "", ParkingLotId = $"L{lotCounter}" });
                lotCounter++;
            }

            lotCounter = 1;

            modelBuilder.Entity<TakenLotsCount>().HasData(new TakenLotsCount() { Id = 1, Small = 0, Medium = 0, Large = 0 });
            modelBuilder.Entity<ParkingInfoDBEntity>().HasData(sheet);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ParkingLotInfo.db");
        }
    }
}
