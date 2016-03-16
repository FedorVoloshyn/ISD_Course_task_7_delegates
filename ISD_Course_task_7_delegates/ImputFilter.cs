using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ISD_Course_task_7_delegates
{
    public static class ImputFilter
    {
        public static int ImputIntNumber(string imput)
        {
            Regex myregex = new Regex("^-?\\d+$");
            while (!myregex.IsMatch(imput, 0))
            {
                Console.WriteLine("Invalid imput, try again!");
                imput = Console.ReadLine();
            }
            return Convert.ToInt32(imput);
        }

        public static double ImputDoubleNumber(string imput)
        {
            Regex myregex = new Regex("^(-?\\d+)(\\,\\d+)?$");
            while (!myregex.IsMatch(imput, 0))
            {
                Console.WriteLine("Invalid imput, try again!");
                imput = Console.ReadLine();
            }
            return Convert.ToDouble(imput);
        }
    }
}
