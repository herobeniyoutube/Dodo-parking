using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Dodo_parking
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
    public class NewCarArrived : Car
    {
         public NewCarArrived(string carScale, string carNumberPlate) : base(carScale, carNumberPlate)
        {
            this.CarScale = carScale;
            this.CarNumberPlate = carNumberPlate;
             
             
        }
     
        
    }
}
