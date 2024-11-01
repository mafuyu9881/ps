internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        int halfN = n / 2;

        int[] arr = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int backIndex = arr.Length - 1;

        int output = 0;
        for (int frontIndex = 0; (frontIndex < halfN) && (backIndex > halfN); ++frontIndex)
        {
            int frontElement = arr[frontIndex];

            if (frontElement % 2 == 0)
                continue;

            while (backIndex > halfN)
            {
                int backElement = arr[backIndex];

                if (backElement % 2 != 0)
                    continue;

                arr[frontIndex] = backElement;
                arr[backIndex] = frontElement;
                ++output;

                --backIndex;
            }
        }
        Console.Write(output);
    }
}