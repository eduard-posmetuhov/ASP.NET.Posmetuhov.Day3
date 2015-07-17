using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polynom;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynom.Polynom a = new Polynom.Polynom(new double[] { -1, 0, 3, 4 });
            Polynom.Polynom b = new Polynom.Polynom(new double[] { 2, 3, 4 });

            Console.WriteLine(a-b);
            Console.WriteLine(3*a);
            Polynom.Polynom c = a.Clone() as Polynom.Polynom;
            Console.WriteLine(c*0);
            double[] array= a.Coefficient;
            array[0] = 10;
            a=a.SetCoefficient(2, 1);

            Console.WriteLine(a.Equals(a));


            var arr = new double[] { 2, 4, 6 };
            double value = 5;
            Polynom.Polynom first = new Polynom.Polynom(arr);
            for (int i = 0; i < arr.Length; i++)
                arr[i] *= value;
            Polynom.Polynom result = new Polynom.Polynom(arr);
            Console.WriteLine((first*value).Equals(result));
        }
    }
}
