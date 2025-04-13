internal class Program
{
    private static void Main(string[] args)
    {
        int[] Damage = new int[3] { 9, 3, 1 };

        int n = int.Parse(Console.ReadLine()!);

        // length = [1, 3]
        // element = [1, 60]
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        Func<bool> Complete = () =>
        {
            for (int i = 0; i < tokens.Length; ++i)
            {
                if (tokens[i] > 0)
                {
                    return false;
                }
            }
            return true;
        };

        int attacks = 0;
        while (Complete() == false)
        {
            Array.Sort(tokens, (x, y) => y.CompareTo(x));

            for (int i = 0; i < tokens.Length; ++i)
            {
                tokens[i] = Math.Max(0, tokens[i] - Damage[i]);
            }

            ++attacks;
        }
        Console.Write(attacks);
    }
}