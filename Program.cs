class Program
{
    static void Main(string[] args)
    {
        const int MinuteSeconds = 60;

        int seconds = 0;
        seconds += int.Parse(Console.ReadLine()!);
        seconds += int.Parse(Console.ReadLine()!);
        seconds += int.Parse(Console.ReadLine()!);
        seconds += int.Parse(Console.ReadLine()!);

        Console.Write($"{seconds / MinuteSeconds}\n{seconds % MinuteSeconds}");
    }
}