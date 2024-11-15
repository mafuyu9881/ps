internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];
        int m = tokens[1];
        int c = tokens[2];
        int[] arrivalTimes = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Array.Sort(arrivalTimes);
        int lastArrivalTimeIndex = n - 1;
        int lastArrivalTime = arrivalTimes[lastArrivalTimeIndex];

        const int InvalidRemainM = -1;
        const int InfinityArrivalTime = 2000000000; // 0 ≤ t ≤ 10^9, 0 ≤ mid ≤ 10^9

        int low = 0 - 1;
        int high = 1000000000 + 1; // arrivalTimes.Max() + 1
        while (low < high - 1)
        {
            int mid = (low + high) / 2;

            // I don't want to use priority queue, the logic with it requires re-allocation.
            int remainM = m;
            int boardedCowCount = 0;
            int arrivalTimeIndex = 0;
            LinkedList<int> waitingCowIndices = new();
            while (arrivalTimeIndex < arrivalTimes.Length)
            {
                while (arrivalTimeIndex < (arrivalTimes.Length - 1) &&
                       arrivalTimes[arrivalTimeIndex] == arrivalTimes[arrivalTimeIndex + 1])
                {
                    arrivalTimeIndex = arrivalTimeIndex + 1;
                }

                waitingCowIndices.AddLast(arrivalTimeIndex);

                // I avoid using some force flag for forcing logic.
                int nextArrivalTime = InfinityArrivalTime;
                int nextArrivalTimeIndex = arrivalTimeIndex + 1;
                if (nextArrivalTimeIndex < arrivalTimes.Length)
                {
                    nextArrivalTime = arrivalTimes[nextArrivalTimeIndex];

                    if ((nextArrivalTime == lastArrivalTime) &&
                        (arrivalTimeIndex != lastArrivalTimeIndex) &&
                        (nextArrivalTime - arrivalTimes[arrivalTimeIndex]) <= mid)
                    {
                        waitingCowIndices.AddLast(lastArrivalTimeIndex);
                        arrivalTimeIndex = lastArrivalTimeIndex; // to exit this while loop.
                    }
                }

                var waitingCowIndexNode = waitingCowIndices.Last;
                while (waitingCowIndexNode != null)
                {
                    int cowIndex = waitingCowIndexNode.Value;
                    int cowArrivalTime = arrivalTimes[cowIndex];

                    if ((nextArrivalTime - cowArrivalTime) >= mid)
                    {
                        int cowCount = cowIndex + 1;
                        int boardingCowCount = cowCount - boardedCowCount;
                        int boardedBusCount = (boardingCowCount - 1) / c + 1;

                        // need to consider the cow's count which boarded on last time
                        remainM = Math.Max(InvalidRemainM, remainM - boardedBusCount);
                        boardedCowCount += boardingCowCount;

                        while (waitingCowIndexNode != null)
                        {
                            var prevWaitingCowIndexNode = waitingCowIndexNode.Previous;
                            waitingCowIndices.Remove(waitingCowIndexNode);
                            waitingCowIndexNode = prevWaitingCowIndexNode;
                        }
                    }
                    else
                    {
                        waitingCowIndexNode = waitingCowIndexNode.Previous;
                    }
                }

                ++arrivalTimeIndex;
            }

            // we need to do the same checks in inner while iterations but,
            // I think the code is fast enough without it so it's better to get rid of duplicated codes.
            if (remainM == InvalidRemainM)
            {
                low = mid;
            }
            else
            {
                high = mid;
            }
        }
        Console.Write(high);
    }
}