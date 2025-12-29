class Program
{
    static void Main(string[] args)
    {
        double[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), double.Parse);
        double a = tokens[0];
        double b = tokens[1];
        double c = tokens[2];
        Console.Write((int)Math.Max(a * b / c, a / b * c));
    }
}