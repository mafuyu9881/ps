class Program
{
    static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int p1 = tokens[0];
        int s1 = tokens[1];

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int s2 = tokens[0];
        int p2 = tokens[1];

        int pSum = p1 + p2;
        int sSum = s1 + s2;
        
        const string Persepolis = "Persepolis";
        const string Esteghlal = "Esteghlal";
        const string Penalty = "Penalty";

        string output;
        if (pSum > sSum)
        {
            output = Persepolis;
        }
        else if (pSum == sSum)
        {
            if (p2 > s1)
            {
                output = Persepolis;
            }
            else if (p2 == s1)
            {
                output = Penalty;
            }
            else
            {
                output = Esteghlal;
            }
        }
        else
        {
            output = Esteghlal;
        }
        Console.Write(output);
    }
}