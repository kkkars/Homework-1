using System;

namespace Task_2._2
{
    class Program
    {
        static int Main(string[] args)
        {
            bool play = default;
            bool isCorrect = default;
            double a, b, c, radius, square = 0;
            string shape = default;
            
            if (args != null && args.Length > 0)
            {
                shape = args[0];
                switch (shape)
                {
                    case "circle":
                        radius = Convert.ToDouble(args[1]);
                        square = Math.PI * Math.Pow(radius, 2);
                        break;
                    case "square":
                        a = Convert.ToDouble(args[1]);
                        square = Math.Pow(a, 2);
                        break;
                    case "rectangle":
                        a = Convert.ToDouble(args[1]);
                        b = Convert.ToDouble(args[2]);
                        square = a * b;
                        break;
                    case "triangle":
                        {
                            a = Convert.ToDouble(args[1]);
                            b = Convert.ToDouble(args[2]);
                            c = Convert.ToDouble(args[3]);
                            double p = (a + b + c) / 2;
                            square = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                        }
                        break;
                    default:
                        return -1;
                }
                Console.WriteLine($"{square}");

            }
            else
            {
                Console.WriteLine("(Task 2.2) by Bilotska Karyna");
                do
                {
                    do
                    {
                        Console.Write(@"Shapes:
    -circle;
    -square;
    -rectangle;
    -triangle.

Choose the shape: ");
                        shape = Console.ReadLine();
                        if (shape == "circle" || shape == "rectangle" || shape == "square" || shape == "triangle")
                        {
                            isCorrect = true;
                            switch (shape)
                            {
                                case "circle":
                                    Console.Write("R: ");
                                    radius = Convert.ToDouble(Console.ReadLine());
                                    square = Math.PI * Math.Pow(radius, 2);
                                    break;
                                case "square":
                                    Console.Write("a: ");
                                    a = Convert.ToDouble(Console.ReadLine());
                                    square = Math.Pow(a, 2);
                                    break;
                                case "rectangle":
                                    Console.Write("a: ");
                                    a = Convert.ToDouble(Console.ReadLine());
                                    Console.Write("b: ");
                                    b = Convert.ToDouble(Console.ReadLine());
                                    square = a * b;
                                    break;
                                case "triangle":
                                    Console.Write("a: ");
                                    a = Convert.ToDouble(Console.ReadLine());
                                    Console.Write("b: ");
                                    b = Convert.ToDouble(Console.ReadLine());
                                    Console.Write("c: ");
                                    c = Convert.ToDouble(Console.ReadLine());
                                    double p = (a + b + c) / 2;
                                    square = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                                    break;
                            }
                            Console.WriteLine($"\nSquare: {square}\n");
                        }
                        else
                        if (shape == "exit")
                            return 0;
                        else
                        {
                            isCorrect = false;
                            Console.WriteLine("Be careful! You entered the wrong option. Try again\n");
                        }
                    } while (isCorrect != true);
                } while (play != true);
            }
            return 0;
        }
    }
}
