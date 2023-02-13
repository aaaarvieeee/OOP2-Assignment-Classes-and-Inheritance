﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Assignment_Classes_and_Inheritance
{
    internal class Vacuum : Appliance 
    {
        public string Grade { get; set; }
        public int Battery { get; set; }

        public Vacuum(int itemnumber, string brand, int quantity, double wattage, string color, double price, string grade, int battery) : base(itemnumber, brand, quantity, wattage, color, price)
        {
            Grade = grade;
            Battery = battery;
        }
        public override string formatForFile()
        {
            return base.formatForFile() + $";{Grade};{Battery};";
        }
        public override string ToString()
        {
            if (Battery == 18)
            {
                string lowVoltage = "Low";
                return base.ToString() + $"Grade: {Grade}\nBattery: {lowVoltage}\n";
            }
            else
            {
                string highVoltage = "High";
                return base.ToString() + $"Grade: {Grade}\nBattery: {highVoltage}\n";
            }
        }
    }
}
