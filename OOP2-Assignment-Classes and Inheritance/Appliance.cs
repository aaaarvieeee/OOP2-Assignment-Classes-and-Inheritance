using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Assignment_Classes_and_Inheritance
{
    internal class Appliance
    {
        // getters and setters for the properties of the appliances
        public int ItemNumber { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public double Wattage { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }

        // constructor which will be inherited by the child classes: Microwave, Dishwasher, Vacuum, and Refrigerator.
        // uses the attributes as a parameter, each child class has additional parameters added due to their other attributes that are only
        // addressed in their own respective classes.
        public Appliance(int itemnumber, string brand, int quantity, double wattage, string color, double price)
        {
            ItemNumber = itemnumber;
            Brand = brand;
            Quantity = quantity;
            Wattage = wattage;
            Color = color;
            Price = price;
        }

        // Checks if the appliance is available by using the appliance's quantity as a condition and returns true if its greater than 0 and false if it;s 0
        public bool isAvailable()
        {
            if (Quantity > 0)
            {
                return true;
            }
            else
            {
                return false; 
            }
        }

        //Decrements the Quantity by 1 and prints a line that indicates that the appliance has been checked out
        public void Checkout()
        {
            int newQuantity = Quantity - 1;
            Quantity = newQuantity;
            Console.WriteLine($"Appliance \"{ItemNumber}\" has been checked out.");
        }

        //formats the attributes by adding ";" in between each one into a string
        public virtual string formatForFile()
        {
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price}";
        }
        public override string ToString()
        {
            return $"Item Number {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColor: {Color}\nPrice: {Price}\n";
        }
    }
}
