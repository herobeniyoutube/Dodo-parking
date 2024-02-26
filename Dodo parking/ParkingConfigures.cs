using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodo_parking
{
    public class ParkingConfigures
    {
        public ParkingConfigures() { }
        public ParkingConfigures(int mediumCarLotsCount, int largeCarLotsCount, int smallCarLotsCount)
        {
            MediumCarLotsCount = mediumCarLotsCount;
            LargeCarLotsCount = largeCarLotsCount;
            SmallCarLotsCount = smallCarLotsCount;
        }
        public int SmallCarLotsCount { get; set; }
        public int MediumCarLotsCount { get; set; }
        public int LargeCarLotsCount { get; set; }
    }
}
