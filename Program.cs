class Program
{
    static void Main(string[] args)
    {
        int[] tokens = new int[3];
        tokens[0] = int.Parse(Console.ReadLine()!);
        tokens[1] = int.Parse(Console.ReadLine()!);
        tokens[2] = int.Parse(Console.ReadLine()!);
        Array.Sort(tokens);
        Console.Write(tokens[1]);
    }
}