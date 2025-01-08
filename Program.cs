internal class Program
{
    private static void Main(string[] args)
    {
        int[] characterTokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = characterTokens[0]; // [1..20]
        int width = characterTokens[1]; // [1..20]

        char[] map = new char[width * height];
        for (int row = 0; row < height; ++row)
        {
            string stringToken = Console.ReadLine()!;
            for (int col = 0; col < width; ++col)
            {
                map[row * width + col] = stringToken[col];
            }
        }

        int[] distance = new int[map.Length];
        bool[] passed = new bool[map.Length];

        int srcIndex1D = 0;
        distance[srcIndex1D] = 1;
        passed[map[srcIndex1D] - 'A'] = true;

        int[] rowOffsets = new int[] { -1, 1, 0, 0 };
        int[] colOffsets = new int[] { 0, 0, -1, 1 };

        int maxDistance = 1;
        Recursion(ref maxDistance,
                  map,
                  width,
                  height,
                  distance,
                  passed,
                  rowOffsets,
                  colOffsets,
                  srcIndex1D);
        Console.Write(maxDistance);
    }

    private static void Recursion(ref int maxDistance,
                                  char[] map,
                                  int width,
                                  int height,
                                  int[] distance,
                                  bool[] passed,
                                  int[] rowOffsets,
                                  int[] colOffsets,
                                  int index1D)
    {
        int row = index1D / width;
        int col = index1D % width;

        for (int i = 0; i < rowOffsets.Length; ++i)
        {
            int adjRow = row + rowOffsets[i];
            if (adjRow < 0 || adjRow > height - 1)
                continue;

            int adjCol = col + colOffsets[i];
            if (adjCol < 0 || adjCol > width - 1)
                continue;

            int adjIndex1D = adjRow * width + adjCol;
            char adjCharacter = map[adjIndex1D];
            if (passed[adjCharacter - 'A'])
                continue;

            int newDistance = distance[index1D] + 1;

            distance[adjIndex1D] = newDistance;
            passed[adjCharacter - 'A'] = true;

            maxDistance = Math.Max(maxDistance, newDistance);

            if (maxDistance > 'Z' - 'A')
                return;

            Recursion(ref maxDistance,
                      map,
                      width,
                      height,
                      distance,
                      passed,
                      rowOffsets,
                      colOffsets,
                      adjIndex1D);

            if (maxDistance > 'Z' - 'A')
                return;
        }

        passed[map[index1D] - 'A'] = false;
    }
}