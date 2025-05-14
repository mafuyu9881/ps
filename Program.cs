internal class Program
{
    private static void Main(string[] args)
    {
        const int InvalidIndex = -1;
        const int Infinity = 100000000 + 1;

        int n = int.Parse(Console.ReadLine()!); // [1, 200'000]

        long traveled = 0;
        {
            int collectorX = 0;

            List<int> coords = new();
            int nearestIndex = InvalidIndex;

            for (int i = 0; i < n; ++i)
            {
                int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
                int command = tokens[0]; // [1, 2]

                if (command == 1)
                {
                    int x = tokens[1]; // [-100'000'000, 100'000'000]

                    coords.Add(x);

                    int index = coords.Count - 1;

                    bool update = false;
                    if (nearestIndex == InvalidIndex)
                    {
                        update = true;
                    }
                    else
                    {
                        int collectorXToX = Math.Abs(x - collectorX);
                        int collectorXToNearestX = Math.Abs(coords[nearestIndex] - collectorX);
                        update = (collectorXToX < collectorXToNearestX) ||
                                 (collectorXToX == collectorXToNearestX && index < nearestIndex);
                    }

                    if (update)
                    {
                        nearestIndex = index;
                    }
                }
                else // if (command == 2)
                {
                    if (nearestIndex != InvalidIndex)
                    {
                        traveled += Math.Abs(coords[nearestIndex] - collectorX);
                        collectorX = coords[nearestIndex];

                        int l = nearestIndex - 1;
                        int r = nearestIndex + 1;

                        while ((l > -1 && l < coords.Count) || (r > -1 && r < coords.Count))
                        {
                            int lDistance = Infinity;
                            if (l > -1 && l < coords.Count)
                            {
                                lDistance = Math.Abs(coords[l] - collectorX);
                            }

                            int rDistance = Infinity;
                            if (r > -1 && r < coords.Count)
                            {
                                rDistance = Math.Abs(coords[r] - collectorX);
                            }

                            if (lDistance <= rDistance)
                            {
                                collectorX = coords[l];
                                traveled += lDistance;
                                --l;
                            }
                            else
                            {
                                collectorX = coords[r];
                                traveled += rDistance;
                                ++r;
                            }
                        }

                        coords.Clear();
                        nearestIndex = InvalidIndex;
                    }
                }
            }
        }
        Console.Write(traveled);
    }
}