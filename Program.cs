class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int a = tokens[0];
        int b = tokens[1];
        
        int c = int.Parse(Console.ReadLine()!);

        int sum = a + b;

        Console.Write((sum >= c * 2) ? sum - c * 2 : sum);
    }
}