using ParkingSystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Models
{

    // Class to represent a parking slot
    public class ParkingSlot
    {
        public int SlotNumber { get; set; }
        public SlotType Type { get; set; }
    }
}
