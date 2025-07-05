class Program
{
    static void Main(string[] args)
    {
        string s = Console.ReadLine()!;

        string output;
        if (s == "M")
        {
            output = "MatKor";
        }
        else if (s == "W")
        {
            output = "WiCys";
        }
        else if (s == "C")
        {
            output = "CyKor";
        }
        else if (s == "A")
        {
            output = "AlKor";
        }
        else
        {
            output = "$clear";
        }
        Console.Write(output);
    }
}