using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

/*
 Program Name: Modern Appliance System
 Purpose: Arrange lines from appliances.txt file into their respective objects and calls methods
 Authors: Arvie Sangalang, Jhio Soriano
 Date: Feb 2, 2023
 */

namespace OOP2_Assignment_Classes_and_Inheritance
{
    internal class Program
    {
        // Main menu for the application, uses a while loop and relies on user input for their desired setting.
        // 1 to purchase an item, calls the Purchase() method
        // 2 to find appliances by brand, calls the EnterBrand() method
        // 3 to display appliances by type, calls the DisplayByType() method
        // 4 to Producerandom appliance list, calls the RandomApplianceList() method
        // 5 to write all formatted objects into file, overwrites any changes made onto the objects in the appliances.txt file and kicks the user out of the loop to end the program, calls the WriteFormattedObjectsIntoTextFile() method.
        static void Main(string[] args)
        {
            Management.ReadFromFile();
            while (true)
            {
                Console.WriteLine("\nWelcome to Modern Appliances!\r\nHow may we assist you?\r\n1 – Check out appliance\r\n2 – Find appliances by brand\r\n3 – Display appliances by type\r\n4 – Produce random appliance list\r\n5 – Save & exit\r\nEnter option:");
                string var = Console.ReadLine();
                if (var == "1")
                {
                    Management.Purchase();
                }
                else if (var == "2")
                {
                    Management.EnterBrand();
                }
                else if (var == "3")
                {
                    Management.DisplayByType();
                }
                else if (var == "4")
                {
                    Management.RandomApplianceList();
                }
                else if (var == "5")
                {
                    Management.WriteFormattedObjectsIntoTextFile();
                    break;
                }
                Console.ReadKey();
            }
        }
    }
}
