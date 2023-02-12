using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Assignment_Classes_and_Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Management.ReadFromFile();
            Console.WriteLine("Welcome to Modern Appliances!\r\nHow may we assist you?\r\n1 – Check out appliance\r\n2 – Find appliances by brand\r\n3 – Display appliances by type\r\n4 – Produce random appliance list\r\n5 – Save & exit\r\nEnter option:");
            string var = Console.ReadLine();
            if (var == "1")
            {
                Management.allitem();
            }
            Console.ReadKey();
        }
            
    }
}
