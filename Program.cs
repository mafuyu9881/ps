class Program
{
    static void Main(string[] args)
    {
        Console.ReadLine();

        int[] divisors = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Array.Sort(divisors);

        int divisorsLength = divisors.Length;

        string output;
        {
            if (divisorsLength % 2 == 0)
            {
                output = (divisors[0] * divisors[divisorsLength - 1]).ToString();
            }
            else
            {
                output = (divisors[divisorsLength / 2] * divisors[divisorsLength / 2]).ToString();
            }
        }
        
        Console.Write(output);
    }
}