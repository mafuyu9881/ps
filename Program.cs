﻿using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        StringBuilder output = new();
        int t = int.Parse(Console.ReadLine()!);
        for (int i = 0; i < t; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int m = tokens[0]; // 1 ≤ m, n ≤ 40,000
            int n = tokens[1];
            int x = tokens[2]; // 1 ≤ x ≤ m
            int y = tokens[3]; // 1 ≤ y ≤ n
            output.AppendLine($"{ComputeYears(m, n, x, y)}");
        }
        Console.Write(output);
    }

    private static int GCD(int a, int b)
    {
        int bigger = Math.Max(a, b);
        int smaller = Math.Min(a, b);
        while (smaller != 0)
        {
            int r = bigger % smaller;
            bigger = smaller;
            smaller = r;
        }
        return bigger;
    }

    private static long LCM(int a, int b)
    {
        return a * (long)b / GCD(a, b);
    }

    private static long ComputeYears(int m, int n, int x, int y)
    {
        long finalYears = LCM(m, n);
        for (; x <= finalYears; x += m)
        {
            if ((x - 1) % n + 1 == y)
            {
                return x;
            }
        }
        return -1;
    }
}