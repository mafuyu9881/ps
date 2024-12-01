internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        // the problem said not to replace integer B's place
        // but actually no need to care about it
        // because the formula S only uses the plus operation
        // so the commutative property will be validated on there
        int[] a = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Array.Sort(a);
        int[] b = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Array.Sort(b);
        Array.Reverse(b);
        int output = 0;
        for (int i = 0; i < n; ++i)
        {
            output += a[i] * b[i];
        }
        Console.Write(output);
    }
}