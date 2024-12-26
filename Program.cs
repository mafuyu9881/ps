internal class Program
{
    private static void Main(string[] args)
    {
        const int Unriped = 0;
        const int Riped = 1;
        
        int offsetCount = 6;
        int[] colOffsets = new int[] { -1, 1, 0, 0, 0, 0 };
        int[] rowOffsets = new int[] { 0, 0, -1, 1, 0, 0 };
        int[] layerOffsets = new int[] { 0, 0, 0, 0, -1, 1 };

        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int width = tokens[0]; // [2..100]
        int height = tokens[1]; // [2..100]
        int layers = tokens[2]; // [1..100]

        int[] map = new int[width * height * layers]; // [4..1000000]
        LinkedList<int> ripeds = new();
        int unripedCount = 0;
        for (int layer = 0; layer < layers; ++layer)
        {
            for (int row = 0; row < height; ++row)
            {
                tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
                for (int col = 0; col < width; ++col)
                {
                    int index = width * height * layer + width * row + col;
                    int element = tokens[col];
                    if (element == Unriped)
                    {
                        ++unripedCount;
                    }
                    else if (element == Riped)
                    {
                        ripeds.AddLast(index);
                    }
                    map[index] = element;
                }
            }
        }

        string output;
        if (unripedCount > 0)
        {
            int[] ripedDays = new int[map.Length];
            Queue<int> visitingQueue = new();
            while (true)
            {
                if (visitingQueue.Count < 1)
                {
                    if (ripeds.Count > 0)
                    {
                        visitingQueue.Enqueue(ripeds.First!.Value);
                        ripeds.RemoveFirst();
                    }
                    else
                    {
                        break;
                    }
                }

                int index = visitingQueue.Dequeue();
                int layer = index / (width * height);
                int row = (index % (width * height)) / width;
                int col = (index % (width * height)) % width;

                for (int i = 0; i < offsetCount; ++i)
                {
                    int adjLayer = layer + layerOffsets[i];
                    if (adjLayer < 0 || adjLayer > layers - 1)
                        continue;

                    int adjRow = row + rowOffsets[i];
                    if (adjRow < 0 || adjRow > height - 1)
                        continue;

                    int adjCol = col + colOffsets[i];
                    if (adjCol < 0 || adjCol > width - 1)
                        continue;

                    int adjIndex = adjLayer * width * height + adjRow * width + adjCol;
                    if (map[adjIndex] != Unriped)
                        continue;

                    int adjRipedDay = ripedDays[adjIndex];
                    int newRipedDay = ripedDays[index] + 1;
                    if (adjRipedDay > 0 && adjRipedDay <= newRipedDay)
                        continue;

                    if (adjRipedDay == 0)
                        --unripedCount;

                    ripedDays[adjIndex] = newRipedDay;
                    visitingQueue.Enqueue(adjIndex);
                }
            }

            if (unripedCount > 0)
            {
                output = "-1";
            }
            else
            {
                output = $"{ripedDays.Max()}";
            }
        }
        else
        {
            output = "0";
        }
        Console.Write(output);
    }
}