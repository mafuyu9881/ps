internal class Program
{
    private static void Main(string[] args)
    {
        long n = long.Parse(Console.ReadLine()!);

        LinkedList<long> factorials = new();
        while (true)
        {
            long factorial;
            if (factorials.Count > 0)
            {
                factorial = factorials.Last!.Value * factorials.Count;
            }
            else
            {
                factorial = 1;
            }

            if (factorial > n)
                break;

            factorials.AddLast(factorial);
        }

        int m = 0;
        while (factorials.Count > 0 && n != 0)
        {
            long factorial = factorials.Last!.Value;
            factorials.RemoveLast();

            if (factorial > n)
                continue;
            
            n -= factorial;
            ++m;
        }
        
        Console.Write(n == 0 && m > 0 ? "YES" : "NO");
    }
}