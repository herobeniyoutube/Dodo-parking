using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodo_parking
{
    public class ParkingInfoDBEntity : Car
    {
        public ParkingInfoDBEntity(string carScale, string carNumberPlate, string parkingTicket) : base(carScale, carNumberPlate)
        {
            this.CarScale = carScale;
            this.CarNumberPlate = carNumberPlate;
            this.WhenParked = DateTime.Now;
            this.ParkingTicket = parkingTicket;
            sw.Start();
        }
        Stopwatch sw = new Stopwatch();
        public int Id {  get; set; }
        public bool IsTaken = false;
        public string ParkingTicket { get; set; }
        public bool IsPayed = false;
        public DateTime WhenParked { get; set; }
        

    }
  
}
