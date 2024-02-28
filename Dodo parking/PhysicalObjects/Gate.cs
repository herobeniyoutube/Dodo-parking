using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace Dodo_parking.PhysicalObjects
{
    public static class Gate
    {
        public static void Open()
        {
            Console.WriteLine("Шлагбаум открыт");
            //Thread.Sleep(1000);
            Gate.Close();
            Console.WriteLine();
        }

        private static void Close() { Console.WriteLine("Шлагбаум закрыт"); }
    }
}
