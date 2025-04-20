internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Array.Sort(tokens);

        int x = int.Parse(Console.ReadLine()!);

        int pairs = 0;
        {
            int i = 0;
            int j = tokens.Length - 1;
            while (i < j)
            {
                int sum = tokens[i] + tokens[j];
                if (sum < x)
                {
                    ++i;
                }
                else if (sum > x)
                {
                    --j;
                }
                else
                {
                    ++pairs;
                    ++i;
                    --j;
                }
            }
        }
        Console.Write(pairs);
    }
}