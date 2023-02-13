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
            string path = "C:\\Users\\death\\source\\repos\\OOP2-Assignment-Classes-and-Inheritance\\OOP2-Assignment-Classes and Inheritance\\appliances.txt";
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

        public static void Purchase()
        {
            Console.WriteLine("Enter the item number of an appliance:");
            string itemnumUserInput = Console.ReadLine();
            List<int> items = new List<int>();
            foreach (Appliance app in applianceList)
            {
                items.Add(app.ItemNumber);
            }
            if (itemnumUserInput.Contains(Convert.ToString(items)))
            {
                foreach (Appliance app in applianceList)
                if (app.isAvailable() == true)
                    {
                        app.Checkout();
                    }
            }
            else
            {
                Console.WriteLine("No appliances found with that item number");
            }
        }

        public static void EnterBrand()
        {
            Console.WriteLine("Enter brand to search for: ");
            string brandtype = Console.ReadLine();
            Console.WriteLine("Matching Appliances:");
            foreach (Appliance app in applianceList)
            {
                if (app.Brand.IndexOf(brandtype, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    if (app is Refrigerator)
                    {
                        Refrigerator fridge = (Refrigerator)app;
                        Console.WriteLine(fridge.ToString());
                    }
                    else if (app is Microwave)
                    {
                        Microwave micro = (Microwave)app;
                        Console.WriteLine(micro.ToString());
                    }
                    else if (app is Vacuum)
                    {
                        Vacuum vac = (Vacuum)app;
                        Console.WriteLine(vac.ToString());
                    }
                    else if (app is Dishwasher)
                    {
                        Dishwasher dish = (Dishwasher)app;
                        Console.WriteLine(dish.ToString());
                    }
                }
            }
        }

        public static void DisplayByType()
        {
            Console.WriteLine("1- Refrigerators\r\n2-Vacuums\r\n3-Microwaves\r\n4-Dishwashers\r\nEnter type of appliances\r\n");
            string var = Console.ReadLine();
            if (var == "1")
            {
                Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):");
                string door = Console.ReadLine();
                int door1 = int.Parse(door);
                Console.WriteLine("Matching regrigerators: ");
                foreach (Appliance x in applianceList)
                {
                    if(x is Refrigerator)
                    {
                        Refrigerator fridge = (Refrigerator)x;
                        if (door1 == fridge.NumberOfDoors)
                        {
                            Console.WriteLine(fridge.ToString());              
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
                        if(volt1 == vac.Battery)
                        {
                            Console.WriteLine(vac.ToString());
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
                        Microwave microwave = (Microwave)c;
                        if(micro == microwave.RoomType)
                        {
                            Console.WriteLine(microwave.ToString());
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
                        if(dish == wash.SoundRating)
                        {
                            Console.WriteLine(wash.ToString());
                        }
                    }
                }
            }
        }

        public static void RandomApplianceList() 
        {
            Console.WriteLine("Enter number of appliances:");
            string numberOfApplianceUserInput = Console.ReadLine();
            int numberOfAppliances = int.Parse(numberOfApplianceUserInput);
            Random rand = new Random();
            Console.WriteLine("Random appliances:");
            for (int i = 0; i < numberOfAppliances; i++) 
            {
                int randomIndex = rand.Next(applianceList.Count);
                Console.WriteLine(applianceList[randomIndex]);
            }
        }

        public static void WriteFormattedObjectsIntoTextFile()
        {
            List<string> stringApplianceList = new List<string>();
            foreach(Appliance app in applianceList)
            {
                if (app is Refrigerator)
                {
                    Refrigerator fridge = (Refrigerator)app;
                    stringApplianceList.Add(fridge.formatForFile());
                }
                else if (app is Microwave)
                {
                    Microwave micro = (Microwave)app;
                    stringApplianceList.Add(micro.formatForFile());


                }
                else if (app is Vacuum)
                {
                    Vacuum vac = (Vacuum)app;
                    stringApplianceList.Add(vac.formatForFile());

                }
                else if (app is Dishwasher)
                {
                    Dishwasher dish = (Dishwasher)app;
                    stringApplianceList.Add(dish.formatForFile());
                }
            }
            File.WriteAllLines("C:\\Users\\death\\source\\repos\\OOP2-Assignment-Classes-and-Inheritance\\OOP2-Assignment-Classes and Inheritance\\appliances.txt", stringApplianceList);
        }
    }
}