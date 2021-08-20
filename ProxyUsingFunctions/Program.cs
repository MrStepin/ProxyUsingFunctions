using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyUsingFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            Action print = FileRead;
            Action<string[], Action, string> checkName = Checker;

            string[] Users = { "Ivan", "Sergey","Vladimir", "Pavel", "Andrey" };

            Console.WriteLine("Enter you name:");

            string userName = Console.ReadLine();

            checkName(Users, FileRead, userName);

            Console.ReadLine();
        }

        public static void ReadFile()
        {
            StreamReader file = new StreamReader("C:\\Users\\Stas\\Desktop\\config.txt");
            string line = file.ReadLine();
         
        }

        public static void FileRead()
        {
            ReadFile();
            Console.WriteLine("File read!");
        }

        public static void Checker(string[] Users, Action print, string userName)
        {
            if (Users.Contains(userName))
            {
                print();
            }
            else
            {
                throw new Exception ("Failed to read.");
            }
        }
    }
}
