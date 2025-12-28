class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = tokens[0];
        int width = tokens[1];
        int index = tokens[2];
        Console.Write($"{index / width} {index % width}");
    }
}