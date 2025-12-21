class Program
{
    static void Main(string[] args)
    {
        int x = int.Parse(Console.ReadLine()!);
        
        int n = int.Parse(Console.ReadLine()!);

        int sum = 0;
        for (int i = 0; i < n; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            sum += tokens[0] * tokens[1];
        }

        Console.Write((sum == x) ? "Yes" : "No");
    }
}