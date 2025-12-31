class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        string output = "No";
        for (int i = 0; i < n; ++i)
        {
            string s = Console.ReadLine()!;

            if (s == "Never gonna give you up" ||
                s == "Never gonna let you down" ||
                s == "Never gonna run around and desert you" ||
                s == "Never gonna make you cry" ||
                s == "Never gonna say goodbye" ||
                s == "Never gonna tell a lie and hurt you" ||
                s == "Never gonna stop")
                continue;

            output = "Yes";
            break;
        }

        Console.Write(output);
    }
}