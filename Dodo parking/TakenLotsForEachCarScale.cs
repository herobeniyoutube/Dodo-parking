using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodo_parking
{
    public class TakenLotsForEachCarScale
    {
        public TakenLotsForEachCarScale(int small, int medium, int large) 
        
        {
            this.Small = small;
            this.Large = large;
            this.Medium = medium;

        }
        public int Id { get; set; }
        public int Small {  get; set; }
        public int Medium { get; set; }
        public int Large { get; set; }
        internal static bool IsEntityCreated()
        {
            int count;
            using (ParkingInfoDBContext db = new ParkingInfoDBContext())
            {
                var list = db.ParkingLotsScale.Count();
                count = list;
                if (count == 0)
                {
                    db.ParkingLotsScale.Add(new TakenLotsForEachCarScale(0, 0, 0));
                    db.SaveChanges();
                }
            }
            return true;
        }
        public static bool ParkingFillnessStatus(string carScale)
        {
            IsEntityCreated();
            bool hasFreeSpace = false;
            using (ParkingInfoDBContext db = new ParkingInfoDBContext())
            {
                int carsCount = 0;
                var dbFillnessSheet = db.ParkingLotsScale;
                switch (carScale)
                {
                    case "Small":
                        carsCount = dbFillnessSheet.Sum(o => o.Small);    
                        if (carsCount < 20)
                        {
                            hasFreeSpace = true;
                            return hasFreeSpace;
                        }

                        break;
                    case "Medium":
                        carsCount = dbFillnessSheet.Sum(o => o.Medium);
                        if (carsCount < 10)
                        {
                            hasFreeSpace = true;
                            return hasFreeSpace;
                        }

                        break;
                    case "Large":
                        carsCount = dbFillnessSheet.Sum(o => o.Large);
                        if (carsCount < 5)
                        {
                            hasFreeSpace = true;
                            return hasFreeSpace;
                        }

                        break;

                }
                return hasFreeSpace;
            }
        }
    }
}
