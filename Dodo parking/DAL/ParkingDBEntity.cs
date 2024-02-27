using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dodo_parking.PhysicalObjects;

namespace Dodo_parking.DAL
{
    public class ParkingInfoDBEntity : Car
    {
        public ParkingInfoDBEntity(string carScale, string carNumberPlate) : base(carScale, carNumberPlate)
        {

        }
        Stopwatch sw = new Stopwatch();
        public int Id { get; set; }
        public bool IsTaken = false;
        public string ParkingTicketId { get; set; }
        public string parkingLotId { get; set; }
        public bool IsPayed = false;
        public DateTime WhenParked { get; set; }


    }

}
