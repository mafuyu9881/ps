class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int startHour = tokens[0];
        int startMinute = tokens[1];

        int cookingMinutes = int.Parse(Console.ReadLine()!);

        int endHour = (startHour + (startMinute + cookingMinutes) / 60) % 24;
        int endMinute = (startMinute + cookingMinutes) % 60;

        Console.Write($"{endHour} {endMinute}");
    }
}