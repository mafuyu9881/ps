class Program
{
    static void Main(string[] args)
    {
        int[] scienceScores = new int[4];
        for (int i = 0; i < scienceScores.Length; ++i)
        {
            scienceScores[i] = int.Parse(Console.ReadLine()!);
        }
        Array.Sort(scienceScores);

        int[] socialScores = new int[2];
        for (int i = 0; i < socialScores.Length; ++i)
        {
            socialScores[i] = int.Parse(Console.ReadLine()!);
        }
        Array.Sort(socialScores);

        int sum = 0;
        for (int i = 0; i < 3; ++i)
        {
            sum += scienceScores[scienceScores.Length - 1 - i];
        }
        sum += socialScores[socialScores.Length - 1];
        Console.Write(sum);
    }
}