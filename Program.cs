using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int q = int.Parse(Console.ReadLine()!); // [3, 500'000]

        LinkedList<int> ll = new();

        StringBuilder sb = new();
        for (int i = 0; i < q; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int command = tokens[0]; // [1, 2]

            if (command == 1)
            {
                int x = tokens[1]; // [1, 1'000]
                ll.AddLast(x);
            }
            else // if (command == 2)
            {
                int leftSum = 0;
                int rightSum = 0;

                int counter = 1;
                for (var lln = ll.First; lln != null; lln = lln.Next)
                {
                    if (counter > ll.Count / 2)
                    {
                        rightSum += lln.Value;
                    }
                    else
                    {
                        leftSum += lln.Value;
                    }
                    ++counter;
                }

                if (leftSum <= rightSum)
                {
                    sb.AppendLine($"{leftSum}");

                    int loops = ll.Count / 2;
                    while (loops > 0)
                    {
                        ll.RemoveFirst();
                        --loops;
                    }
                }
                else
                {
                    sb.AppendLine($"{rightSum}");

                    int loops = ll.Count - ll.Count / 2;
                    while (loops > 0)
                    {
                        ll.RemoveLast();
                        --loops;
                    }
                }
            }
        }

        for (var lln = ll.First; lln != null; lln = lln.Next)
        {
            sb.Append($"{lln.Value} ");
        }

        Console.Write(sb);
    }
}