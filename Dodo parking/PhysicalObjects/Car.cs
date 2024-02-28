using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Dodo_parking.PhysicalObjects
{
    public class Car
    {
        public Car(string carScale, string carNumberPlate)
        {
            CarScale = carScale;
            CarNumberPlate = carNumberPlate;
        }

        public string CarScale { get; set; }
        public string CarNumberPlate { get; set; }
    }
}
