class Program
{
    static void Main(string[] args)
    {
        const int InvalidMinute = -1;

        int n = int.Parse(Console.ReadLine()!);

        int minimumMinute = InvalidMinute;
        for (int i = 0; i < n; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int a = tokens[0];
            int b = tokens[1];

            if (a > b)
                continue;

            if (minimumMinute != InvalidMinute &&
                minimumMinute <= b)
                continue;

            minimumMinute = b;
        }

        Console.Write(minimumMinute);
    }
}