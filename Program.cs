internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int[] arr = new int[n];
        for (int i = 0; i < n; ++i)
        {
            arr[i] = int.Parse(Console.ReadLine()!);
        }
        Array.Sort(arr);

        int minRequired = 4;
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                int j = i + 1;
                while (j < arr.Length && arr[j] - arr[i] < 5)
                {
                    ++j;
                }
                minRequired = Math.Min(minRequired, 5 - (j - i));
            }
        }
        Console.Write(minRequired);
    }
}