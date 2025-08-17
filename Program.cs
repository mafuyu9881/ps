class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int hh = tokens[0];
        int mm = tokens[1];
        Console.Write((hh - 9) * 60 + mm);
    }
}