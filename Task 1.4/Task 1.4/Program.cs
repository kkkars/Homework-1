using System;

namespace Task_1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prime number search(Task 1.4) by Bilotska Karyna\n");
            Console.Write("Enter the range for search:\n    Lower bound: ");
            int lowerBound = Convert.ToInt32(Console.ReadLine());
            Console.Write("    Upper bound: ");
            int upperBound = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Prime numbers: ");
            PrintPrimeNumbers(lowerBound, upperBound);
        }
        static void PrintPrimeNumbers(int lowerBound, int upperBound)
        {
            for (int i = lowerBound; i <= upperBound; i++)
            {
                bool IsPrime = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        IsPrime = false;
                        break;
                    }
                }
                if (!IsPrime) continue;
                Console.Write($"{i}  ");
            }
        }
    }
}
