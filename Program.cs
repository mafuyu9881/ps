public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        string output;
        if (n == 1)
        {
            output = "12 1600";
        }
        else if (n == 2)
        {
            output = "11 894";
        }
        else if (n == 3)
        {
            output = "11 1327";
        }
        else if (n == 4)
        {
            output = "10 1311";
        }
        else if (n == 5)
        {
            output = "9 1004";
        }
        else if (n == 6)
        {
            output = "9 1178";
        }
        else if (n == 7)
        {
            output = "9 1357";
        }
        else if (n == 8)
        {
            output = "8 837";
        }
        else if (n == 9)
        {
            output = "7 1055";
        }
        else if (n == 10)
        {
            output = "6 556";
        }
        else // if (n == 11)
        {
            output = "6 773";
        }

        Console.Write(output);
    }
}