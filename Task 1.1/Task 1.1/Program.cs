using System;

namespace Task_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Compute the value(Task 1.1) by Bilotska Karyna\n");
            Console.WriteLine(@"       
     a
    e + 4 * lg(c)                   5
y = _____________ * |arctg(d)| + ________ , 
        √b                        sin(a)

where : a - user's parameter;
        b - the year of programmer's birth;
        c - the month of programmer's birth;
        d - the day of programmer's birth.

");
            Console.Write("Enter a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter b: ");
            double yearOfBD = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter c: ");
            double monthOfBD = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter d: ");
            double dayOfBD = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"\nResult of computation: {ComputeValue(a, yearOfBD, monthOfBD, dayOfBD)}");
        }

        static double ComputeValue(double a, double b, double c, double d)
        {
            double result = ((Math.Pow(Math.E, a) + (4 * (Math.Log10(c)))) / (Math.Sqrt(b))) * (Math.Abs(Math.Atan(d))) + (5 / Math.Sin(a));
            return result;
        }
    }
}
