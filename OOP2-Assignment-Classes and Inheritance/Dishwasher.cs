using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Assignment_Classes_and_Inheritance
{
    internal class Dishwasher : Appliance
    {
        public string Feature { get; set; }
        public string SoundRating { get; set; }

        public Dishwasher(int itemnumber, string brand, int quantity, double wattage, string color, double price, string feature, string soundrating) : base(itemnumber, brand, quantity, wattage, color, price)
        { 
            Feature = feature;
            SoundRating = soundrating;

        }
        public override string formatForFile()
        {
            return base.formatForFile() + $";{Feature};{SoundRating};";
        }
        public override string ToString()
        {
            if (SoundRating == "Qt")
            {
                SoundRating = "Quietest";
            }
            else if (SoundRating == "Qr")
            {
                SoundRating = "Quieter";
            }
            else if (SoundRating == "Qu")
            {
                SoundRating = "Quiet";
            }
            else
            {
                SoundRating = "Moderate";
            }
            return base.ToString() + $"Feature: {Feature}\nSound Rating: {SoundRating}\n";
        }

    }
}

