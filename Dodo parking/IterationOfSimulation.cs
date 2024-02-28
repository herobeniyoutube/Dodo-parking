using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dodo_parking.BL;
using Dodo_parking.DAL;
using Dodo_parking.PhysicalObjects;

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
                bool isThereFreeSpace = TakenLotsCount.ParkingFillnessStatus(car.CarScale);

                if (isThereFreeSpace)
                {
                    using (ParkingInfoDBContext db = new ParkingInfoDBContext())
                    {
                        var dbConnection = db.ParkingLots;

                        ParkingInfoDBEntity dbRow = dbConnection.FirstOrDefault(a => a.CarScale == car.CarScale && a.ParkingTicketId == "");
                        Ticket ticketInstance = TicketPrinter.Print(dbRow.ParkingLotId);
                        ParkedCar carEntity = new ParkedCar(car.CarScale, car.CarNumberPlate, ticketInstance.ParkingTicketId, ticketInstance.ParkingTimeStarted);

                        dbRow.CarNumberPlate = carEntity.CarNumberPlate;
                        dbRow.WhenParked = carEntity.WhenParked;
                        dbRow.ParkingTicketId = carEntity.ParkingTicketId;

                        db.SaveChanges();
                        Gate.Open();
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
