using System;
using System.IO;

namespace Registro_de_datos
{
    class Program
    {
        static string Data(string filePath)
        {
            string id = "", names = "", lastNames = "";
            int age = 0;
            string delimiter = ", ";

            Console.Write("Identidy: ");
            id = Console.ReadLine();
            Console.Write("Names: ");
            names = Console.ReadLine();
            Console.Write("Last names: ");
            lastNames = Console.ReadLine();
            Console.Write("Age: ");
            age = int.Parse(Console.ReadLine());
            string finalData = id + delimiter + names + delimiter + lastNames + delimiter + age;

            return finalData;  

        }
        
        static void Main(string[] args)
        {
            string fileName = args [0];
            string filePath = @"C:\Users\ODILIS\Desktop\Registro\Datos" + fileName;
            int menu;
            int endProg = 0;

            string defaultext = "Indentify, Names, Last name, Age";
            using (StreamWriter sw = File.CreateText(filePath))
            {
                sw.WriteLine(defaultext);
                sw.Close();
            }

            do
            {
                string z = Data(filePath);
                Console.WriteLine("Save(1), Discart(2), Exit(3)");
                menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                    using (StreamWriter sw = File.AppendText(filePath))
                    {
                         sw.WriteLine(z);
                         sw.Close();
                    }
                    break;

                    case 2:    
                    break;

                    case 3:
                    endProg++;
                    break;

                    default:
                    Console.WriteLine("Invalid entry. ");
                    break;
                }
            } while (endProg == 0);
            
        }

    }
}
