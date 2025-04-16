using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        StringBuilder sb = new();
        while (true)
        {
            // length = 2
            // element = [0, 1'000'000]
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int n = tokens[0];
            int m = tokens[0];
            if (n == 0 && m == 0)
                break;

            int[] nCDs = new int[n];
            for (int i = 0; i < nCDs.Length; ++i)
            {
                nCDs[i] = int.Parse(Console.ReadLine()!);
            }
            int[] mCDs = new int[m];
            for (int i = 0; i < mCDs.Length; ++i)
            {
                mCDs[i] = int.Parse(Console.ReadLine()!);
            }

            int sells = 0;
            {
                int i = 0;
                int j = 0;
                while (i < nCDs.Length && j < mCDs.Length)
                {
                    int nCD = nCDs[i];
                    int mCD = mCDs[j];

                    if (nCD == mCD)
                    {
                        ++sells;
                    }

                    if (nCD < mCD)
                    {
                        ++i;
                    }
                    else
                    {
                        ++j;
                    }
                }
            }
            sb.AppendLine($"{sells}");
        }
        Console.Write(sb);
    }
}