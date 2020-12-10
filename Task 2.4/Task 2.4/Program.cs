using System;

namespace Task_2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isCorrect = default;
            int lowerBound = default;
            int upperBound = default;
            string usersPrompt = default;
            Console.WriteLine("More less game by Bilotska Karyna\n");
            Console.WriteLine(@"Enter the range.
Computer will pick number between your range.
Try to guess this number.
If you fail, you will be given a clue: ""more""/ ""less"".
If you give up, your score will be nullify.
To exit: enter exit.
");
                do
                {
                    Console.Write(@"Range(0 to 1000000):
    Lower bound: ");
                    lowerBound = Convert.ToInt32(Console.ReadLine());
                    Console.Write("    Upper bound: ");
                    upperBound = Convert.ToInt32(Console.ReadLine());
                    if ((upperBound > 0 && lowerBound >= 0) && lowerBound < upperBound)
                    {
                        int pickedNumber = PickNumber(Convert.ToInt32(lowerBound), Convert.ToInt32(upperBound));
                        int fails = 0;
                        do
                        {
                            Console.Write("Your prompt:");
                            usersPrompt = Console.ReadLine();
                        if (usersPrompt == "exit")
                        {
                            Console.WriteLine("\nScores: 0");
                            return;
                        }
                        else
                        {
                            if (Convert.ToInt32(usersPrompt) < pickedNumber)
                            {
                                fails++;
                                Console.WriteLine("Picked number is more");
                            }
                            else
                            if (Convert.ToInt32(usersPrompt) > pickedNumber)
                            {
                                Console.WriteLine("Picked number is less");
                                fails++;
                            }
                        }
                        } while (Convert.ToInt32(usersPrompt)!= pickedNumber);
                        Console.WriteLine("\nYou won!");
                        Console.WriteLine($"Scores: {CountScore(ClosestPowerOf2(pickedNumber), fails)}");
                    Console.WriteLine();
                        return;
                    }
                    else 
                    {
                        isCorrect = false;
                        Console.WriteLine("Be careful! You entered wrong range. Try again.");
                    }
                } while (isCorrect !=true);
                int pickedNumbere = PickNumber(Convert.ToInt32(lowerBound), Convert.ToInt32(upperBound));
        }

        static int PickNumber(int lowerBound, int upperBound)
        {
            Random random = new Random();
            return random.Next(lowerBound, upperBound + 1);
        }
        static double CountScore(int closestPower,int amountOfFails)
        {
            double score = 100 * (closestPower - amountOfFails)/closestPower;
            return Math.Round(score);
        }
        static int ClosestPowerOf2(int pickedNumber)
        {
            int power = 0;
            while(pickedNumber % 2 != 0)
                pickedNumber-= 1;
            while (pickedNumber>1)
            {
                pickedNumber /= 2;
                power++;
            }
            return power;
        }
    }
}
