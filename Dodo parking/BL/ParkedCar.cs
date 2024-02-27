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
            sw.Start();
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



