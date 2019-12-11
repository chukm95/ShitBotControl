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
            await ts.TryConnect("127.0.0.1", 8988);
            Console.WriteLine("Connect ok");
            while (true)
            {
                
            }
        }
    }
}
