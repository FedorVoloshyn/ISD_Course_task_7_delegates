using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISD_Course_task_7_delegates
{
    delegate double Averege(int firstVal, int secondVal, int thirdVal);
    delegate double Ariphmethic(double firstVal, double secondVal);
    delegate int RandomValue();
    delegate double AveregeOfDelegates(RandomValue[] arrayOfDelegates);
    class Program
    {
        static void Main(string[] args)
        {
            int chosen_exersise = -1;

            while (chosen_exersise != 0)
            {
                Console.WriteLine("\tISD Course. Task 6. Homework by Fedor Voloshyn.\n");
                Console.WriteLine("Enter number of exercise or '0' to exit: ");
                chosen_exersise = ImputFilter.ImputIntNumber(Console.ReadLine());
                Console.Clear();

                switch (chosen_exersise)
                {
                    case 0: Console.WriteLine("Have a nice day!");
                        break;
                    case 1: ExerciseOne();
                        break;
                    case 2: ExerciseTwo();
                        break;
                    case 3: ExerciseThree();
                        break;
                    default: Console.WriteLine("Looks like you entered wrong number! Try again ;)");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static public void ExerciseOne()
        {
            Averege myAverCalculator = delegate(int firstVal, int secondVal, int thirdVal)
            {
                return (firstVal + secondVal + thirdVal) / 3.0;
            };

            Console.WriteLine("Enter first value: ");
            int myFirstVal = ImputFilter.ImputIntNumber(Console.ReadLine());
            Console.WriteLine("Enter second value: ");
            int mySecondVal = ImputFilter.ImputIntNumber(Console.ReadLine());
            Console.WriteLine("Enter third value: ");
            int myThirdVal = ImputFilter.ImputIntNumber(Console.ReadLine());

            double result = myAverCalculator(myFirstVal, mySecondVal, myThirdVal);

            Console.WriteLine("Averege = {0}", result);
        }
        static public void ExerciseTwo()
        {
            Ariphmethic Add = delegate(double firstVal, double secondVal) { return firstVal + secondVal; };
            Ariphmethic Sub = delegate(double firstVal, double secondVal) { return firstVal - secondVal; };
            Ariphmethic Mul = delegate(double firstVal, double secondVal) { return firstVal * secondVal; };
            Ariphmethic Div = delegate(double firstVal, double secondVal)
            {
                if (secondVal != 0)
                    return firstVal / secondVal;
                else
                    return 0;
            };

            Console.WriteLine("Enter first value: ");
            int myFirstVal = ImputFilter.ImputIntNumber(Console.ReadLine());
            Console.WriteLine("Enter second value: ");
            int mySecondVal = ImputFilter.ImputIntNumber(Console.ReadLine());

            Console.WriteLine("Enter number of option: ");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Sub");
            Console.WriteLine("3. Mul");
            Console.WriteLine("4. Div");

            switch (ImputFilter.ImputIntNumber(Console.ReadLine()))
            {
                case 1: Console.WriteLine("Add: {0}", Add(myFirstVal, mySecondVal));
                    break;
                case 2: Console.WriteLine("Sub: {0}", Sub(myFirstVal, mySecondVal));
                    break;
                case 3: Console.WriteLine("Mul: {0}", Mul(myFirstVal, mySecondVal));
                    break;
                case 4: Console.WriteLine("Div: {0}", Div(myFirstVal, mySecondVal));
                    break;
                default:
                    break;
            }
        }
        static public void ExerciseThree()
        {
            Random rand = new Random();
            RandomValue[] mas = new RandomValue[3];

            mas[0] = delegate() { return rand.Next(-100, 1); };
            mas[1] = delegate() { return rand.Next(1, 50); };
            mas[2] = delegate() { return rand.Next(50, 101); };
            
            AveregeOfDelegates averOfDels = delegate(RandomValue[] arrayOfDelegates)
            {
                double result = 0;
                for (int i = 0; i < arrayOfDelegates.Length; i++)
                {
                    result += arrayOfDelegates[i]();
                }
                return result / arrayOfDelegates.Length;
            };

            Console.WriteLine("Averege of 3 random functions = {0}" ,averOfDels(mas));
        }
    }
}
