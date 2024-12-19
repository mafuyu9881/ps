internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // 1 ≤ n ≤ 200,000

        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // 1 ≤ Si ≤ 9

        int begin = 0;
        int end = 0;

        bool[] included = new bool[10];
        LinkedList<int> includedNumbers = new();
        included[begin] = true;
        includedNumbers.AddLast(begin);

        int minimumLength = 1;
        int length = 1;
        while (true)
        {
            //if (begin < end)
            //{
            //}
            //else
            //{
            //    ++end;
            //    if (end > tokens.Length - 1)
            //    {
            //        break;
            //    }
            //}

            ++end;

            int endNumber = tokens[end];

            if (included[endNumber])
            {
                ++length;
            }
            else
            {
                if (includedNumbers.Count < 2)
                {
                    included[endNumber] = true;
                    includedNumbers.AddLast(endNumber);
                }
                else
                {
                    //var firstIncludedNumberNode = includedNumbers.First!;
                    //int firstIncludedNumber = firstIncludedNumberNode.Value;
                    //includedNumbers.Remove(firstIncludedNumberNode);
                    //included[firstIncludedNumber] = false;
                    //length = 
                    
                }
            }
        }
    }
}