class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split('/'), int.Parse);
        int k = tokens[0];
        int d = tokens[1];
        int a = tokens[2];

        string output;
        if (k + a < d || d == 0)
        {
            output = "hasu";
        }
        else
        {
            output = "gosu";
        }
        Console.Write(output);
    }
}