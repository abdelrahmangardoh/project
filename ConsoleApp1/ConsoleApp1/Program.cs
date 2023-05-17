
using System;
using System.Collections.Generic;
using System.Linq;

namespace StatisticsProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the number of items
            Console.Write("Enter the number of items: ");
            int n = int.Parse(Console.ReadLine());

            // Read the items values
            Console.WriteLine("Enter the items values:");
            double[] values = new double[n];
            for (int i = 0; i < n; i++)
            {
                values[i] = double.Parse(Console.ReadLine());
            }

            // Sort the values
            Array.Sort(values);

            // Calculate the median
            double median = 0;
            if (n % 2 == 0) // even number of items
            {
                median = (values[n / 2 - 1] + values[n / 2]) / 2;
            }
            else // odd number of items
            {
                median = values[n / 2];
            }

            // Calculate the mode
            double mode = 0;
            int maxCount = 0;
            for (int i = 0; i < n; i++)
            {
                int count = 1;
                for (int j = i + 1; j < n; j++)
                {
                    if (values[i] == values[j])
                    {
                        count++;
                    }
                }
                if (count > maxCount)
                {
                    maxCount = count;
                    mode = values[i];
                }
            }

            // Calculate the range
            double range = values[n - 1] - values[0];

            // Calculate the first quartile
            double firstQuartile = 0;
            if (n % 4 == 0) // divisible by 4
            {
                firstQuartile = (values[n / 4 - 1] + values[n / 4]) / 2;
            }
            else // not divisible by 4
            {
                firstQuartile = values[(n + 1) / 4 - 1];
            }

            // Calculate the third quartile
            double thirdQuartile = 0;
            if (n % 4 == 0) // divisible by 4
            {
                thirdQuartile = (values[3 * n / 4 - 1] + values[3 * n / 4]) / 2;
            }
            else // not divisible by 4
            {
                thirdQuartile = values[(3 * n + 1) / 4 - 1];
            }

            // Calculate the P90
            double p90 = values[(int)Math.Ceiling(0.9 * n) - 1];

            // Calculate the interquartile
            double interquartile = thirdQuartile - firstQuartile;

            // Calculate the boundaries of the outlier region
            double lowerBound = firstQuartile - 1.5 * interquartile;
            double upperBound = thirdQuartile + 1.5 * interquartile;
        }
    }
}