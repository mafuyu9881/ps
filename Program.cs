class Program
{
    static void Main(string[] args)
    {
        SortedDictionary<int, int> sd = new();
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int i = 0; i < tokens.Length; ++i)
            {
                sd.Add(tokens[i], i + 1);
            }
        }

        int intersected = 0;
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            if (sd.TryGetValue(tokens[0], out int value))
            {
                intersected = value;
            }
        }
        Console.Write(intersected);
    }
}