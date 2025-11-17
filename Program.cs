class Program
{
    static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int a1 = tokens[0];
        int p1 = tokens[1];
        double ratio1 = (double)a1 / p1;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int r1 = tokens[0];
        int p2 = tokens[1];
        double a2 = r1 * r1 * 3.141592653589793;
        
        double ratio2 = a2 / p2;

        string output;
        if (ratio1 > ratio2)
        {
            output = "Slice of pizza";
        }
        else
        {
            output = "Whole pizza";
        }
        Console.Write(output);
    }
}