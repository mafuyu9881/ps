internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();

        float n1 = float.Parse(tokens[0]);
        float n2 = float.Parse(tokens[1]);
        float n12 = float.Parse(tokens[2]);
        
        Console.Write((int)((n1 + 1) * (n2 + 1) / (n12 + 1) - 1.0f));
    }
}