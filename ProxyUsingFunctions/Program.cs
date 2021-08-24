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

            string[] Users = { "Ivan", "Sergey","Vladimir", "Pavel", "Andrey" };

            Console.WriteLine("Enter you name:");

            string userName = Console.ReadLine();

            Action proxy = FileRead;

            if (userName == "Ivan")
            {
                proxy = CreateProxy(Users, proxy, userName);
                proxy();
            }
            if (userName == "Pavel")
            {
                proxy = CreateProxyAction(ForProxyAction, FileRead);
                proxy();
            }
            FileRead();

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

        public static Action CreateProxy(string[] Users, Action print, string userName)
        {
            Action readFile = () =>
            {
                Checker(Users, print, userName);
                Console.WriteLine("Proxy");
            };
            return readFile;
        }

        public static void ForProxyAction(Action print)
        {
            Console.WriteLine("ProxyAction");
        }

        public static Action CreateProxyAction(Action<Action> proxyAction, Action print)
        {
            return () =>
            {
                proxyAction(print);
            };
        }
    }
}
