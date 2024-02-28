using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodo_parking.PhysicalObjects
{
    public class Ticket
    {
        public Ticket(string lotId, string parkingTicketId)
        {
            this.LotId = lotId;
            this.ParkingTicketId = parkingTicketId;
            ParkingTimeStarted = DateTime.Now;
        }

        public string LotId { get; set; }
        public DateTime ParkingTimeStarted { get; set; }
        public string ParkingTicketId { get; set; }
    }
}
