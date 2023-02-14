using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Assignment_Classes_and_Inheritance
{
    internal class Microwave : Appliance
    {
        public double Capacity { get; set; }
        public string RoomType { get; set; }

        public Microwave(int itemnumber, string brand, int quantity, double wattage, string color, double price, double capacity, string roomtype) : base(itemnumber, brand, quantity, wattage, color, price)
        {
            Capacity = capacity;
            RoomType = roomtype;
        }
        public override string formatForFile()
        {
            return base.formatForFile() + $";{Capacity};{RoomType};";
        }
        // regular ToString() but converts the "K" from the text file into "Kitchen" so the ToString() prints Kitchen instead of "K" and vice versa
        public override string ToString()
        {
            if (RoomType == "K")
            {
                RoomType = "Kitchen";
            }
            else
            {
                RoomType = "Work Site";
            }
            return base.ToString() + $"Capacity: {Capacity}\nRoom Type: {RoomType}\n";
        }
    }
}
