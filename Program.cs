class Program
{
    static void Main(string[] args)
    {
        int aSum = 0;
        aSum += int.Parse(Console.ReadLine()!) * 3;
        aSum += int.Parse(Console.ReadLine()!) * 2;
        aSum += int.Parse(Console.ReadLine()!) * 1;

        int bSum = 0;
        bSum += int.Parse(Console.ReadLine()!) * 3;
        bSum += int.Parse(Console.ReadLine()!) * 2;
        bSum += int.Parse(Console.ReadLine()!) * 1;

        string output;
        if (aSum > bSum)
        {
            output = "A";
        }
        else if (aSum < bSum)
        {
            output = "B";
        }
        else
        {
            output = "T";
        }

        Console.Write(output);
    }
}