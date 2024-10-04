internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();

        int n1 = int.Parse(tokens[0]);
        int k1 = int.Parse(tokens[1]);
        int n2 = int.Parse(tokens[2]);
        int k2 = int.Parse(tokens[3]);
        
        Console.Write(n1 * k1 + n2 * k2);
    }
}