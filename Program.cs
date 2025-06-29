class Program
{
    static void Main(string[] args)
    {
        // length = 3
        // element = [1, 1'000]
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int a = tokens[0];
        int b = tokens[1];
        int c = tokens[2];
        Console.Write(b / a * 3 * c);
    }
}