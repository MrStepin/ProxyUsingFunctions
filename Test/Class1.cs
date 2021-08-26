using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ProxyUsingFunctions;

namespace Test
{
    public class Class1
    {
        string[] Users = { "Ivan", "Sergey", "Vladimir", "Pavel", "Andrey" };

        [Test]
        public void CheckAccessAllowed()
        {
            string userName = "Ivan";

            Assert.DoesNotThrow(() => Program.ValidateUserAccess(Users, userName));
        }

        [Test]
        public void CheckAccessDenied()
        {
            string userName = "ivan";

            Assert.Catch(() => Program.ValidateUserAccess(Users, userName));
        }

        [Test]
        public void FileIsNotExist()
        {
            Assert.Catch(() => Program.ReadFile());
        }

        [Test]
        public void CheckCreateProxyFunction()
        {
            string userName = "Andrey";

            Assert.DoesNotThrow(() => Program.CreateProxy(Users, userName));

        }

        [Test]
        public void CheckCreateProxyActionFunction()
        {
            string userName = "Sergey";

            Assert.DoesNotThrow(() => Program.CreateProxyAction(Program.ReadFileConsoleLogProxy));
        }
    }
}
