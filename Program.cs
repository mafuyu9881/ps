class Program
{
    static void Main(string[] args)
    {
        int limit = int.Parse(Console.ReadLine()!);
        int recorded = int.Parse(Console.ReadLine()!);
        int over = recorded - limit;

        int fine = 0;
        if (over > 30)
        {
            fine = 500;
        }
        else if (over > 20)
        {
            fine = 270;
        }
        else if (over > 1)
        {
            fine = 100;
        }

        string output;
        if (fine > 0)
        {
            output = $"You are speeding and your fine is ${fine}.";
        }
        else
        {
            output = "Congratulations, you are within the speed limit!";
        }
        Console.Write(output);
    }
}