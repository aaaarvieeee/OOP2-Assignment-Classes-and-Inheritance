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

        public static List<Appliance> appliance = new List<Appliance>();
        public Appliance(int itemnumber, string brand, int quantity, double wattage, string color, double price)
        {
            this.ItemNumber = itemnumber;
            this.Brand = brand;
            this.Quantity = quantity;
            this.Wattage = wattage;
            this.Color = color;
            this.Price = price;
        }

        public void Purchase()
        {
            int itemnum = Convert.ToInt32(Console.ReadLine());
            foreach(Appliance x in appliances)
            {
                if (itemnum == x.ItemNumber)
                {
                    Console.WriteLine("Appliance {0} has been checked out.", itemnum);
                }
                else if (itemnum =! x.ItemNumber)
                {
                    Console.WriteLine("Applice {0} is not Available", itemnum);
                }
            }
        }

        public void EnterBrand()
        {
            Console.WriteLine("Enter brand to search for: ");
            string brandtype = Console.ReadLine();
            List<string> brandy  = new List<string>();
            foreach (Appliance y in appliances)
            {
                if(brandtype == y.Brand)
                {
                    brandy.Add(y);
                    foreach(Appliance z in brandy)
                    {
                        Console.WriteLine("{0}\n {1}\n {2}\n {3}\n {4}\n {5}\n {6}\n {7}\n {8}\n",z);
                    }
                }

                else if(brandtype != y.Brand)
                {
                    Console.WriteLine("This brand does not exist for this product")
                }
            }
 
        }

        public void allitem()
        {
            Console.WriteLine("1- Refrigerators\r\n2-Vacuums\r\n3-Microwaves\r\n4-Dishwashers\r\nEnter type of appliances\r\n");
            string var = Console.ReadLine();
            if(var == 1)
            {
                foreach(Refrigerators a in appliances)
                {
                    Console.WriteLine(a);
                }
            }
            else if (var == 2)
            {
                foreach (Vacuum b in appliances)
                {
                    Console.WriteLine(b);
                }
            }


        }
    }
}
