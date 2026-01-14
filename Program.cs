class Program
{
    static void Main(string[] args)
    {
        const int Width = 4;

        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int a = tokens[0];
        int b = tokens[1];

        int aIndex = a - 1;
        int bIndex = b - 1;

        int aRow = aIndex / Width;
        int aCol = aIndex % Width;

        int bRow = bIndex / Width;
        int bCol = bIndex % Width;

        Console.Write(Math.Abs(bRow - aRow) + Math.Abs(bCol - aCol));
    }
}