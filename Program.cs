using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int birthYear = tokens[0];
        int birthMonth = tokens[1];
        int birthDay = tokens[2];

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int currYear = tokens[0];
        int currMonth = tokens[1];
        int currDay = tokens[2];

        int standard = currYear - birthYear;
        if (currYear > birthYear)
        {
            if ((currMonth < birthMonth) ||
                (currMonth == birthMonth && currDay < birthDay))
            {
                --standard;
            }
        }
        
        int count = currYear - birthYear + 1;

        int year = currYear - birthYear;

        StringBuilder output = new();
        output.AppendLine($"{standard}");
        output.AppendLine($"{count}");
        output.AppendLine($"{year}");
        Console.Write(output);
    }
}