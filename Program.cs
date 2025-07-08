class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];
        int a = tokens[1];
        int b = tokens[2];

        string output = "Anything";
        if (a < b)
        {
            output = "Bus";
        }
        else if (a > b)
        {
            output = "Subway";
        }
        Console.Write(output);
    }
}