using Dodo_parking;
using System;
using System.Diagnostics;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine();

        for (int i = 0; i < 30; i++)
        {
            IterationOfSimulation.Run();
        }
        Console.WriteLine();
    }
}

