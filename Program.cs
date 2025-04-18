using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        const int Nodes = 1024;

        int t = int.Parse(Console.ReadLine()!);

        bool[] visited = new bool[Nodes];
        
        StringBuilder sb = new();
        for (int i = 0; i < t; ++i)
        {
            for (int j = 0; j < visited.Length; ++j)
            {
                visited[j] = false;
            }

            int[] ab = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int a = ab[0];
            int b = ab[1];

            int m = 1;
            {
                for (int v = a; v > 0; v /= 2)
                {
                    visited[v] = true;
                }

                for (int v = b; v > 0; v /= 2)
                {
                    if (visited[v] == false)
                        continue;

                    m = Math.Max(m, v);
                }
            }

            sb.AppendLine($"{m * 10}");
        }
        Console.Write(sb);
    }
}