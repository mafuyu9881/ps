internal class Program
{
    private static void Main(string[] args)
    {
        long[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), long.Parse);
        long n = tokens[0]; // [1, 10^2]
        long t = tokens[1]; // [1, 10^18]

        int[] pointings = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        for (int i = 0; i < pointings.Length; ++i) // max tc = 100
        {
            --pointings[i]; // adjust to 0-based
        }

        const int InvalidPointedOrder = -1;

        int[] pointedOrder = new int[n];
        for (int i = 0; i < pointedOrder.Length; ++i)
        {
            pointedOrder[i] = InvalidPointedOrder;
        }

        LinkedList<int> orderLookupLL = new();
        int x = 0;
        int cycleBeginOrder = InvalidPointedOrder;
        while (true) // max tc = 100
        {
            x = pointings[x];

            if (pointedOrder[x] != InvalidPointedOrder)
            {
                cycleBeginOrder = pointedOrder[x];
                break;
            }

            orderLookupLL.AddLast(x);
            pointedOrder[x] = orderLookupLL.Count() - 1;
        }

        int[] orderLookupArr = orderLookupLL.ToArray();
        
        long adjustedT = t - 1;
        long defeatedPlayerOrder;
        if (adjustedT > orderLookupArr.Length)
        {
            // the cycle inevitably happens
            defeatedPlayerOrder = cycleBeginOrder + (adjustedT - cycleBeginOrder) % (orderLookupArr.Length - cycleBeginOrder);
        }
        else
        {
            defeatedPlayerOrder = adjustedT;
        }
        Console.Write(orderLookupArr[defeatedPlayerOrder] + 1);
    }
}