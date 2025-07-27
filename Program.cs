class Program
{
    static void Main(string[] args)
    {
        const int Years = 12;

        int n = int.Parse(Console.ReadLine()!); // [1, 5]

        int year = 2024;
        int month = 8;

        month += 7 * (n - 1);

        if (month > Years)
        {
            year += month / Years;
            month %= Years;
        }

        Console.Write($"{year} {month}");
    }
}