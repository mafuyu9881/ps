using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        int[] holes = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int[] outHoles = new int[100000 + 1];
        int writingIndex = 1;
        for (int i = 0; i < n; ++i) // max tc = 100'000
        {
            // the ith hole's actual size is
            // (its original size) + (its order), (i starts from 0)
            // this is because the acorns shrink with each roll
            int actualHole = Math.Min(holes[i] + i, 100000); // and there is no acorn larger than 10000 (to prevent out-of-range index errors)

            while (writingIndex <= actualHole) // tc (total loops count, excluding duplicates) = 100'000
            {
                outHoles[writingIndex] = i + 1;
                ++writingIndex;
            }
        }

        int q = int.Parse(Console.ReadLine()!);
        int[] acorns = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        StringBuilder output = new();
        for (int i = 0; i < acorns.Length; ++i)
        {
            output.AppendLine($"{outHoles[acorns[i]]}");
        }
        Console.Write(output);
    }
}