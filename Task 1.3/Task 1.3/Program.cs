using System;

namespace Task_1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Compute numbers' sum(Task 1.3) by Bilotska Karyna");
            Console.WriteLine(@"
 inf       1
 Sum = ___________ ,
 i=1  i * (i + 1)
additional information:
        accuracy: epsilon = 1 / year of programmer's birth.");
            Console.Write("Enter the year of programmer birth to indicate the accuracy: ");
            double yearOfBD = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"\nThe result: {CountNumbersSum(yearOfBD)}");
        }
        static double CountNumbersSum(double yearOfBD)
        {
            double sum = 0;
            double i = 1;
            do
            {
                sum += 1 / (i * (i + 1));
                i++;
            } while ((1 / (i * (i + 1))) > (1 / yearOfBD));
            return sum;
        }
    }
}
