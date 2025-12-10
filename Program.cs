class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];
        int m = tokens[1];

        string output;
        if (m < 3)
        {
            output = "NEWBIE!";
        }
        else if (m >= 3 && m <= n)
        {
            output = "OLDBIE!";
        }
        else
        {
            output = "TLE!";
        }
        Console.Write(output);
    }
}