class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int x = tokens[0];
        int y = tokens[1];
        int w = tokens[2];
        int h = tokens[3];
        
        int[] distances = new int[]
        {
            x,
            y,
            w - x,
            h - y,
        };

        Console.Write(distances.Min());
    }
}