class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int[] junks = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int waitingDays = 0;
        for (int i = 0; i < junks.Length; ++i)
        {
            if (junks[waitingDays] > junks[i])
            {
                waitingDays = i;
            }
        }
        Console.Write(waitingDays);
    }
}