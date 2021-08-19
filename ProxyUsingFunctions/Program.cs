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

            string[] Users = { "Ivan", "Sergey","Vladimir", "Pavel", "Andrey" };

            Console.WriteLine("Enter you name:");

            string userName = Console.ReadLine();

            Predicate<string> nameExist = delegate (string name) { return name == userName; };

            foreach (string name in Users)
                if(nameExist(name))
                {
                    print();
                }

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

        
    }
}
