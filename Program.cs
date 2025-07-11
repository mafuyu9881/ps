using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 200'000]

        // length = n
        // element = [1, 1'000'000'000]
        int[] arr = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int max = 1;
        int min = 1000000000;

        int maxDiff = 0;

        StringBuilder sb = new();
        for (int i = 0; i < n; ++i)
        {
            int elem = arr[i];

            max = Math.Max(max, arr[i]);

            if (elem < min)
            {
                min = elem;
                max = elem;
            }

            maxDiff = Math.Max(maxDiff, max - min);

            sb.Append($"{maxDiff} ");
        }
        Console.Write(sb);
    }
}