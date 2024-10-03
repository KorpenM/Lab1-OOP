using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            int a = 2953512;
            int b = 535;
            int c = 35123;
            int d = 487234;
            int e = 872348;
            int f = 723487;
            long g = 2348759764572;
            long h = 3487597645723;
            int i = 48759764;
            int j = 7597;
            int k = 597645;
            int l = 76457;
            int m = 6457236;
            int n = 4572364;
            int o = 5723645;

            Console.WriteLine(a + b + c + d + e + f + g + h + i + j + k + l + m + n + o);
            */

            long[] numbers = // Alla giltliga tal
            {
                2953512, 535, 35123, 487234, 872348, 723487,
                2348759764572, 3487597645723, 48759764, 7597,
                597645, 76457, 6457236, 4572364, 5723645
            };

            long totalSum = numbers.Sum();

            Console.WriteLine(totalSum);

            Console.ReadKey();
        }
    }
}
