class Program
{
    static void Main(string[] args)
    {
        const int MaxPrice = 2000;

        int burger = MaxPrice;
        for (int i = 0; i < 3; ++i)
        {
            burger = Math.Min(burger, int.Parse(Console.ReadLine()!));
        }

        int beverage = MaxPrice;
        for (int i = 0; i < 2; ++i)
        {
            beverage = Math.Min(beverage, int.Parse(Console.ReadLine()!));
        }

        Console.Write(burger + beverage - 50);
    }
}