internal class Program
{
    private static void Main(string[] args)
    {
        string input = Console.ReadLine()!;

        string output;
        if (input == "SONGDO")
        {
            output = "HIGHSCHOOL";
        }
        else if (input == "CODE")
        {
            output = "MASTER";
        }
        else if (input == "2023")
        {
            output = "0611";
        }
        else
        {
            output = "CONTEST";
        }
        Console.Write(output);
    }
}