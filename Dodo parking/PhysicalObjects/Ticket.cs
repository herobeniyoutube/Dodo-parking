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
            this.lotId = lotId;
            this.parkingTicketId = parkingTicketId;
            parkingTimeStarted = DateTime.Now;
        }

        public string lotId { get; set; }
        public DateTime parkingTimeStarted { get; set; }
        public string parkingTicketId { get; set; }
    }
}
