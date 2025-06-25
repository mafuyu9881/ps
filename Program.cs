using System.Text;

class Program
{
    static void Main(string[] args)
    {
        List<int> prefixSum = new(100000);
        prefixSum.Add(0);
        prefixSum.Add(1);

        StringBuilder sb = new();
        while (true)
        {
            int n = int.Parse(Console.ReadLine()!);
            if (n == 0)
                break;

            while (prefixSum.Count - 1 < n)
            {
                prefixSum.Add(prefixSum.Count + prefixSum[prefixSum.Count - 1]);
            }

            sb.AppendLine($"{prefixSum[n]}");
        }
        Console.Write(sb);
    }
}