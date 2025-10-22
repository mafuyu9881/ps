class Program
{
    static void Main(string[] args)
    {
        int depth0 = int.Parse(Console.ReadLine()!);
        int depth1 = int.Parse(Console.ReadLine()!);
        int depth2 = int.Parse(Console.ReadLine()!);
        int depth3 = int.Parse(Console.ReadLine()!);

        string output;
        if (depth0 < depth1 && depth1 < depth2 && depth2 < depth3)
        {
            output = "Fish Rising";
        }
        else if (depth0 > depth1 && depth1 > depth2 && depth2 > depth3)
        {
            output = "Fish Diving";
        }
        else if (depth0 == depth1 && depth1 == depth2 && depth2 == depth3)
        {
            output = "Fish At Constant Depth";
        }
        else
        {
            output = "No Fish";
        }
        Console.Write(output);
    }
}