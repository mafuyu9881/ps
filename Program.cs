using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        StringBuilder output = new();
        int t = int.Parse(Console.ReadLine()!); // 1 ≤ t ≤ 10
        for (int i = 0; i < t; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int j = tokens[0]; // 1 ≤ j ≤ 1,000
            int n = tokens[1]; // 1 ≤ n ≤ 1,000
            
            int[] boxArray = new int[n];
            for (int k = 0; k < n; ++k)
            {
                tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
                int r = tokens[0]; // 1 ≤ r ≤ 10,000
                int c = tokens[1]; // 1 ≤ c ≤ 10,000
                boxArray[k] = r * c;
            }
            Array.Sort(boxArray);
            Array.Reverse(boxArray);

            LinkedList<int> boxLinkedList = new LinkedList<int>();
            for (int k = 0; k < boxArray.Length; ++k)
            {
                boxLinkedList.AddLast(boxArray[k]);
            }

            int usedBoxCount = 0;
            while (j > 0)
            {
                j -= boxLinkedList.First!.Value;
                boxLinkedList.RemoveFirst();
                ++usedBoxCount;
            }
            output.AppendLine($"{usedBoxCount}");
        }
        Console.Write(output);
    }
}