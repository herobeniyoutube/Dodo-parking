using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dodo_parking.DAL
{
    public class TakenLotsCount
    {
        public TakenLotsCount()
        {

        }
        public int Id { get; set; }
        public int Small { get; set; }
        public int Medium { get; set; }
        public int Large { get; set; }
        private static void Change(ParkingInfoDBContext db, string carScale)
        {
            var dbFillnessSheet = db.ParkingLotsScale.ToList();

            switch (carScale)
            {
                case "Small":

                    dbFillnessSheet[0].Small += 1;
                    db.SaveChanges();
                    break;
                case "Medium":

                    dbFillnessSheet[0].Medium += 1;
                    db.SaveChanges();
                    break;
                case "Large":

                    dbFillnessSheet[0].Large += 1;
                    db.SaveChanges();
                    break;
            }
        }
        public static bool ParkingFillnessStatus(string carScale)
        {

            bool hasFreeSpace = false;
            using (ParkingInfoDBContext db = new ParkingInfoDBContext())
            {
                int carsCount = 0;
                int carLimit = 0;
                var dbFillnessSheet = db.ParkingLotsScale;
                ParkingConfigures carsLimitConfig = GetParkingConfigures();
                switch (carScale)
                {
                    case "Small":
                        carsCount = dbFillnessSheet.Sum(o => o.Small);
                        carLimit = carsLimitConfig.SmallCarLotsCount;
                        break;

                    case "Medium":
                        carsCount = dbFillnessSheet.Sum(o => o.Medium);
                        carLimit = carsLimitConfig.MediumCarLotsCount;
                        break;

                    case "Large":
                        carsCount = dbFillnessSheet.Sum(o => o.Large);
                        carLimit = carsLimitConfig.LargeCarLotsCount;
                        break;

                }
                if (carsCount < carLimit)
                {
                    hasFreeSpace = true;
                    //Обновляет статус
                    Change(db, carScale);
                    return hasFreeSpace;


                }
                return hasFreeSpace;
            }
        }
        public static ParkingConfigures GetParkingConfigures()
        {
            ParkingConfigures parkingConfigures;
            if (File.Exists("ParkingConfigures.json"))
            {
                string parkingConfiguresJson = File.ReadAllText("ParkingConfigures.json");
                parkingConfigures = JsonSerializer.Deserialize<ParkingConfigures>(parkingConfiguresJson);

            }
            else
            {
                string jsonDefaultConfigures;
                parkingConfigures = new ParkingConfigures(10, 5, 20);
                jsonDefaultConfigures = JsonSerializer.Serialize(parkingConfigures);
                File.AppendAllText("ParkingConfigures.json", jsonDefaultConfigures);
            }
            return parkingConfigures;
        }


    }
}
