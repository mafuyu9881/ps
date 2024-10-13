internal class Program
{
    private static void Main(string[] args)
    {
        double[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), double.Parse);

        double area = tokens[0] * tokens[1] * 0.5;
        
        Console.Write(area.ToString("0.0"));
    }
}