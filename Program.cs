class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int s = tokens[0];
        int k = tokens[1];
        int h = tokens[2];
        int sum = s + k + h;
        int min = Math.Min(s, Math.Min(k, h));

        string output;
        if (sum >= 100)
        {
            output = "OK";
        }
        else if (s == min)
        {
            output = "Soongsil";
        }
        else if (k == min)
        {
            output = "Korea";
        }
        else// if (h == min)
        {
            output = "Hanyang";
        }

        Console.Write(output);
    }
}