using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodo_parking.PhysicalObjects
{
    public static class TicketPrinter
    {
        public static Ticket Print(string lotId)
        {
            string ticketId = Guid.NewGuid().ToString();
            var ticketInstance = new Ticket(lotId, ticketId);
            Console.WriteLine($"Билет на место {lotId} выдан");
            return ticketInstance;
        }
    }
}
