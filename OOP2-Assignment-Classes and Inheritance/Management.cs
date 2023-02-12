using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Assignment_Classes_and_Inheritance
{
    internal class Management
    {
        public static List<Appliance> applianceList = new List<Appliance>();
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
                    string grade = fields[6];
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
                    string soundrating = fields[7];
                    applianceList.Add(new Dishwasher(itemNumber, brand, quantity, wattage, color, price, feature, soundrating));
                }
            }
        }

        public virtual void Purchase()
        {
            Console.WriteLine("Enter the item number of an appliance:");
            string itemnum = Console.ReadLine();
            int itemnum1 = int.Parse(itemnum);
            List<int> items = new List<int>();
            foreach (Appliance x in applianceList)
            {
                items.Add(x.ItemNumber);
            }
            if (items.Contains(itemnum1))
            {
                Console.WriteLine("Appliance {0} has been checked out.", itemnum1);
            }
            else
            {
                Console.WriteLine("The appliance is not available to be checked out.");
            }
        }

        public void EnterBrand()
        {
            Console.WriteLine("Enter brand to search for: ");
            string brandtype = Console.ReadLine();
            List<Appliance> brandy = new List<Appliance>();
            Console.WriteLine("Matching Appliances:");
            foreach (Appliance y in applianceList)
            {
                if (brandtype == y.Brand)
                {
                    brandy.Add(y);
                    foreach(Appliance z in brandy)
                    {
                        if (z is Refrigerator)
                        {
                            Refrigerator fridge = (Refrigerator)z;
                            Console.WriteLine("ItemNumber: {0}\n Brand: {1}\n Quantity: {2}\n Wattage: {3}\n Color: {4}\n Price: {5}\n NumberOfDoors: {6}\n Height: {7}\n Width: {8} ", fridge.ItemNumber, fridge.Brand, fridge.Quantity, fridge.Wattage, fridge.Color, fridge.Price, fridge.NumberOfDoors, fridge.Height, fridge.Width);
                        }
                        else if (z is Microwave)
                        {
                            Microwave micro = (Microwave)z;
                            Console.WriteLine("ItemNumber: {0}\n Brand: {1}\n Quantity: {2}\n Wattage: {3}\n Color: {4}\n Price: {5}\n Capacity: {6}\n RoomType: {7} ", micro.ItemNumber, micro.Brand, micro.Quantity, micro.Wattage, micro.Color, micro.Price, micro.Capacity, micro.RoomType);
                        }
                        else if (z is Vacuum)
                        {
                            Vacuum vac = (Vacuum)z;
                            Console.WriteLine("ItemNumber: {0}\n Brand: {1}\n Quantity: {2}\n Wattage: {3}\n Color: {4}\n Price: {5}\n Grade: {6}\n BatteryType: {7} ", vac.ItemNumber, vac.Brand, vac.Quantity, vac.Wattage, vac.Color, vac.Color, vac.Price, vac.Grade, vac.Battery);
                        }
                        else if (z is Dishwasher)
                        {
                            Dishwasher dish = (Dishwasher)z;
                            Console.WriteLine("ItemNumber: {0}\n Brand: {1}\n Quantity: {2}\n Wattage: {3}\n Color: {4}\n Price: {5}\n Grade: {6}\n BatteryType: {7} ", dish.ItemNumber, dish.Brand, dish.Quantity, dish.Wattage, dish.Color, dish.Color, dish.Price, dish.Feature, dish.SoundRating);
                        }

                    }
                }
            }

        }

        public void allitem()
        {
            Console.WriteLine("1- Refrigerators\r\n2-Vacuums\r\n3-Microwaves\r\n4-Dishwashers\r\nEnter type of appliances\r\n");
            string var = Console.ReadLine();
            if (var == "1")
            {
                Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):");
                string door = Console.ReadLine();
                int door1 = int.Parse(door);
                foreach (Appliance x in applianceList)
                {
                    if(x is Refrigerator)
                    {
                        Refrigerator fridge = (Refrigerator)x;
                        List<Refrigerator> list1 = new List<Refrigerator>();
                        Console.WriteLine("Matching regrigerators: ");
                        if (door1 == fridge.NumberOfDoors)
                        {
                            list1.Add(fridge);
                            foreach (var y in list1)
                            {
                                Console.WriteLine("ItemNumber: {0}\n Brand: {1}\n Quantity: {2}\n Wattage: {3}\n Color: {4}\n Price: {5}\n NumberOfDoors: {6}\n Height: {7}\n Width: {8} ", y.ItemNumber, y.Brand, y.Quantity, y.Wattage, y.Color, y.Price, y.NumberOfDoors, y.Height, y.Width);
                            }                      
                        }      
                    }
                }
            }
            else if (var == "2")
            {
                Console.WriteLine("Enter battery voltage value. 18 V (low) or 24 V (high)");
                string volt = Console.ReadLine();
                int volt1 = int.Parse(volt);
                Console.WriteLine("Matching vacuums:");
                foreach (Appliance b in applianceList)
                {
                    if(b is Vacuum)
                    {
                        Vacuum vac = (Vacuum)b;
                        List<Vacuum> list2 = new List<Vacuum>();
                        if(volt1 == vac.Battery)
                        {
                            list2.Add(vac);
                            foreach(var y in list2)
                            {
                                Console.WriteLine("ItemNumber: {0}\n Brand: {1}\n Quantity: {2}\n Wattage: {3}\n Color: {4}\n Price: {5}\n Grade: {6}\n BatteryType: {7} ", y.ItemNumber, y.Brand, y.Quantity, y.Wattage, y.Color, y.Price, y.Grade, y.Battery);
                            }
                        }
                    }
                }
            }
            else if (var == "3")
            {
                Console.WriteLine("RoomWhere the microwave will be installed: K (kitchen) or W (work site):");
                string micro = Console.ReadLine();
                Console.WriteLine("Matching microwave:");
                foreach (Appliance c in applianceList)
                {
                    if(c is Microwave)
                    {
                        Microwave mac = (Microwave)c;
                        List<Microwave> list3 = new List<Microwave>();
                        if(micro == mac.RoomType)
                        {
                            list3.Add(mac);
                            foreach (var y in list3)
                            {
                                Console.WriteLine("ItemNumber: {0}\n Brand: {1}\n Quantity: {2}\n Wattage: {3}\n Color: {4}\n Price: {5}\n Capacity: {6}\n Room Type: {7} ", y.ItemNumber, y.Brand, y.Quantity, y.Wattage, y.Color, y.Price, y.Capacity, y.RoomType);
                            }
                        }
                    }
                }
            }
            else if (var == "4")
            {
                Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):");
                string dish = Console.ReadLine();
                Console.WriteLine("Matching dishwasher: ");
                foreach(Appliance d in applianceList)
                {
                    if(d is Dishwasher)
                    {
                        Dishwasher wash = (Dishwasher)d;
                        List<Dishwasher> list4 = new List<Dishwasher>();
                        if(dish == wash.SoundRating)
                        {
                            list4.Add(wash);
                            foreach(var y in list4)
                            {
                                Console.WriteLine("ItemNumber: {0}\n Brand: {1}\n Quantity: {2}\n Wattage: {3}\n Color: {4}\n Price: {5}\n Feature: {6}\n Sound Rating: {7} ", y.ItemNumber, y.Brand, y.Quantity, y.Wattage, y.Color, y.Price, y.Feature, y.SoundRating);
                            }
                        }
                    }
                }

            }


        }


    }
}