internal class Program
{
    private static void Main(string[] args)
    {
        string s0 = Console.ReadLine()!;
        string s1 = Console.ReadLine()!;
        Console.Write((s0.Length >= s1.Length) ? "go" : "no");
    }
}