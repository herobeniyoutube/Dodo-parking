using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dodo_parking.PhysicalObjects
{
    public static class Camera
    {
        //возвращает экземпляр машины, которая стоит на въезде

        public static Car GetCarInstance()
        {
            var car = GetRandomCarInstance();
            Console.WriteLine($"Перед шлагбауном стоит машина размера {car.CarScale} с номером {car.CarNumberPlate}");

            return car;
        }

        private static Car GetRandomCarInstance()
        {
            Random rn = new Random();
            var value = rn.Next(1, 4);
            string carScale = "";
            string carNumberPlate = Guid.NewGuid().ToString().Substring(0, 8);
            Car car;

            switch (value)
            {
                case 1:
                    carScale = "Small";
                    break;
                case 2:
                    carScale = "Medium";
                    break;
                case 3:
                    carScale = "Large";
                    break;

            }
            car = new Car(carScale, carNumberPlate);
            return car;
        }
        public static bool CarsAtFrontMonitoring()
        {
            while (true)
            {
                Thread.Sleep(1000);
                return true;
            }

        }


    }
}
