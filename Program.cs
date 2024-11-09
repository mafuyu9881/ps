internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int n = tokens[0];
        int m = tokens[1];
        int l = tokens[2];

        LinkedList<int> initialRestAreaList = new();

        if (n > 0)
        {
            int[] initialRestAreaArray = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            Array.Sort(initialRestAreaArray);

            for (int i = 0; i < n; ++i)
            {
                initialRestAreaList.AddLast(initialRestAreaArray[i]);
            }
        }

        int left = 1;
        int right = l - 2;
        int output = 0;
        while (left <= right)
        {
            int mid = (left + right) / 2;

            int remainRestAreaCount = m;
            LinkedList<int> restAreaList = new(initialRestAreaList);
            var startpointNode = restAreaList.AddFirst(0);
            var endpointNode = restAreaList.AddLast(l);
            for (var node = restAreaList.First; (node != null) && (node != endpointNode); node = node.Next)
            {
                int begin = node.Value;
                int end = node.Next!.Value;

                int interval = end - begin;
                if (interval <= mid)
                    continue;

                int equalDivisionCount = (interval - 1) / mid + 1;
                int equalDivisionStride = Math.Max(interval / equalDivisionCount, mid);
                
                var targetNode = node;
                for (int i = 1; i < equalDivisionCount; ++i)
                {
                    int newRestAreaPoint = begin + equalDivisionStride * i;
                    if (newRestAreaPoint >= end)
                        break;

                    targetNode = restAreaList.AddAfter(targetNode, newRestAreaPoint);
                    --remainRestAreaCount;
                }
            }

            if (remainRestAreaCount < 0)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
                output = mid;
            }
        }
        Console.Write(output);
    }
}