﻿using ParkingSystem.Enums;
using ParkingSystem.Interfaces;
using ParkingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Implementations
{
    // Concrete strategy for parking small vehicles
    public class SmallParkingStrategy : IParkingStrategy
    {
        public ParkingSlot ParkVehicle(Dictionary<SlotType, Queue<ParkingSlot>> availableSlots)
        {
            if (availableSlots[SlotType.Small].Count > 0)
            {
                return availableSlots[SlotType.Small].Dequeue();
            }
            return null;
        }
    }
}
