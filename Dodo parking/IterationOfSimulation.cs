using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodo_parking
{
    public static class IterationOfSimulation
    {
        public static void Run()
        {
            //камера смотрит на прибывшие машины
            bool isThereACarInFrontOfTheCamera = Camera.CarsAtFrontMonitoring();
            //камера получила параметры машины

            if (isThereACarInFrontOfTheCamera)
            {
                Car car = Camera.GetCarInstance();
                ParkingInfoDBEntity carEntity = null;
                bool isThereFreeSpace = TakenLotsCount.ParkingFillnessStatus(car.CarScale);


                if (isThereFreeSpace)
                {
                    string ticket = TicketPrinter.Print();
                    Gate.Open();
                    carEntity = new ParkingInfoDBEntity(car.CarScale, car.CarNumberPlate, ticket);
                    using (ParkingInfoDBContext db = new ParkingInfoDBContext())
                    {
                        db.ParkingLots.Add(carEntity);
                        db.SaveChanges();
                        Console.WriteLine($"Машина {carEntity.CarScale} добавлена в базу");
                    }
                }
                else
                {
                    Console.WriteLine($"На парковке недостаточно мест {car.CarScale} размера");
                }





            }
            Console.WriteLine();
        }
    }
}
