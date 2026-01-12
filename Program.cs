class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int ySum = 0;
        int mSum = 0;
        for (int i = 0; i < n; ++i)
        {
            int token = tokens[i];
            ySum += (token / 30 + 1) * 10;
            mSum += (token / 60 + 1) * 15;
        }
        
        string output;
        if (ySum < mSum)
        {
            output = $"Y {ySum}";
        }
        else if (ySum > mSum)
        {
            output = $"M {mSum}";
        }
        else
        {
            output = $"Y M {ySum}";
        }
        Console.Write(output);
    }
}