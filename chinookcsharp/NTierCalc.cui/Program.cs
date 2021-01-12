using NTierCalc.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierCalc.cui
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("첫번째");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("두번째");
            double b = double.Parse(Console.ReadLine());
            Calculator c = new Calculator();
            Console.WriteLine(c.devide(a,b));
        }
    }
}
