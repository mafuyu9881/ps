class Program
{
    static void Main(string[] args)
    {
        string s = "WelcomeToSMUPC";

        int n = int.Parse(Console.ReadLine()!);
        n = (n - 1) % 14;

        Console.Write(s[n]);
    }
}