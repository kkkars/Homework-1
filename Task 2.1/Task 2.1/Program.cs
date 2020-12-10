using System;
using System.Collections.Generic;

namespace Task_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> scores = new List<string>();
            Console.WriteLine("Rock-paper-scissors game(Task 2.1) by Bilotska Karyna\n");
            string userOption = default;
            bool play = default;
            bool isCorrect = default;
            Console.WriteLine(@"You have 3 options: scissors, paper and rock.
You need to choose one of them. 
Rules:
    -Rock beats scissors;
    -Scissors beats paper;
    -Paper beats rock.
       
Let's play?");
            do
            {
                do
                {
                    Console.Write("Your choice: ");
                    userOption = Console.ReadLine();
                    if (userOption == "scissors" || userOption == "paper" || userOption == "rock")
                        isCorrect = true;
                    else
                    if (userOption == "exit")
                    {
                        int round = 0;
                        foreach (string score in scores)
                            Console.WriteLine($@"
Round {++round}:
    {score}");
                        return;
                    }
                    else
                    {
                        isCorrect = false;
                        Console.WriteLine("Be careful! You entered wrong option. Try again.\nOptions: scissors, rock, paper");
                    }
                } while (isCorrect != true);
                string computerOption = ComputerOption();
                Console.WriteLine($"Computer: {computerOption}\n");
                IndicateTheWinner(userOption, computerOption, scores);
            } while (play != true);

            static string ComputerOption()
            {
                string computerOption = default;
                Random random = new Random();
                switch (random.Next(1, 4))
                {
                    case 1:
                        computerOption = "rock";
                        break;
                    case 2:
                        computerOption = "scissors";
                        break;
                    case 3:
                        computerOption = "paper";
                        break;
                }
                return computerOption;
            }
            static void IndicateTheWinner(string userOption, string computerOption, List<string> scores)
            {
                if (userOption == "rock" && computerOption == "scissors" || userOption == "scissors" && computerOption == "paper" || userOption == "paper" && computerOption == "rock")
                {
                    Console.WriteLine("You won this round!\n");
                    scores.Add("Score: 1 : 0 ");
                }
                else
                if (computerOption == "rock" && userOption == "scissors" || computerOption == "scissors" && userOption == "paper" || computerOption == "paper" && userOption == "rock")
                {
                    Console.WriteLine("Computer won this round!\n");
                    scores.Add("Score: 0 : 1 ");
                }
                else
                if (userOption == computerOption)
                {
                    Console.WriteLine("Draw!\n");
                    scores.Add("Score: 0 : 0 ");
                }

            }
        }
    }
}
