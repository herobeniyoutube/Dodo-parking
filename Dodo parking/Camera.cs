using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodo_parking
{
    public class Camera
    {
        //возвращает экземпляр машины, которая стоит на въезде
        public static ParkingInfoDBEntity CarEntering()
        {
            return RandomCar();
        }
        private static ParkingInfoDBEntity RandomCar()
        {
            Random rn = new Random();
            var value = rn.Next(1, 4);
            
            string newCarScale = "";

            string newCarNumberPlate = Guid.NewGuid().ToString().Substring(0, 8);
            bool hasFreeSpace = false;
            ParkingInfoDBEntity carEntity = null;
            string parkingTicket;
            

            using (ParkingInfoDBContext db = new ParkingInfoDBContext())
            {
                switch (value)
                {
                    case 1:
                        newCarScale = "Small";
                        hasFreeSpace = TakenLotsForEachCarScale.ParkingFillnessStatus(newCarScale);
                        break;
                    case 2:
                        newCarScale = "Medium";
                        hasFreeSpace = TakenLotsForEachCarScale.ParkingFillnessStatus(newCarScale);
                        break;
                    case 3:
                        newCarScale = "Large";
                        hasFreeSpace = TakenLotsForEachCarScale.ParkingFillnessStatus(newCarScale);
                        break;

                }
            }
            Console.WriteLine($"Перед шлагбауном стоит машина размера {newCarScale} с номером {newCarNumberPlate}");

            
            if ( hasFreeSpace )
            {
                parkingTicket = TicketPrinter.GetNewTicket();
                Gate.GateOpener(CarDirection.enter, hasFreeSpace, newCarScale);
                carEntity = new ParkingInfoDBEntity(newCarScale, newCarNumberPlate, parkingTicket);
            }
            else
            {
                Gate.GateOpener(CarDirection.enter, hasFreeSpace, newCarScale);
            }
            
            
            


                


            return carEntity;
        }
    }
}
