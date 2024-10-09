internal class Program
{
    private static void Main(string[] args)
    {
        const long InvalidLength = -1;

        long[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), long.Parse);

        long k = tokens[0];
        long n = tokens[1];

        long maxLength = InvalidLength;
        long[] lengths = new long[k];
        for (long i = 0; i < lengths.Length; ++i)
        {
            long length = long.Parse(Console.ReadLine()!);

            if (maxLength == InvalidLength || length > maxLength)
            {
                maxLength = length;
            }

            lengths[i] = length;
        }

        long bottom = 1;
        long top = maxLength;
        long answerLength = InvalidLength;
        while (bottom <= top)
        {
            long mid = (bottom + top) / 2;

            long counts = 0;
            for (long i = 0; i < lengths.Length; ++i)
            {
                counts += lengths[i] / mid;
            }
            
            if (counts >= n)
            {
                answerLength = mid;
                bottom = mid + 1;
            }
            else
            {
                top = mid - 1;
            }
        }
        Console.Write(answerLength);
    }
}