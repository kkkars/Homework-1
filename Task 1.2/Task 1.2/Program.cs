using System;

namespace Task_1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Margin's calculation(Task 1.2) by Bilotska Karyna\n");
            Console.WriteLine("To compute the outcomes' probabolities and margin enter next values: \n\n" +
               "Participants' names:");
            Console.Write("   first participant's name: ");
            string player1 = Console.ReadLine();
            Console.Write("   second  participant's name: ");
            string player2 = Console.ReadLine();
            Console.Write("Coefficients:\n      W1: ");
            double winOfp1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("      X: ");
            double draw = Convert.ToDouble(Console.ReadLine());
            Console.Write("      W2: ");
            double winOfp2 = Convert.ToDouble(Console.ReadLine());
            double margin = CountMargin(winOfp1, draw, winOfp2);
            Console.WriteLine(@$"
{player1}'s victory: {Math.Round(CountProbability(winOfp1, margin))}%
{player2}'s victory: {Math.Round(CountProbability(winOfp2, margin))}%
Draw: {Math.Round(CountProbability(draw, margin))}%
Bookmaker's margin: {Math.Round(margin)}%");
        }
        static double CountProbability(double coefficient, double margin)
            => ((1 / coefficient) * 100) - (margin/3);
        static double CountMargin(double w1, double x, double w2)
            => ((1 - (1 / (1 / w1 + 1 / x + 1 / w2))) * 100);
        
    }
}
