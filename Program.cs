using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int[] sequence = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Array.Sort(sequence);
        StringBuilder sb = new();
        for (int i = 0; i < sequence.Length; ++i)
        {
            sb.Append($"{sequence[i]} ");
        }
        Console.Write(sb);
    }
}