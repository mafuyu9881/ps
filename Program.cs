class Program
{
    static void Main(string[] args)
    {
        int month = int.Parse(Console.ReadLine()!);
        int day = int.Parse(Console.ReadLine()!);

        string answer = "Special";
        if ((month < 2) ||
            (month == 2 && day < 18))
        {
            answer = "Before";
        }
        else if ((month > 2) ||
                 (month == 2 && day > 18))
        {
            answer = "After";
        }
        Console.Write(answer);
    }
}