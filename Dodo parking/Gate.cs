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
        public static void Open()
        {
            Console.WriteLine("Шлагбаум открыт");
            //Thread.Sleep(1000);
            Close();
        }
        private static void Close() { Console.WriteLine(); }
        public static void GateOpener(CarDirection carDirection, bool hasFreeSpace, string carScale)
        {
            if (carDirection == CarDirection.enter)
            {
                
            }
            else
            {
                Console.WriteLine($"На парковке нет места для {carScale} машин");
            }







            if (carDirection == CarDirection.leave)
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
