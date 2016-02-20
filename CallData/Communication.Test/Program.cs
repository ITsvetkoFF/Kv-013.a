using System;
using Communication.Common;

namespace Communication.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser();

            foreach (var bill in parser.ParseWithSax(args[0]))
            {
                Console.WriteLine(bill.ToString());
            }
        }
    }
}
