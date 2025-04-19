internal class Program
{
    private enum Behavior
    {
        Enter,
        Exit,
    }

    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        (int time, Behavior behavior)[] acts = new (int, Behavior)[n * 2];

        for (int i = 0; i < n; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int enteringTime = tokens[0];
            int exitingTime = tokens[1];
            acts[(i * 2) + 0] = (enteringTime, Behavior.Enter);
            acts[(i * 2) + 1] = (exitingTime, Behavior.Exit);
        }

        Array.Sort(acts, (a, b) => a.time.CompareTo(b.time));

        List<(int time, Behavior behavior)> refinedActs = new();
        refinedActs.Capacity = n * 2;
        for (int i = 0; i < acts.Length; ++i)
        {
            var act = acts[i];

            if (refinedActs.Count > 0)
            {
                if (refinedActs[refinedActs.Count - 1].time == act.time &&
                    refinedActs[refinedActs.Count - 1].behavior != act.behavior)
                {
                    refinedActs.RemoveAt(refinedActs.Count - 1);
                }
                else
                {
                    refinedActs.Add(act);
                }
            }
            else
            {
                refinedActs.Add(act);
            }
        }

        int maxCount = 0;
        int enteringTimeOnMaxCount = 0;
        int exitingTimeOnMaxCount = 0;
        int count = 0;
        for (int i = 0; i < refinedActs.Count; ++i)
        {
            var element = refinedActs[i];
            int time = element.time;
            Behavior behavior = element.behavior;

            if (behavior == Behavior.Enter)
            {
                ++count;

                if (count > maxCount)
                {
                    maxCount = count;
                    enteringTimeOnMaxCount = time;
                }
            }
            else
            {
                if (count == maxCount)
                {
                    exitingTimeOnMaxCount = time;
                }

                --count;
            }
        }
        Console.WriteLine(maxCount);
        Console.WriteLine($"{enteringTimeOnMaxCount} {exitingTimeOnMaxCount}");
    }
}