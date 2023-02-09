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
            this.Capacity = capacity;
            this.RoomType = roomtype;
        }
    }
}
