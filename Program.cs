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

                // I avoided using some force flag for forcing logic.
                int nextArrivalTime = InfinityArrivalTime;
                int nextArrivalTimeIndex = arrivalTimeIndex + 1;
                if (nextArrivalTimeIndex < arrivalTimes.Length)
                {
                    nextArrivalTime = arrivalTimes[nextArrivalTimeIndex];

                    if (nextArrivalTime == lastArrivalTime &&
                        arrivalTimeIndex != lastArrivalTimeIndex)
                    {
                        
                    }
                }

                //var waitingIndexNode = waitingCowIndices.First;
                //while (waitingIndexNode != null)
                //{
                //    int cowIndex = waitingIndexNode.Value;

                //    int cowArrivalTime = arrivalTimes[cowIndex];
                //    int cowCount = cowIndex + 1;

                //    if ((nextArrivalTime - cowArrivalTime) >= mid)
                //    {
                //        waitingCowIndices.Remove(waitingIndexNode);
                //        waitingIndexNode = waitingCowIndices.First;

                //        // 여기서 2, 3, 4, 5, 6마리로 지워버리니까 remainM이 남아나질 않음
                //        // 뒤에서부터 검색해서 지우기 성공하면 앞에 노드도 다 날려버리는 식으로 해야할듯
                //        remainM = Math.Max(InvalidRemainM, remainM - ((cowCount - 1) / c + 1));
                //    }
                //    else
                //    {
                //        waitingIndexNode = waitingIndexNode.Next;
                //    }
                //}

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