using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Assignment_Classes_and_Inheritance
{
    internal class Management
    {
        static List<Appliance> applianceList = new List<Appliance>();
        public static void ReadFromFile()
        {
            string path = "C:\\Users\\death\\Source\\Repos\\OOP2-Assignment-Classes-and-Inheritance\\OOP2-Assignment-Classes and Inheritance\\appliances.txt";
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] fields = line.Split(';');
                int itemNumber = Convert.ToInt32(fields[0]);
                string brand = fields[1];
                int quantity = Convert.ToInt32(fields[2]);
                double wattage = Convert.ToDouble(fields[3]);
                string color = fields[4];
                double price = Convert.ToDouble(fields[5]);
                string itemNumbertoString = Convert.ToString(itemNumber);
                string firstNumber = Convert.ToString(itemNumbertoString[0]);
                if (firstNumber == "1")
                {
                    int numberofDoors = Convert.ToInt32(fields[6]);
                    double height = Convert.ToDouble(fields[7]);
                    double width = Convert.ToDouble(fields[8]);
                    applianceList.Add(new Refrigerator(itemNumber, brand, quantity, wattage, color, price, numberofDoors, height, width));
                }
                else if (firstNumber == "2")
                {
                    int grade = Convert.ToInt32(fields[6]);
                    int battery = Convert.ToInt32(fields[7]);
                    applianceList.Add(new Vacuum(itemNumber, brand, quantity, wattage, color, price, grade, battery));
                }
                else if (firstNumber == "3")
                {
                    double capacity = Convert.ToDouble(fields[6]);
                    string roomtype = fields[7];
                    applianceList.Add(new Microwave(itemNumber, brand, quantity, wattage, color, price, capacity, roomtype));
                }
                else if (firstNumber == "4" || firstNumber == "5")
                {
                    string feature = fields[6];
                    double soundrating = Convert.ToDouble(fields[7]);
                    applianceList.Add(new Dishwasher(itemNumber, brand, quantity, wattage, color, price, feature, soundrating));
                }
            };
            public void Purchase()
            {
                int itemnum = Convert.ToInt32(Console.ReadLine());
                foreach (Appliance x in appliances)
                {
                    if (itemnum == x.ItemNumber)
                    {
                        Console.WriteLine("Appliance {0} has been checked out.", itemnum);
                    }
                    else if (itemnum = !x.ItemNumber)
                    {
                        Console.WriteLine("Applice {0} is not Available", itemnum);
                    }
                }
            }

            public void EnterBrand()
            {
                Console.WriteLine("Enter brand to search for: ");
                string brandtype = Console.ReadLine();
                List<string> brandy = new List<string>();
                foreach (Appliance y in appliances)
                {
                    if (brandtype == y.Brand)
                    {
                        brandy.Add(y);
                        foreach (Appliance z in brandy)
                        {
                            Console.WriteLine("{0}\n {1}\n {2}\n {3}\n {4}\n {5}\n {6}\n {7}\n {8}\n", z);
                        }
                    }

                    else if (brandtype != y.Brand)
                    {
                        Console.WriteLine("This brand does not exist for this product");
                    }
                }

            }

            public void allitem()
            {
                Console.WriteLine("1- Refrigerators\r\n2-Vacuums\r\n3-Microwaves\r\n4-Dishwashers\r\nEnter type of appliances\r\n");
                string var = Console.ReadLine();
                if (var == "1")
                {
                    foreach (Refrigerators a in appliances)
                    {
                        Console.WriteLine(a);
                    }
                }
                else if (var == "2")
                {
                    foreach (Vacuum b in appliances)
                    {
                        Console.WriteLine(b);
                    }
                }
                else if (var == "3")
                {
                    foreach (Microwave b in appliances)
                    {
                        Console.WriteLine(b);
                    }
                }
                else if (var == "4")
                {
                    foreach (Microwave b in appliances)
                    {
                        Console.WriteLine(b);
                    }
                }


            }
        }

}
