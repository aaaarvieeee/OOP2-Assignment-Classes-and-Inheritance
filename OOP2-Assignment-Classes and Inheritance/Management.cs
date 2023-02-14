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
        // All the appliance objects are stored in this list
        public static List<Appliance> applianceList = new List<Appliance>();

        // Reads from the appliances.txt file and adds it to an array. Then splits each line at every instance of ";" in the array. 
        public static void ReadFromFile()
        {
            string path = "C:\\Users\\death\\source\\repos\\OOP2-Assignment-Classes-and-Inheritance\\OOP2-Assignment-Classes and Inheritance\\appliances.txt";
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                //each field of each line is assigned a variable that is consistent with the Appliance class constructor.
                string[] fields = line.Split(';');
                int itemNumber = Convert.ToInt32(fields[0]);
                string brand = fields[1];
                int quantity = Convert.ToInt32(fields[2]);
                double wattage = Convert.ToDouble(fields[3]);
                string color = fields[4];
                double price = Convert.ToDouble(fields[5]);
                string itemNumbertoString = Convert.ToString(itemNumber);
                string firstNumber = Convert.ToString(itemNumbertoString[0]);
                //checks the first number of the item number to determine the class of object each appliance should fall under and calls their constructor and adds their other properties
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

        // Relies on user input, checks if the user input matches any of the item numbers in the applianceList. Uses a foreeach loop to read each
        // object in the list and checks if the item number and user input match AND if it is available. If it does, it calls the Checkout() method.
        // If it is not available but the numbers match, it tells the user that the appliance isn't available to be checked out.
        // the loop also adds each input number into a list. Uses an if statement to check if the users input does NOT match any of the item numbers
        // in the list and indicates that it doesn't match
        public static void Purchase()
        {
            Console.WriteLine("Enter the item number of an appliance:");
            string itemnumUserInput = Console.ReadLine();
            List<string> inputCheck = new List<string>();
            foreach (Appliance app in applianceList)
            {
                inputCheck.Add(Convert.ToString(app.ItemNumber));
                if (app.isAvailable() == true && itemnumUserInput.Contains(Convert.ToString(app.ItemNumber)))
                {
                    app.Checkout();
                }
                else if (app.isAvailable() == false && itemnumUserInput.Contains(Convert.ToString(app.ItemNumber)))
                {
                    Console.WriteLine("The appliance is not available to be checked out.");
                }
            }
            if (!inputCheck.Contains(itemnumUserInput))
            {
                Console.WriteLine("No appliances found with that item number.");
            }
        }

        //takes a user input and checks if it is in the Brand attribute of each object. User input is case insensitive. Uses ToString to print the appliance when the conditions are met.
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

        //User decides which type of appliance they want to display by number. When the user inputs for Refrigerators, asks for the number of doors and prints the
        //refrigerators that match the amount of doors. If Vacuums are chosen, it asks for the voltage of the vacuum and prints only the ones that have the same voltage.
        // If microwaves are chosen, it asks where it will be installed and prints the ones with the same places. If dishwashers are chosen, it asks what the sound level is and
        // prints only the ones with the same sound level indicated by the user.
        public static void DisplayByType()
        {
            Console.WriteLine("1 - Refrigerators\r\n2 - Vacuums\r\n3 - Microwaves\r\n4 - Dishwashers\r\nEnter type of appliance:\r\n");
            string var = Console.ReadLine();
            if (var == "1")
            {
                Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):");
                string door = Console.ReadLine();
                int door1 = int.Parse(door);
                Console.WriteLine("Matching refrigerators: ");
                foreach (Appliance applianceFridge in applianceList)
                {
                    if(applianceFridge is Refrigerator)
                    {
                        Refrigerator fridge = (Refrigerator)applianceFridge;
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
                foreach (Appliance applianceVacuum in applianceList)
                {
                    if(applianceVacuum is Vacuum)
                    {
                        Vacuum vac = (Vacuum)applianceVacuum;
                        if(volt1 == vac.Battery)
                        {
                            Console.WriteLine(vac.ToString());
                        }
                    }
                }
            }
            else if (var == "3")
            {
                Console.WriteLine("Room Where the microwave will be installed: K (kitchen) or W (work site):");
                string micro = Console.ReadLine();
                Console.WriteLine("Matching microwave:");
                foreach (Appliance applianceMicrowave in applianceList)
                {
                    if(applianceMicrowave is Microwave)
                    {
                        Microwave microwave = (Microwave)applianceMicrowave;
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
                foreach(Appliance applianceDishwasher in applianceList)
                {
                    if(applianceDishwasher is Dishwasher)
                    {
                        Dishwasher wash = (Dishwasher)applianceDishwasher;
                        if(dish == wash.SoundRating)
                        {
                            Console.WriteLine(wash.ToString());
                        }
                    }
                }
            }
        }

        // Uses a for loop and uses user input as a condition for the amount of times it should loop. Uses the Random class and calls
        // the .Next method to call a random index in the applianceList and prints the appliance at that random index.
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

        // Calls the formatForFile() method for each type of object from the applianceList and adds it to a string list, each object is now a string and is formatted in the
        // specified way. Then calls the File.WriteAllLines method to overwrite any changes made onto the existing appliances.txt file by writing the stringApplianceList into it.
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