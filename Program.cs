class Program
{
    static void Main(string[] args)
    {
        float[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), float.Parse);
        float a = tokens[0];
        float b = tokens[1];

        Console.Write(((a - a * b / 100) >= 100) ? 0 : 1);
    }
}