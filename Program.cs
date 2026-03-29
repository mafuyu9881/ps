public class Program
{
    public static void Main(string[] args)
    {
        string s = Console.ReadLine()!;
        int n = int.Parse(s);

        string output;
        if (s.Contains("7") == false && n % 7 != 0)
        {
            output = "0";
        }
        else if (s.Contains("7") == false && n % 7 == 0)
        {
            output = "1";
        }
        else if (n % 7 != 0)
        {
            output = "2";
        }
        else
        {
            output = "3";
        }
        Console.Write(output);
    }
}