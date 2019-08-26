// <copyright file="BasicCoding.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public static class BasicCoding
    {
        public static int InsertNumber(int numberSource, int numberLn, int i, int j)
        {
            if (i == j)
            {
                if (numberSource == numberLn)
                {
                    numberLn &= numberSource;
                }
                else
                {
                    numberLn = (numberLn & numberSource) + 1;
                }
            }

            return numberLn << i;
        }

        public static int CheckFindingElementIndexBetweenEqualSums(int[] sourceArray)
        {
            int max = 0;

            for (int i = 0; i < sourceArray.Length; i++)
                if (max < sourceArray[i]) max = sourceArray[i];

            return max;
        }

        public static int CheckFindingElementIndexBetweenEqualSums(double[] sourceArray)
        {
            int index = -1;

            for (int i = 0; i < sourceArray.Length; i++)
            {
                double a = 0, b = 0;

                for (int z = 0; z < sourceArray.Length; z++)
                {
                    if (z < i) a += sourceArray[z];

                    if (z > i) b += sourceArray[z];
                }

                if (a.ToString() == b.ToString()) index = i;
            }

            return index;
        }

        public static string CheckStringConcatenation(string firstStr, string secondStr)
        {
            string strSecond = null;

            for (int f = 0; f < secondStr.Length; f++)
            {
                if (firstStr.IndexOf(secondStr[f]) != -1) continue;
                strSecond += secondStr[f];
            }

            return firstStr + strSecond;
        }

        public static int FindNextBiggerNumber(int number)
        {
            Stopwatch time = new Stopwatch();

            time.Start();

            string s = "Число - " + number + ". Время нахождения составило - ";

            char[] numbers = number.ToString().ToCharArray();

            for (int i = numbers.Length - 1; i > 0; i--)
            {
                int value = numbers[i];
                int prevValue = numbers[i - 1];

                if (value > prevValue)
                {
                    numbers[i] = (char)prevValue;
                    numbers[i - 1] = (char)value;

                    int count = numbers.Length - i;

                    char[] newNumbers = new char[count];

                    Array.ConstrainedCopy(numbers, i, newNumbers, 0, count);

                    Array.Sort(newNumbers);

                    Array.Resize(ref numbers, i);

                    time.Stop();

                    Console.WriteLine(s + time.Elapsed);

                    return int.Parse(new string(numbers) + new string(newNumbers));
                }
            }

            time.Stop();

            Console.WriteLine(s + time.Elapsed);

            return -1;
        }

        public static int[] FilterDigit(int[] sourceArray, int digit)
        {
            int[] distArray = new int[] { };

            for (int i = 0; i < sourceArray.Length; i++)
            {
                if (sourceArray[i].ToString().IndexOf(digit.ToString()) == -1) continue;
                Array.Resize(ref distArray, distArray.Length + 1);
                distArray[distArray.Length - 1] = sourceArray[i];
            }

            return distArray;
        }

        private static void Main(string[] args)
        {
            int n = InsertNumber(8, 15, 0, 0);

            Console.WriteLine(n);
            Console.ReadKey();
        }
    }
}
