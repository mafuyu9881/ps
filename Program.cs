internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // max tc = 1000000
        int stations = tokens[0]; // [2, 100000]
        int soldiers = tokens[1]; // [2, 100000]

        // element in [1, 1000]
        int[] intervalTimes = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // max tc = 1000000

        // SI = station interval
        int[] accIntervalTimes = new int[intervalTimes.Length + 1];
        // leave 0 index as zero
        for (int i = 1; i < accIntervalTimes.Length; ++i)
        {
            accIntervalTimes[i] = accIntervalTimes[i - 1] + intervalTimes[i - 1];
        }

        int cycleTime = accIntervalTimes[accIntervalTimes.Length - 1];

        int travelTime = 0;
        for (int i = 0; i < soldiers; ++i) // max tc = 100000
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            // points are 1-based
            int bp = tokens[0] - 1; // boarding point [0, 100000 - 1]
            int ap = tokens[1] - 1; // alighting point [0, 100000 - 1]
            int bt = tokens[2]; // boardable time [0, 1000000000]

            int cyclicClampedBT = bt % cycleTime;

            // rounder is the ceiling or flooring value that rounds boardable time to accumulated interval time
            int rounder = accIntervalTimes[bp] - cyclicClampedBT;
            // if it floored, we need just one more cycle
            // no need more over than one because we used cyclicly clamped boardable time (cyclicClampedBT)
            if (rounder < 0)
            {
                rounder += cycleTime;
            }

            int boardingTime = bt + rounder;

            // It's guaranteed that boarding point and alighting point are not equeal
            int fromBPToAPTime = accIntervalTimes[ap] - accIntervalTimes[bp];
            // if fromBPToAPTime is lower than 0, it means the boarding point is on before the alighting point
            if (fromBPToAPTime < 0)
            {
                fromBPToAPTime += cycleTime;
            }

            int alightingTime = boardingTime + fromBPToAPTime;

            travelTime = Math.Max(travelTime, alightingTime);
        }
        Console.Write(travelTime);
    }
}