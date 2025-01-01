using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        StringBuilder[] commands = new StringBuilder[10000];
        for (int i = 0; i < commands.Length; ++i) // tc = 10000
        {
            commands[i] = new();
        }

        StringBuilder output = new();
        int t = int.Parse(Console.ReadLine()!);
        for (int i = 0; i < t; ++i) // max tc = unknown
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int a = tokens[0]; // [0, 10000)
            int b = tokens[1];

            for (int j = 0; j < commands.Length; ++j) // tc = 10000
            {
                commands[j].Clear();
            }
            Queue<int> visitingQueue = new();

            visitingQueue.Enqueue(a);
            while (visitingQueue.Count > 0) // max tc = 10000
            {
                int v = visitingQueue.Dequeue();
                int newCost = commands[v].Length + 1;

                char[] adjCommands = new char[4]
                {
                    'D',
                    'S',
                    'L',
                    'R',
                };
                int[] adjVs = new int[4]
                {
                    CommandD(v),
                    CommandS(v),
                    CommandL(v),
                    CommandR(v),
                };

                for (int j = 0; j < adjVs.Length; ++j) // tc = 4
                {
                    int adjV = adjVs[j];

                    if (adjV == a)
                        continue;

                    if (commands[adjV].Length > 0)
                        continue;

                    commands[adjV].Append(commands[v]);
                    commands[adjV].Append(adjCommands[j]);
                    visitingQueue.Enqueue(adjV);
                }
            }

            output.AppendLine($"{commands[b]}");
        }
        Console.Write(output);
    }

    private static int CommandD(int input)
    {
        return (input * 2) % 10000;
    }

    private static int CommandS(int input)
    {
        if (--input < 0)
        {
            input = 9999;
        }
        return input;
    }

    private static int CommandL(int input)
    {
        int d1 = input / 1000;
        return ((input * 10) % 10000) + d1;
    }
    
    private static int CommandR(int input)
    {
        int d4 = input % 10;
        return (input / 10) + (d4 * 1000);
    }
}