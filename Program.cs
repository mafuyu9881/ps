internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 100]

        string s;
        if (n < 3)
        {
            s = "1";
        }
        else if (n < 6)
        {
            s = "2";
        }
        else
        {
            s = "3";
        }
        Console.Write(s);
    }
}