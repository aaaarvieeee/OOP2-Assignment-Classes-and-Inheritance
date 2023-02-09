using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Assignment_Classes_and_Inheritance
{
    internal class Vacuum : Appliance 
    {
        public int Grade { get; set; }
        public int Battery { get; set; }
        public int Voltage { get; set; }

        public Vacuum(int itemnumber, string brand, int quantity, double wattage, string color, double price, int grade, int battery, int voltage ) : base(itemnumber, brand, quantity, wattage, color, price)
        {
            this.Grade = grade;
            this.Battery = battery;
            this.Voltage = voltage;
        }
    }
}
