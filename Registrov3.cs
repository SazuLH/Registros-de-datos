using System;
using System.IO;

namespace Registro_de_datos_3
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

            string defaultext = "Indentify | Names | Last name | Age";
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

        static int SRC(string filePath, string id)
        {
            int line_to_edit = 0; 
            string Line = "";
            using(StreamReader sr = new StreamReader(filePath))
            do
            {
               
                string SubId = Line.Split(',')[0];
                line_to_edit++;
                if (SubId == id)
                {
                    Console.WriteLine(Line);
                    break;
                }
               
            } while ((Line = sr.ReadLine()) != null);
            return line_to_edit;
        }

        
        static void DataEdit(string filePath, string id)
        {
            int line_to_edit = SRC(filePath, id) - 1;
            Console.WriteLine(line_to_edit);

            string Regis = StartData();

            string[] lines = File.ReadAllLines(filePath);
            using(StreamWriter writer = new StreamWriter(filePath))
            {
                for(int currentLine = 1; currentLine <= lines.Length; ++currentLine)
                {
                    if(currentLine == line_to_edit)
                    {
                        writer.WriteLine(Regis);
                    }
                    else
                    {
                        writer.WriteLine(lines[currentLine - 1]);
                    }
                }
            }
        }

        static void DataDelete(string filePath)
        {
            int conf = 0;
            Console.WriteLine("Are you sure you want delete the saved data?");
            Console.Write("(1). Yes\n");
            Console.Write("(2). No\n");
            conf = int.Parse(Console.ReadLine());
            switch(conf)
            {
                case 1:
                System.IO.File.Delete(filePath);
                break;
                case 2:
                break;
                default:
                Console.WriteLine("Invalid input");
                break;
            }

        }
       

        static void Main(string[] args)        
        {
            string filePath = @"C:\Users\ODILIS\Desktop\Registro\Datos.txt";
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
                Console.Write("(4). Edit Data.\n");
                Console.Write("(5). Delete data.\n");
                Console.Write("(6). Exit\n");
                Console.WriteLine("///////////////////////////////////////");
                num = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (num)
                {
                    case 1:
                            SaveData(filePath);
                            Console.Clear();
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
                    Console.WriteLine("\n Enter the ID you want search");
                    idFinder = Console.ReadLine();
                    Console.WriteLine();
                    DataEdit(filePath, idFinder);
                    break;  

                    case 5:
                    DataDelete(filePath);
                    break;

                    case 6:
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
