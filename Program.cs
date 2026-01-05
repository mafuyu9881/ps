class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int sum = 0;
        for (int i = 0; i < n; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int width = tokens[0];

            if (width == 136)
            {
                sum += 1000;
            }
            else if (width == 142)
            {
                sum += 5000;
            }
            else if (width == 148)
            {
                sum += 10000;
            }
            else if (width == 154)
            {
                sum += 50000;
            }
        }
        
        Console.Write(sum);
    }
}