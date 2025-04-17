using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] nk = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = nk[0]; // [1, 100'000]
        int k = nk[1]; // [1, 100'000]

        int[] houses = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int max = 0;
        {
            int i = 0;
            for (int j = 0; j < houses.Length; ++j)
            {
                if ((j > 0) && (houses[j] == houses[j - 1]))
                {
                    i = j;
                }

                max = Math.Max(max, j - i + 1);
            }
        }
        Console.Write(max);
    }
}