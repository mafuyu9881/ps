internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // 0 <= n <= 50
        int m = tokens[1]; // 1 <= m <= 1,000

        // It may feel quite inefficient.
        // But to write the code that computes box count more clearly,
        // I should make a conditional statement right here.
        // I guess this input code can be written in better form with C++,
        // by virtue of the mechanism of the std::cin.
        int[] bookWeights; // 1 <= books[i] <= m
        if (n > 0)
        {
            bookWeights = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        }
        else
        {
            bookWeights = new int[0];
        }

        int boxCount = 0;
        int boxWeight = m;
        for (int i = 0; i < bookWeights.Length; ++i)
        {
            int bookWeight = bookWeights[i];

            boxWeight += bookWeight;

            if (boxWeight > m)
            {
                boxWeight = bookWeight;
                ++boxCount;
            }
        }
        Console.Write(boxCount);
    }
}