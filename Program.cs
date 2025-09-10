class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int a = tokens[0];
        int b = tokens[1];
        int c = tokens[2];
        int d = int.Parse(Console.ReadLine()!);

        int minuteInSeconds = 60;
        int hourInSeconds = minuteInSeconds * minuteInSeconds;
        int dayInSeconds = hourInSeconds * 24;

        int oldTotalSeconds = a * hourInSeconds + b * minuteInSeconds + c;
        int newTotalSeconds = (oldTotalSeconds + d) % dayInSeconds;
        Console.Write($"{newTotalSeconds / hourInSeconds} {(newTotalSeconds % hourInSeconds) / minuteInSeconds} {newTotalSeconds % minuteInSeconds}");
    }
}