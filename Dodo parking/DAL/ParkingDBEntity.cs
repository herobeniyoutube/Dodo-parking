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
        public ParkingInfoDBEntity(string carScale, string carNumberPlate) : base(carScale, carNumberPlate) { }

        public int Id { get; set; }
        public string ParkingTicketId { get; set; }
        public string ParkingLotId { get; set; }
        public DateTime WhenParked { get; set; }
    }

}
