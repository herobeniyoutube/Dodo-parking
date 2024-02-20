using Dodo_parking;
using System;
using System.Diagnostics;

class Program
{
    public static void Main(string[] args)
    {
        //ParkingLotsInfo parkingLotsInfo = ParkingLotsInfo.GetParkingLotsInfoInstance(5, 11, 23);

        // string parkingTicket = parkingLotsInfo.GetParkingTicket(ParkingLotsInfo.carScale.M);
        //parkingLotsInfo.ReturningParkingTicket(parkingTicket);



        Console.WriteLine();
        
            for (int i = 0; i < 30; i++) 
        {
            updateDB.DBUpdater(); 
            Console.WriteLine();
        }

            
        
        Console.WriteLine();
    }
    
     
     

    

}

