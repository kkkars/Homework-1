using System;

namespace Task_2._3
{
    class Program
    {
        static int Main(string[] args)
        {
            bool isCorrect = default;
            int size = default;

            if (args != null && args.Length > 0)
            {
                double[] copy = new double[args.Length];
                int i = 0;
                try
                {
                    foreach (string element in args)
                    {
                        copy[i] = Convert.ToDouble(element);
                        i++;
                    }
                }
                catch
                {
                    return -1;
                }
                Console.WriteLine($@"{MinValue(copy)}               
{MaxValue(copy)}               
{Average(copy)}               
{StandardDeviation(copy)}");
                QuickSort(ref copy, 0, copy.Length-1);
                foreach (double element in copy)
                    Console.Write($"{element} ");
            }
            else
            {
                Console.WriteLine("Array statistics by Bilotska Karyna");
                Console.Write("Enter the size of the array: ");
                do
                {
                    try
                    {
                        size = Convert.ToInt32(Console.ReadLine());
                        isCorrect = true;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                        isCorrect = false;
                    }
                } while (isCorrect != true);
                isCorrect = false;
                double[] array = new double[size];
                do
                {
                    Console.WriteLine("Fill the array: ");
                    try
                    {
                        for (int i = 0; i < size; i++)
                        {
                            Console.Write($"[{i}]: ");
                            array[i] = Convert.ToDouble(Console.ReadLine());
                        }
                        isCorrect = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nWrogn input. Try again.\n");
                        isCorrect = false;
                    }

                } while (isCorrect != true); ;
                Console.WriteLine(@$"
Min element: {MinValue(array)}
Max element: {MaxValue(array)}
Average: {Average(array)}
Standard deviation: {StandardDeviation(array)}");
                QuickSort(ref array, 0, array.Length-1);
                Console.WriteLine("Sorted array: ");
                foreach (double element in array)
                    Console.Write($"{element} ");
            }
            return 0;
        }

        static double MinValue(double[] array)
        {
            double minValue = array[0];
            for (int i = 0; i < array.Length; i++)
                if (minValue > array[i])
                    minValue = array[i];
            return minValue;
        }
        static double MaxValue(double[] array)
        {
            double maxValue = array[0];
            for (int i = 0; i < array.Length; i++)
                if (maxValue < array[i])
                    maxValue = array[i];
            return maxValue;
        }
        static double Average(double[] array)
        {
            double sum = 0;
            foreach (double element in array)
                sum += element;
            return (sum / array.Length);
        }
        static double StandardDeviation(double[] array)
        {
            double deviationSum = 0;
            foreach (double element in array)
                deviationSum += Math.Pow((element - Average(array)), 2);
            return deviationSum / array.Length;
        }
        static double Partition(ref double[] array, int start, int end)
        {
            double temp;
            int marker = start;
            for (int i = start; i < end; i++)
            {
                if (array[i] < array[end]) 
                {
                    temp = array[marker]; 
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }
        static void QuickSort(ref double[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = (int)Partition(ref array, start, end);
            QuickSort(ref array, start, pivot - 1);
            QuickSort(ref array, pivot + 1, end);
        }
    }
}
