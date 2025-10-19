class Program
{
    static void Main(string[] args)
    {
        const int HourMinutes = 60;
        const int DayMinutes = 24 * HourMinutes;

        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int start = 11 * DayMinutes + 11 * HourMinutes + 11;
        int end = tokens[0] * DayMinutes + tokens[1] * HourMinutes + tokens[2];

        int interval = end - start;
        if (interval < 0)
        {
            interval = -1;
        }

        Console.Write(interval);
    }
}