using ParkingSystem.Enums;
using ParkingSystem.Implementations;
using ParkingSystem.Interfaces;
using ParkingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    // Parking Lot class
    public class ParkingLot
    {
        private Dictionary<VehicleType, IParkingStrategy> parkingStrategies = new Dictionary<VehicleType, IParkingStrategy>
        {
            { VehicleType.Hatchback, new SmallParkingStrategy() },
            { VehicleType.SedanCompactSUV, new MediumParkingStrategy() },
            { VehicleType.SUVLarge, new LargeParkingStrategy() }
        };

        private Dictionary<SlotType, Queue<ParkingSlot>> availableSlots = new Dictionary<SlotType, Queue<ParkingSlot>>()
        {
            { SlotType.Small, new Queue<ParkingSlot>() },
            { SlotType.Medium, new Queue<ParkingSlot>() },
            { SlotType.Large, new Queue<ParkingSlot>() }
        };

        private Dictionary<int, VehicleType> occupiedSlots = new Dictionary<int, VehicleType>();

        public ParkingLot()
        {
            InitializeSlots();
        }

        private void InitializeSlots()
        {
            for (int i = 1; i <= 50; i++)
            {
                availableSlots[SlotType.Small].Enqueue(new ParkingSlot { SlotNumber = i, Type = SlotType.Small });
            }

            for (int i = 51; i <= 80; i++)
            {
                availableSlots[SlotType.Medium].Enqueue(new ParkingSlot { SlotNumber = i, Type = SlotType.Medium });
            }

            for (int i = 81; i <= 100; i++)
            {
                availableSlots[SlotType.Large].Enqueue(new ParkingSlot { SlotNumber = i, Type = SlotType.Large });
            }
        }

        public void ParkVehicle(VehicleType vehicleType)
        {
            if (parkingStrategies.ContainsKey(vehicleType))
            {
                IParkingStrategy parkingStrategy = parkingStrategies[vehicleType];
                ParkingSlot slot = parkingStrategy.ParkVehicle(availableSlots);

                if (slot != null)
                {
                    occupiedSlots[slot.SlotNumber] = vehicleType;
                    Console.WriteLine($"Vehicle parked at {slot.Type} slot {slot.SlotNumber}");
                }
                else
                {
                    Console.WriteLine("No available slots for the given vehicle type");
                }
            }
            else
            {
                Console.WriteLine("Invalid vehicle type");
            }
        }

        public void LeaveParking(int slotNumber)
        {
            if (occupiedSlots.ContainsKey(slotNumber))
            {
                VehicleType vehicleType = occupiedSlots[slotNumber];
                SlotType slotType = GetSlotType(vehicleType);

                availableSlots[slotType].Enqueue(new ParkingSlot { SlotNumber = slotNumber, Type = slotType });
                occupiedSlots.Remove(slotNumber);

                Console.WriteLine($"Vehicle left from slot {slotNumber}");
            }
            else
            {
                Console.WriteLine("Invalid slot number");
            }
        }

        private SlotType GetSlotType(VehicleType vehicleType)
        {
            switch (vehicleType)
            {
                case VehicleType.Hatchback:
                    return SlotType.Small;
                case VehicleType.SedanCompactSUV:
                    return SlotType.Medium;
                case VehicleType.SUVLarge:
                    return SlotType.Large;
                default:
                    return SlotType.Small;
            }
        }
    }
}
