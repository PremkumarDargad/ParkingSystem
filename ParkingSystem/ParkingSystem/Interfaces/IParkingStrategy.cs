using ParkingSystem.Enums;
using ParkingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Interfaces
{
    public interface IParkingStrategy
    {
        ParkingSlot ParkVehicle(Dictionary<SlotType, Queue<ParkingSlot>> availableSlots);
    }
}
