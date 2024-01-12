using ParkingSystem.Enums;
using ParkingSystem.Interfaces;
using ParkingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Implementations
{
    // Concrete strategy for parking large vehicles
    public class LargeParkingStrategy : IParkingStrategy
    {
        public ParkingSlot ParkVehicle(Dictionary<SlotType, Queue<ParkingSlot>> availableSlots)
        {
            if (availableSlots[SlotType.Large].Count > 0)
            {
                return availableSlots[SlotType.Large].Dequeue();
            }
            return null;
        }
    }
}
