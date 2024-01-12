using ParkingSystem;
using ParkingSystem.Enums;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        ParkingLot parkingLot = new ParkingLot();

        //// Test parking
        //parkingLot.ParkVehicle(VehicleType.Hatchback);
        //parkingLot.ParkVehicle(VehicleType.SedanCompactSUV);

        //// Test leaving parking
        //parkingLot.LeaveParking(1);
        //parkingLot.LeaveParking(51);

        while (true)
        {
            Console.WriteLine("Choose operation:\n1. Park Vehicle\n2. Leave Parking\n3. Exit");
            int choice, slotNumber;
            VehicleType vehicleType;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the type of vehicle (Hatchback, SedanCompactSUV, SUVLarge): ");
                        Enum.TryParse(Console.ReadLine(),  out vehicleType);
                        parkingLot.ParkVehicle(vehicleType);
                        break;
                    case 2:
                        Console.WriteLine("Enter the slot number to leave: ");
                        int.TryParse(Console.ReadLine(), out slotNumber);
                        parkingLot.LeaveParking(slotNumber);
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
        }
}
