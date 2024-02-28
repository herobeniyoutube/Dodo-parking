using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dodo_parking.DAL;

namespace Dodo_parking.BL
{
    public class ParkedCar : ParkingInfoDBEntity
    {
        public ParkedCar(string carScale, string carNumberPlate, string parkingTicket, DateTime timeArrived) : base(carScale, carNumberPlate)
        {
            CarScale = carScale;
            CarNumberPlate = carNumberPlate;
            WhenParked = timeArrived;
            ParkingTicketId = parkingTicket;
        }

        public int Id { get; set; }
        public string ParkingTicketId { get; set; }
        public string ParkingLotId { get; set; }
        public DateTime WhenParked { get; set; }
    }

}



