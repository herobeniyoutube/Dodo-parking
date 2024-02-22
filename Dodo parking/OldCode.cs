using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class ParkingLotsInfo
{
    private static ParkingLotsInfo ParkingLotsInfoInstance = null;
    public List<bool> largeLotsInfo = new List<bool>();
    public List<bool> mediumLotsInfo = new List<bool>();
    public List<bool> smallLotsInfo = new List<bool>();
    private ParkingLotsInfo(int largeLotsQuantity, int smallLotsQuantity, int mediumLotsQuantity)
    {
        for (int i = 0; i < smallLotsQuantity; i++)
        {
            smallLotsInfo.Add(true);
        }
        for (int i = 0; i < mediumLotsQuantity; i++)
        {
            mediumLotsInfo.Add(true);
        }
        for (int i = 0; i < largeLotsQuantity; i++)
        {
            largeLotsInfo.Add(true);
        }
    }
    public static ParkingLotsInfo GetParkingLotsInfoInstance(int largeLotsQuantity, int mediumLotsQuantity, int smallLotsQuantity)
    {
        if (ParkingLotsInfoInstance == null)
        {
            ParkingLotsInfoInstance = new ParkingLotsInfo(largeLotsQuantity, smallLotsQuantity, mediumLotsQuantity);
        }
        return ParkingLotsInfoInstance;
    }
    public string GetParkingTicket(carScale carScale)
    {
        int ticketID = -1;
        int index = 0;
        switch (carScale)
        {
            case carScale.S:

                foreach (bool ParkingLot in smallLotsInfo)
                {
                    if (ParkingLot)
                    {
                        ticketID = index;
                        smallLotsInfo[index] = false;
                        return $"S{ticketID}";

                    }
                }
                return $"Full";

            case carScale.M:

                foreach (bool ParkingLot in mediumLotsInfo)
                {
                    if (ParkingLot)
                    {
                        ticketID = index;
                        mediumLotsInfo[index] = false;
                        return $"M{ticketID}";

                    }
                }
                return $"Full";

            case carScale.L:

                foreach (bool ParkingLot in largeLotsInfo)
                {
                    if (ParkingLot)
                    {
                        ticketID = index;
                        largeLotsInfo[index] = false;
                        return $"L{ticketID}";

                    }
                }
                return $"Full";


            default:
                //нет мест
                return $"Full";

        }





    }
    public void ReturningParkingTicket(string lotID)
    {
        switch (lotID[0])
        {
            case 'S':
                smallLotsInfo[(int)lotID[1]] = true;
                break;
            case 'M':
                mediumLotsInfo[(int)lotID[1]] = true;
                break;
            case 'L':
                mediumLotsInfo[(int)lotID[1]] = true;
                break;
            default:
                break;
        }
    }
    public enum carScale
    {
        S,
        M,
        L
    }
}


