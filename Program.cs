class Program
{
    static void Main(string[] args)
    {
        string s = "WelcomeToSMUPC";

        int n = int.Parse(Console.ReadLine()!);
        if (n % 14 == 0)
        {
            n = 14;
        }
        else
        {
            n %= 14;
        }
        n -= 1;

        Console.Write(s[n]);
    }
}