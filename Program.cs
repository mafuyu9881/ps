internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 1'000]
        int tapeLength = tokens[1]; // [1, 1'000]

        // element = [1, 1'000]
        int[] leakPoints = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Array.Sort(leakPoints);

        const int InvalidIndex = -1;

        int output = 0;

        int beginIndex = InvalidIndex;
        for (int i = 0; i < leakPoints.Length; ++i)
        {
            if (beginIndex == InvalidIndex ||
                leakPoints[i] - leakPoints[beginIndex] > tapeLength - 1)
            {
                beginIndex = i;
                ++output;
            }
        }
        
        Console.Write(output);
    }
}