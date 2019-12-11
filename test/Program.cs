using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        static async void Test()
        {
            TestService ts = new TestService();
            await ts.TryConnect("127.0.0.1", 12345);
            Console.WriteLine("Connect ok");
            //ts.SendMessage(new TestOutMessage());
            Console.ReadKey();
        }
    }
}
