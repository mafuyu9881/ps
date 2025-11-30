class Program
{
    static void Main(string[] args)
    {
        string telephoneNumber = Console.ReadLine()!;
        Console.Write((telephoneNumber[0] == '5' && telephoneNumber[1] == '5' && telephoneNumber[2] == '5') ? "YES" : "NO");
    }
}