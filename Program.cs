using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!); // [1, 5]

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int n = tokens[0]; // [2, 20]
            int m = tokens[1]; // [2, 20]
            int k = tokens[2]; // [2, min(n, m, 10)]

            // length = n
            // element = [1, 10^8]
            int[] bSet = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            // length = m
            // element = [1, 10^8]
            int[] aSet = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            List<int> bSetSums = new(1048576);
            List<int> aSetSums = new(1048576);
            ComputeSums(0, 0, 0, k, bSet, bSetSums);
            ComputeSums(0, 0, 0, k, aSet, aSetSums);
            bSetSums.Sort();
            aSetSums.Sort();

            int min = int.MaxValue;
            {
                int j = 0;
                int l = 0;
                while (j < bSetSums.Count && l < aSetSums.Count)
                {
                    int bSetSum = bSetSums[j];
                    int aSetSum = aSetSums[l];

                    min = Math.Min(min, Math.Abs(bSetSum - aSetSum));

                    if (bSetSum < aSetSum)
                    {
                        ++j;
                    }
                    else if (bSetSum > aSetSum)
                    {
                        ++l;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            int max = Math.Max(Math.Abs(bSetSums[0] - aSetSums[aSetSums.Count - 1]),
                               Math.Abs(bSetSums[bSetSums.Count - 1] - aSetSums[0]));

            sb.AppendLine($"{min} {max}");
        }
        Console.Write(sb);
    }

    // tc <= 2^20
    static void ComputeSums(int index, int taken, int setSum, int k, int[] set, List<int> setSums)
    {
        if (taken == k)
        {
            setSums.Add(setSum);
        }
        else
        {
            if (index < set.Length)
            {
                ComputeSums(index + 1, taken + 1, setSum + set[index], k, set, setSums);
                ComputeSums(index + 1, taken, setSum, k, set, setSums);
            }
        }
    }
}