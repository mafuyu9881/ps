class Program
{
    static void Main(string[] args)
    {
        string s = "WelcomeToSMUPC";

        int n = int.Parse(Console.ReadLine()!);
        n %= 14;
        n -= 1;

        Console.Write(s[n]);
    }
}