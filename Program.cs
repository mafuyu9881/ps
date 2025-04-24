internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int[] sequence = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Array.Sort(sequence);

        for (int i = 1; i < sequence.Length; ++i)
        {
            if (sequence[i] == sequence[i - 1])
            {
                Console.Write(sequence[i]);
                break;
            }
        }
    }
}