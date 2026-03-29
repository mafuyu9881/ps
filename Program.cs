public class Program
{
    public static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int s1 = tokens[0];
        int s2 = tokens[1];
        if (s2 % 2 == 1)
        {
            s2 += 1;
        }
        Console.Write((s1 >= s2 / 2) ? "E" : "H");
    }
}