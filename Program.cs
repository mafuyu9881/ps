using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!); // [1, 200'000]
        StringBuilder output = new();
        for (int i = 0; i < t; ++i) // max tc = 200'000
        {
            int squares = int.Parse(Console.ReadLine()!); // [1, 1'000'000'000]

            int low = 2 - 1;
            int high = 31623 * 2 + 1; // sqrt(1'000'000'000) = 31622.xxx
            while (low < high - 1)
            {
                int mid = (low + high) / 2;

                int side0 = mid / 2;
                int side1 = (mid + 1) / 2;

                if (side0 * side1 < squares)
                {
                    low = mid;
                }
                else
                {
                    high = mid;
                }
            }
            output.AppendLine($"{high * 2}");
        }
        Console.Write(output);
    }
}