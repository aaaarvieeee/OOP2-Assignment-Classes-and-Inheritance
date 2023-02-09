using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Assignment_Classes_and_Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
        static void ReadFromFile()
        {
            string path = "C:\\Users\\death\\source\\repos\\OOP2-Assignment-Classes and Inheritance\\OOP2-Assignment-Classes and Inheritance\\appliances.txt";
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] fields = line.Split(';');
            }
        }
    }
}
