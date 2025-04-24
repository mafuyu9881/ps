internal class Program
{
    private static void Main(string[] args)
    {
        const int SeatCount = 20;

        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int trainCount = tokens[0]; // [1, 100'000]
        int commandCount = tokens[1]; // [1, 100'000]

        bool[][] trains = new bool[trainCount + 1][];
        for (int i = 1; i < trains.Length; ++i)
        {
            trains[i] = new bool[SeatCount + 1];
        }

        for (int i = 0; i < commandCount; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int command = tokens[0]; // [1, 4]
            if (command == 1)
            {
                int trainIndex = tokens[1]; // [1, n]
                int seatIndex = tokens[2]; // [1, TrainLength] = [1, 20]
                trains[trainIndex][seatIndex] = true;
            }
            else if (command == 2)
            {
                int trainIndex = tokens[1]; // [1, n]
                int seatIndex = tokens[2]; // [1, TrainLength] = [1, 20]
                trains[trainIndex][seatIndex] = false;
            }
            else if (command == 3)
            {
                int trainIndex = tokens[1]; // [1, n]
                for (int seatIndex = SeatCount; seatIndex > 1; --seatIndex)
                {
                    trains[trainIndex][seatIndex] = trains[trainIndex][seatIndex - 1];
                }
                trains[trainIndex][1] = false;
            }
            else // if (command == 4)
            {
                int trainIndex = tokens[1]; // [1, n]
                for (int seatIndex = 1; seatIndex < SeatCount; ++seatIndex)
                {
                    trains[trainIndex][seatIndex] = trains[trainIndex][seatIndex - 1];
                }
                trains[trainIndex][SeatCount] = false;
            }
        }

        int[] bitPackedTrains = new int[trains.Length];
        for (int i = 1; i < bitPackedTrains.Length; ++i)
        {
            bool[] train = trains[i];
            for (int j = 1; j < train.Length; ++j)
            {
                if (train[j])
                {
                    bitPackedTrains[i] |= 1 << (j - 1);
                }
            }
        }

        int crossables = 0;
        {
            SortedSet<int> crossed = new();
            for (int trainIndex = 1; trainIndex < trains.Length; ++trainIndex)
            {
                int bitPackedTrain = bitPackedTrains[trainIndex];
                if (crossed.Contains(bitPackedTrain))
                    continue;

                crossed.Add(bitPackedTrain);
                ++crossables;
            }
        }
        Console.Write(crossables);
    }
}