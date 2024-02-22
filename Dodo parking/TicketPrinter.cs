using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodo_parking
{
    public static class TicketPrinter
    {
        public static  string GetNewTicket() 
        { 
        return Guid.NewGuid().ToString();
        }



    }
}
