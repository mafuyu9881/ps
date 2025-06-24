using System.Text;

class Program
{
    static void Main(string[] args)
    {
        long[] counts = new long[100000 + 1];
        for (int i = 2; i < counts.Length; ++i)
        {
            counts[i] = counts[i - 1] + (i - 2 + 1);
        }

        int t = int.Parse(Console.ReadLine()!); // [1, 10]

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i)
        {
            int n = int.Parse(Console.ReadLine()!); // [1, 100'000]

            // length = n
            // element = [-1'000'000'000, 1'000'000'000]
            int[] sequence = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            // lo = [0, sequence.Length - 1]
            // hi = [lo + 1, sequence.Length - 1]
            Func<int, int, bool> Zigzag = (lo, hi) =>
            {
                if (hi - lo + 1 < 3)
                {
                    return sequence[hi] != sequence[hi - 1];
                }
                else
                {
                    if (sequence[hi] > sequence[hi - 1] && sequence[hi - 2] > sequence[hi - 1])
                        return true;
                    
                    if (sequence[hi] < sequence[hi - 1] && sequence[hi - 2] < sequence[hi - 1])
                        return true;

                    return false;
                }
            };

            long count = 0;
            int lo = 0;
            int hi = 0;
            while (true)
            {
                if (hi - lo + 1 < 2)
                    hi = lo + 1;

                if (hi > sequence.Length - 1)
                    break;

                long increment = 0;
                while (hi < sequence.Length)
                {
                    if (Zigzag(lo, hi))
                    {
                        increment = counts[hi - lo + 1];
                        ++hi;
                    }
                    else
                    {
                        break;
                    }
                }
                
                count += increment;

                lo = (increment > 0) ? hi - 1 : hi;
            }
            sb.AppendLine($"{count}");
        }
        Console.Write(sb);
    }
}