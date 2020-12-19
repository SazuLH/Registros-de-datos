using System;
using System.IO;

namespace Registro_de_datos_2
{
    class Program
    {
        static string StartData()
        {
            string id = "", names = "", lastNames = "";
            int age = 0;
            string limiter = ", ";

            Console.Write("Identidy: ");
            id = Console.ReadLine();
            Console.Write("Names: ");
            names = Console.ReadLine();
            Console.Write("Last names: ");
            lastNames = Console.ReadLine();
            Console.Write("Age: ");
            age = int.Parse(Console.ReadLine());
            string finalData = id + limiter + names + limiter + lastNames + limiter + age;

            return finalData;  

        }
        
        static void SaveData(string filePath)
        {
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
                string z = StartData();
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
        
        static void Reading(string filePath)
        {
            int NumLines = 0;
            string Line = "";
            using(StreamReader sr = new StreamReader(filePath))
            {
              do
              {
                  Console.WriteLine("no. {0}-- {1}", NumLines, Line);
                  NumLines++;
              } while ((Line = sr.ReadLine()) != null);

            }
        }

        static void SRC(string filePath, string id)
        {
            string Line = "";
            using(StreamReader sr = new StreamReader(filePath))
            do
            {
                string SubId = Line.Split(',')[0];
                if (SubId == id)
                {
                    Console.WriteLine(Line);
                }
            } while ((Line = sr.ReadLine()) != null));
        }

        static void Main(string[] args)
        {
            string fileName = args [0];
            string filePath = @"C:\Users\ODILIS\Desktop\Registro\Datos" + fileName;
            int endProg = 0;
            do
            {
                int num;
                Console.WriteLine();
                Console.WriteLine("Main menu");
                Console.WriteLine("///////////////////////////////////////");
                Console.Write("(1). Capture data.\n");
                Console.Write("(2). List existing information.\n");
                Console.Write("(3). Scearch.\n");
                Console.Write("(4). Exit\n");
                Console.WriteLine("///////////////////////////////////////");
                num = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (num)
                {
                    case 1:
                            SaveData(filePath);
                    break;
                    case 2:
                    Reading(filePath);
                    Console.WriteLine("\nPress a key to continue");
                    Console.ReadKey();
                    break;
                    case 3:
                    string idFinder;
                    Console.WriteLine("\n Enter the ID you want to search");
                    idFinder = Console.ReadLine();
                    Console.WriteLine();
                    SRC(filePath, idFinder);
                    break;
                    case 4:
                    endProg++;
                    break;
                    
                    default:
                    Console.WriteLine("Invalid input.");
                    break;
                }

            } while (endProg == 0);
            
            
        }

    }
}
