class Program
{
    static void Main(string[] args)
    {
        double[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), double.Parse);
        double a = tokens[0];
        double b = tokens[1];

        double m = (b - a) / 400;

        Console.Write(1 / (1 + Math.Pow(10, m)));
    }
}