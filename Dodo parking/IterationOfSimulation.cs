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
                ParkedCar carEntity = null;
                bool isThereFreeSpace = TakenLotsCount.ParkingFillnessStatus(car.CarScale);


                if (isThereFreeSpace)
                {
                    
                    
                    
                    using (ParkingInfoDBContext db = new ParkingInfoDBContext())
                    {
                        var dbConnection = db.ParkingLots;
                        
                        ParkingInfoDBEntity row = dbConnection.FirstOrDefault(a => a.CarScale == car.CarScale && a.ParkingTicketId == "");
                        Ticket ticketInstance = TicketPrinter.Print(row.parkingLotId);
                        carEntity = new ParkedCar(car.CarScale, car.CarNumberPlate, ticketInstance.parkingTicketId, ticketInstance.parkingTimeStarted);
                        row.CarNumberPlate = carEntity.CarNumberPlate;
                        row.WhenParked = carEntity.WhenParked;
                        row.ParkingTicketId = carEntity.ParkingTicketId;

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
