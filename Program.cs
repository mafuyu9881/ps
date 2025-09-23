class Program
{
    static void Main(string[] args)
    {
        int a = int.Parse(Console.ReadLine()!);
        int b = int.Parse(Console.ReadLine()!);
        int c = int.Parse(Console.ReadLine()!);

        string output;
        if (a + b + c == 180)
        {
            if (a == b && b == c)
            {
                output = "Equilateral";
            }
            else if (a == b || b == c || c == a)
            {
                output = "Isosceles";
            }
            else
            {
                output = "Scalene";
            }
        }
        else
        {
            output = "Error";
        }
        Console.Write(output);
    }
}