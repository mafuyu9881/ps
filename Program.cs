using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();
        BigInteger p = BigInteger.Parse(tokens[0]);
        int k = int.Parse(tokens[1]);

        bool[] composite = new bool[k];
        LinkedList<int> primes = new();
        for (int i = 2; i < k; ++i) // max tc = 10^6
        {
            if (composite[i])
                continue;
            
            primes.AddLast(i);

            long square = (long)i * i;
            if (square < k)
            {
                for (int j = (int)square; j < k; j += i) // max tc = ln(ln(10^6))
                {
                    composite[j] = true;
                }
            }
        }

        string output = "GOOD";

        for (var lln = primes.First; lln != null; lln = lln.Next)
        {
            int prime = lln.Value;
            if (p % lln.Value == 0)
            {
                output = $"BAD {prime}";
                break;
            }
        }

        Console.Write(output);
    }
}