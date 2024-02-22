using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodo_parking
{
    public static class updateDB
    {
        public static void DBUpdater()
        {
            using (ParkingInfoDBContext db = new ParkingInfoDBContext())
            {

                var carEntity = Camera.CarEntering();
                if (carEntity != null)
                {
                    db.ParkingLots.Add(carEntity);
                    db.SaveChanges();
                    Console.WriteLine($"Машина {carEntity.CarScale} добавлена в базу");
                }
            }
        }
    }
}
