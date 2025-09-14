class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int sum = tokens[0];
        int diff = tokens[1];

        string output;
        if ((sum >= diff) && (sum % 2 == diff % 2))
        {
            int a = (sum + diff) / 2;
            int b = (sum - diff) / 2;
            output = $"{a} {b}";
        }
        else
        {
            output = "-1";
        }
        Console.Write(output);
    }
}