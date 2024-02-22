using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace Dodo_parking
{
    public static class Gate
    {
        private static bool IsOpened = false;

        public static void GateOpener(CarDirection carDirection, bool hasFreeSpace, string carScale)
        {
            if (carDirection == CarDirection.enter)
            {
                if (hasFreeSpace)
                {
                    using (ParkingInfoDBContext db = new ParkingInfoDBContext())
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

                        Console.WriteLine("Шлагбаум открыт");




                    }
                }
                else
                {
                    Console.WriteLine($"На парковке нет места для {carScale} машин");
                }

                    
               



            }
            else if (carDirection == CarDirection.leave)
            {
                //if else проверить оплачена ли парковка если да открыть если нет, писать в консоль, что машина заблокировала проход
            }

        }
    }
    public enum CarDirection
    {
        enter,
        leave
    }

}
