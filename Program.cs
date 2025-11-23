class Program
{
    static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int ax = tokens[0];
        int ay = tokens[1];
        int az = tokens[2];

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int cx = tokens[0];
        int cy = tokens[1];
        int cz = tokens[2];
        
        Console.Write($"{cx - az} {cy / ay} {cz - ax}");
    }
}