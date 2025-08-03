class Program
{
    static void Main(string[] args)
    {
        int[] sequence = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        char output = 'S';
        for (int i = 0; i < sequence.Length; ++i)
        {
            int bit = sequence[i];
            if (bit == 0 || bit == 1)
                continue;

            output = 'F';
            break;
        }
        Console.Write(output);
    }
}