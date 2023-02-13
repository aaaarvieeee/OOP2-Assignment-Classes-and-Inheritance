using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Assignment_Classes_and_Inheritance
{
    internal class Refrigerator : Appliance
    {
        public int NumberOfDoors { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }

        public Refrigerator(int itemnumber, string brand, int quantity, double wattage, string color, double price, int numberofdoors, double height, double width) : base(itemnumber, brand, quantity, wattage, color, price)
        {
            this.NumberOfDoors = numberofdoors;
            this.Height = height;
            this.Width = width;
        }
        public override string formatForFile()
        {
            return base.formatForFile() + $";{NumberOfDoors};{Height};{Width};";
        }
        public override string ToString()
        {
            return base.ToString() + $"Number of Doors: {NumberOfDoors}\nHeight: {Height}\nWidth: {Width}\n";
        }

    }
}
