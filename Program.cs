public class Program
{
    public static void Main(string[] args)
    {
        int floor = int.Parse(Console.ReadLine()!);

        if (floor > 12)
        {
            floor += 1;
        }

        Console.Write(floor);
    }
}