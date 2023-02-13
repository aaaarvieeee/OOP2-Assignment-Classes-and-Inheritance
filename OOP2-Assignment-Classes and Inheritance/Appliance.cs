using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Assignment_Classes_and_Inheritance
{
    internal class Appliance
    {
        public int ItemNumber { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public double Wattage { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }

        public Appliance(int itemnumber, string brand, int quantity, double wattage, string color, double price)
        {
            ItemNumber = itemnumber;
            Brand = brand;
            Quantity = quantity;
            Wattage = wattage;
            Color = color;
            Price = price;
        }

        public bool isAvailable()
        {
            if (Quantity > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("The appliance is not available to be checked out.");
                return false; 
            }
        }
        public void Checkout()
        {
            int newQuantity = Quantity - 1;
            Quantity = newQuantity;
            Console.WriteLine($"Appliance \"{ItemNumber}\" has been checked out.");
        }

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
