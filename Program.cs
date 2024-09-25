// 1 ≤ N ≤ 500,000

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        LinkedList<int> list = new();
        for (int i = 0; i < n; ++i)
        {
            list.AddLast(i + 1);
        }

        while (list.Count > 1)
        {
            list.RemoveFirst();
            list.AddLast(list.First!.Value);
            list.RemoveFirst();
        }

        Console.Write(list.First!.Value);
    }
}