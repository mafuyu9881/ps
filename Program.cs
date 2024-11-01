internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        int halfN = n / 2;

        int[] arr = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int leftOddCount = 0;
        int leftEvenCount = 0;
        long leftOddOutput = 0;
        long leftEvenOutput = 0;
        for (int i = 0; i < n; ++i)
        {
            int element = arr[i];

            if (element % 2 != 0)
            {
                ++leftOddCount;

                leftEvenOutput += leftEvenCount;
            }
            else
            {
                ++leftEvenCount;
                
                leftOddOutput += leftOddCount;
            }
        }
        Console.Write(Math.Min(leftOddOutput, leftEvenOutput));
    }
}