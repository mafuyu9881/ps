class Program
{
    static void Main(string[] args)
    {
        int youngest = int.Parse(Console.ReadLine()!);
        int middle = int.Parse(Console.ReadLine()!);
        Console.Write(middle + (middle - youngest));
    }
}