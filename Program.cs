internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<string, string> schools = new()
        {
            { "NLCS", "North London Collegiate School" },
            { "BHA", "Branksome Hall Asia" },
            { "KIS", "Korea International School" },
            { "SJA", "St. Johnsbury Academy" },
        };

        Console.Write(schools[Console.ReadLine()!]);
    }
}