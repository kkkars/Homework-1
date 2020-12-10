using System;

namespace Task_3
{
    class Program
    {
        static int Main(string[] args)
        {
            int firstNumberSign = 1;
            string expression = default;
            
            if (args != null && args.Length > 0)
            {
                expression = PrepareInput(args, ref firstNumberSign);
                try
                {
                    Console.WriteLine(CalculateTheResult(expression, firstNumberSign));
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            else
            {
                string userInput = default;
                Console.WriteLine("Calculator(Task 3.1) by Bilotska Karyna\n"); 
                Console.WriteLine(@"Enter the expression to compure the result.
Enter ""help"" to see the instruction.
Enter ""exit"" to cease program execution.
");
                do
                {
                        Console.WriteLine("Enter the expression: \n");
                        userInput = Console.ReadLine();

                        if (userInput == "help")
                            Help();
                        else
                            if (userInput == "exit")
                            return 0;
                        expression = PrepareInputSt(userInput, ref firstNumberSign);

                    try
                    {
                        if (expression != "help")
                        {
                            Console.WriteLine($"\nResult: {CalculateTheResult(expression, firstNumberSign)}\n");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("\n"+e.Message);
                        Console.WriteLine(@"To see the instruction enter ""help""
");
                    }

                    catch (DivideByZeroException e)
                    {
                        Console.WriteLine("\n"+ e.Message);
                        Console.WriteLine("Try again.\n");
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine("\n"+e.Message);
                        return -1;
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("\nSorry, something went wrong, we will fix it soon.");
                        return -1;
                    }
                    firstNumberSign = 1;
                } while (userInput != "exit");
            }
            return 0;
        }

        static bool CheckForPlus(string expression, int i)
        {
            if(expression[i+1]=='+')
            {
                return false;
            }
            return true;
        }
        static double CalculateTheResult(string expression, int firstNumberSign)
        {
            string[] numbers = new string[2];
            double result = default;
          
            for (int i = 0; i < expression.Length; i++)
            {
                switch (expression[i])
                {
                    case '+':
                        {
                            numbers = expression.Split(new char[] { '+' });
                            if (numbers.Length == 2 && CheckForPlus(expression, i))
                            {
                                result = firstNumberSign * Convert.ToDouble(numbers[0]) + Convert.ToDouble(numbers[1]);
                                i = expression.Length;
                            }
                            else
                                throw new FormatException();
                            break;
                        }
                    case '-':
                        {
                            numbers = expression.Split(new char[] { '-' });
                            if (numbers.Length == 2 && CheckForPlus(expression, i))
                            {
                                result = firstNumberSign * Convert.ToDouble(numbers[0]) - Convert.ToDouble(numbers[1]);
                                i = expression.Length;
                            }
                            break;
                        }
                    case '*':
                        {
                            numbers = expression.Split(new char[] { '*' });
                            if (numbers.Length == 2 && CheckForPlus(expression, i))
                            {
                                result = firstNumberSign * Convert.ToDouble(numbers[0]) * Convert.ToDouble(numbers[1]);
                                i = expression.Length;
                            }
                            break;
                        }
                    case 'x':
                        {
                            numbers = expression.Split(new char[] { 'x' });
                            if (numbers.Length == 2 && CheckForPlus(expression, i))
                            {
                                result = firstNumberSign * Convert.ToDouble(numbers[0]) * Convert.ToDouble(numbers[1]);
                                i = expression.Length;
                            }
                            break;
                        }
                    case '/':
                        {
                            numbers = expression.Split(new char[] { '/' });
                            if (numbers[1] == "0")
                                throw new DivideByZeroException();
                            if (numbers.Length == 2 && CheckForPlus(expression, i))
                            {
                                result = firstNumberSign * Convert.ToDouble(numbers[0]) / Convert.ToDouble(numbers[1]);
                                i = expression.Length;
                            }
                            break;
                        }
                    case '\\':
                        {
                            numbers = expression.Split(new char[] { '\\' });
                            if (numbers[0] == "0")
                                throw new DivideByZeroException();
                            if (numbers.Length == 2 && CheckForPlus(expression, i))
                            {
                                result = firstNumberSign * Convert.ToDouble(numbers[0]) / Convert.ToDouble(numbers[1]);
                                i = expression.Length;
                            }
                            break;
                        }
                    case '%':
                        {
                            numbers = expression.Split(new char[] { '%' });
                            if (numbers.Length == 2 && CheckForPlus(expression, i))
                            {
                                result = firstNumberSign * Convert.ToDouble(numbers[0]) % Convert.ToDouble(numbers[1]);
                                i = expression.Length;
                            }
                            break;
                        }
                    case 'p':
                        {
                            numbers = expression.Split(new char[] { 'p' });
                            if (numbers.Length == 2 && CheckForPlus(expression, i))
                            {
                                try
                                {
                                    checked
                                    {
                                        result = checked(Math.Pow(firstNumberSign * Convert.ToDouble(numbers[0]), Convert.ToDouble(numbers[1])));
                                    }
                                }
                                catch(OverflowException)
                                {
                                    throw new OverflowException();
                                }
                                i = expression.Length;
                            }
                            break;
                        }
                    case '&':
                        {
                            if (firstNumberSign == 1)
                            {
                                numbers = expression.Split(new char[] { '&' });
                                if (numbers.Length == 2)
                                    result = Convert.ToInt32(numbers[0]) & Convert.ToInt32(numbers[1]);

                            }
                            break;
                        }
                    case '|':
                        {
                            if (firstNumberSign == 1)
                            {
                                numbers = expression.Split(new char[] { '|' });
                                if (numbers.Length == 2)
                                    result = Convert.ToInt32(numbers[0]) | Convert.ToInt32(numbers[1]);
                            }
                            break;
                        }
                    case '^':
                        {
                            if (firstNumberSign == 1)
                            {
                                numbers = expression.Split(new char[] { '^' });
                                if (numbers.Length == 2)
                                    result = Convert.ToInt32(numbers[0]) ^ Convert.ToInt32(numbers[1]);
                            }
                            break;
                        }
                    case '!':
                        {
                            if (firstNumberSign == 1)
                            {
                                if (expression.StartsWith('!'))
                                {
                                    expression = expression.Remove(0, 1);
                                    result = ~Convert.ToInt32(expression);
                                }
                                else
                                    if (expression.EndsWith('!'))
                                    {
                                    result = 1;
                                    numbers[0] = " ";
                                    expression = expression.Remove(expression.Length - 1, 1);
                                    try
                                    {
                                        checked
                                        {
                                            for (int index = 1; index <= Convert.ToInt32(expression); index++)
                                                result *= index;
                                        }
                                    }
                                    catch (OverflowException)
                                    {
                                        throw new OverflowException();
                                    }
                                    }
                                
                            }
                            break;
                        }
                }
            }
            if (numbers[0] == null)
            {
                result = firstNumberSign * Convert.ToDouble(expression);
                firstNumberSign = 1;
            }
            return result;
        }
        static string PrepareInput(string[] input, ref int firstNumberSign)
        {
            string expression = default;
            for (int i = 0; i < input.Length; i++)
                if (input[i] != " ")
                    expression += input[i];
            if (expression.StartsWith('-'))
            {
                expression = expression.Remove(0, 1);
                firstNumberSign = -1;
            }
            expression = expression.Replace("--", "+");
            expression = expression.Replace("pow", "p");
            return expression;
        }
        static string PrepareInputSt(string input, ref int firstNumberSign )
        {
            string expression = default;
            for (int i = 0; i < input.Length; i++)
                if (input[i] != ' ')
                    expression += input[i];
            expression = expression.Replace("--", "+");
            expression = expression.Replace("pow", "p");
            if (expression.StartsWith('-'))
            {
                expression = expression.Remove(0, 1);
                firstNumberSign = -1;
            }
            return expression;
        }
        static void Help()
        {
            Console.WriteLine(@"
**************************************Instruction**************************************
Program supports next types of expression:
    -Binary:
        a + b, a - b, a * b, a x b, a / b, a \ b, a % b, a pow b (a to power of b);
    -Binary bit (only positive operands):
        a & b, a | b, a ^ b;
    -Unary bit (only positive operands):
        !a;
    -Unary:
        a! (factorial), a (echo mode), -a (echo mode).

Operations:
    + <-- to add two numbers;
    - <-- to subtract two numbers;
    * <-- to multiply two numbers;
    x <-- to multiply two numbers;
    / <-- to divide two numbers;
    \ <-- to divide two numbers;
    % <-- to find remainder of division;
    pow <-- to the power of;
    & <-- to turn off bits, if getted data is different;
    | <-- to turn on bits, if getted data is different;
    ^ <-- to turn on bits, if getted data is the same;
    ! <-- 1.before a number: (unary bit operation) to invert bits;
          2.after a number: (unary operation) to compute a factorial.

Program supports expressions only with one or two operands.
Exception, which contains more than two operands is unacceptabl.

Examples of correct expressions:
    1+2
    1+-2
    1--2
    12&3
    5!
    -5
    -2 *-2
Examples of wrong expressions:
    1+5+6
    1+--2
    2/+2
    2+
    +2
***************************************************************************************

");
        }
    }
}
