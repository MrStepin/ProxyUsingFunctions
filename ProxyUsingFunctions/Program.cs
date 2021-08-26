using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyUsingFunctions
{
    public class Program
    {
        static void Main(string[] args)
        {

            string[] Users = { "Ivan", "Sergey","Vladimir", "Pavel", "Andrey" };

            Console.WriteLine("Enter you name:");

            string userName = Console.ReadLine();

            Action proxy = ReadFile;

            if (userName == "Ivan")
            {
                proxy = CreateProxy(proxy, Users, userName);
                proxy();
            }
            if (userName == "Pavel")
            {
                proxy = CreateProxyAction(proxy, ReadFileConsoleLogProxy);
                proxy();
            }

            Console.ReadLine();
        }

        public static void ReadFile()
        {
            StreamReader file = new StreamReader("C:\\Users\\Stas\\Desktop\\config.txt");
        }

        public static void ValidateUserAccess(string[] Users, string userName)
        {
            if (!Users.Contains(userName))
            {
                throw new Exception("Failed to read.");
            }
        }

        public static Action CreateProxy(Action sourceAction, string[] Users, string userName)
        {
            Action readFile = () =>
            {
                ValidateUserAccess(Users, userName);
                Console.WriteLine("Proxy");
                sourceAction();
            };
            return readFile;
        }

        public static void ReadFileConsoleLogProxy()
        {
            Console.WriteLine("ProxyAction"); 
        }

        public static Action CreateProxyAction(Action sourceAction, Action proxyPostAction)
        {
            return () =>
            {
                sourceAction();
                proxyPostAction();
            };
        }
    }
}
