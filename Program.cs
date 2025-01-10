internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int stations = tokens[0]; // [2, 100000]
        int soldiers = tokens[1]; // [2, 100000]

        int[] drivingTimes = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        (int bp, int ap)[] bnas = new (int, int)[soldiers];
        PriorityQueue<int, int> boardingTimes = new();
        // bp = boarding point
        // ap = alighting point
        // bna = boarding and alighting
        SortedDictionary<int, LinkedList<int>> bnaIndicesMap = new();
        for (int i = 0; i < soldiers; ++i) // max tc = 100000
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            // points are 1-based
            int boardingPoint = tokens[0] - 1;
            int alightingPoint = tokens[1] - 1;
            int boardingTime = tokens[2];

            bnas[i] = (boardingPoint, alightingPoint);

            boardingTimes.Enqueue(boardingTime, boardingTime);

            if (bnaIndicesMap.ContainsKey(boardingTime) == false)
            {
                bnaIndicesMap.Add(boardingTime, new());
            }
            bnaIndicesMap[boardingTime].AddLast(i);
        }

        int currStation = 0;
        int elapsedTime = 0;

        // index of garrison means boarding point
        // element in the linked list means alighting point
        LinkedList<int>[] garrison = new LinkedList<int>[stations];
        for (int i = 0; i < garrison.Length; ++i) // max tc = 100000
        {
            garrison[i] = new();
        }

        // index means alighting point
        // element means soldiers waiting for alighting
        int[] bus = new int[stations]; // max sc = 4B * 100000 = 0.4MB
        int soldiersOnBus = 0;

        while (soldiersOnBus > 0 || boardingTimes.Count > 0)
        {
            while (boardingTimes.Count > 0)
            {
                int minBoardingTime = boardingTimes.Peek();
                if (elapsedTime < minBoardingTime)
                    break;

                boardingTimes.Dequeue();

                var bnaIndices = bnaIndicesMap[minBoardingTime];
                for (var node = bnaIndices.First; node != null; node = node.Next)
                {
                    int bnaIndex = node.Value;

                    var bna = bnas[bnaIndex];

                    garrison[bna.bp].AddLast(bna.ap);
                }
            }

            var aps = garrison[currStation];
            while (aps.Count > 0)
            {
                ++bus[aps.First!.Value];
                ++soldiersOnBus;
                aps.RemoveFirst();
            }

            // times taken for driving from the current station to the next station
            int timeTaken = drivingTimes[currStation];
            elapsedTime += timeTaken;

            int nextStation = currStation + 1;
            if (nextStation > stations - 1)
            {
                nextStation = 0;
            }
            currStation = nextStation;

            soldiersOnBus -= bus[nextStation];
            bus[nextStation] = 0;
        }

        Console.Write(elapsedTime);
    }
}