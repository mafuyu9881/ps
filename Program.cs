using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 100'000]

        // length = [1, 100'000]
        int[] a = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int[] b = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Array.Sort(a); // max tc = 100'000 * log2(100'000) = 100'000 * 16.xxx
        Array.Sort(b); // max tc = 100'000 * 16.xxx
        
        int pairs = 0;
        int i = 0;
        int j = 0;
        LinkedList<int> pairedAElements = new();
        LinkedList<int> unpairedAElements = new();
        LinkedList<int> pairedBElements = new();
        LinkedList<int> unpairedBElements = new();
        while (i >= 0 && i < a.Length && // max tc = 100'000
               j >= 0 && j < b.Length)
        {
            if (a[i] == b[j])
            {
                ++pairs;

                pairedAElements.AddLast(a[i]);
                pairedBElements.AddLast(b[j]);

                ++i;
                ++j;
            }
            else if (a[i] > b[j])
            {
                unpairedBElements.AddLast(b[j]);

                ++j;
            }
            else
            {
                unpairedAElements.AddLast(a[i]);

                ++i;
            }
        }

        StringBuilder sb = new();
        sb.AppendLine($"{pairs}");
        PrintArray(sb, pairedAElements, unpairedAElements, a, i);
        PrintArray(sb, pairedBElements, unpairedBElements, b, j);
        Console.Write(sb);
    }

    // max tc = 100'000
    private static void PrintArray(StringBuilder sb, LinkedList<int> pairedElements, LinkedList<int> unpairedElements, int[] elements, int iteratableIndex)
    {
        for (var lln = pairedElements.First; lln != null; lln = lln.Next)
        {
            sb.Append($"{lln.Value} ");
        }
        for (var lln = unpairedElements.First; lln != null; lln = lln.Next)
        {
            sb.Append($"{lln.Value} ");
        }
        for (int k = iteratableIndex; k < elements.Length; ++k)
        {
            sb.Append($"{elements[k]} ");
        }
        sb.AppendLine();
    }
}