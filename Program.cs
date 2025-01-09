internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int stations = tokens[0]; // [2, 100000]
        int soldiers = tokens[1]; // [2, 100000]

        int[] drivingTimes = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        SortedSet<int> boardingTimes = new();
        // bp = boarding point
        // ap = alighting point
        // bna = boarding and alighting
        SortedDictionary<int, LinkedList<(int bp, int ap)>> bnaInfos = new();
        for (int i = 0; i < soldiers; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            // points are 1-based
            int boardingPoint = tokens[0] - 1;
            int alightingPoint = tokens[1] - 1;
            int boardingTime = tokens[2];

            boardingTimes.Add(boardingTime);

            if (bnaInfos.ContainsKey(boardingTime) == false)
            {
                bnaInfos.Add(boardingTime, new());
            }
            bnaInfos[boardingTime].AddLast((boardingPoint, alightingPoint));
        }

        int elapsedTime = 0;
        //while ()
        {
            while (boardingTimes.Count > 0)
            {
                int minBoardingTime = boardingTimes.Min;
                if (elapsedTime < minBoardingTime)
                    break;

                
            }

            
        }
    }
}