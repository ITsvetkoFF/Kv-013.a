using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communication.Common;

namespace Communication.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser();

            foreach (var bill in parser.ParseSAX(args[0]))
            {
                Console.WriteLine(bill.ToString());
            }
        }
    }
}
