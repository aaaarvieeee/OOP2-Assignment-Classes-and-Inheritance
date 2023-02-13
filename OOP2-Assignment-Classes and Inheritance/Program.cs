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
            Console.WriteLine("Welcome to Modern Appliances!\r\nHow may we assist you?\r\n1 – Check out appliance\r\n2 – Find appliances by brand\r\n3 – Display appliances by type\r\n4 – Produce random appliance list\r\n5 – Save & exit\r\nEnter option:");
            string var = Console.ReadLine();
            Management.ReadFromFile();
            Management test1 = new Management();
            Management test2 = new Management();
            Management test3 = new Management();
            do
            {
                if (var == "1")
                {
                    test1.Purchase();
                }
                else if (var == "2")
                {
                    test1.EnterBrand();
                }
                else if (var == "3")
                {
                    test1.allitem();

                }
                Console.WriteLine("Welcome to Modern Appliances!\r\nHow may we assist you?\r\n1 – Check out appliance\r\n2 – Find appliances by brand\r\n3 – Display appliances by type\r\n4 – Produce random appliance list\r\n5 – Save & exit\r\nEnter option:");
                var = Console.ReadLine();
            } while (var != "5");
            Console.ReadKey();
        }

    }
}
