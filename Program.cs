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
        SortedSet<char> passedCharacters = new();

        int srcIndex1D = 0;
        distance[srcIndex1D] = 1;
        passedCharacters.Add(map[srcIndex1D]);

        int[] rowOffsets = new int[] { -1, 1, 0, 0 };
        int[] colOffsets = new int[] { 0, 0, -1, 1 };

        int maxDistance = 0;
        Recursion(ref maxDistance,
                  map,
                  width,
                  height,
                  distance,
                  passedCharacters,
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
                                  SortedSet<char> passedCharacters,
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
            if (passedCharacters.Contains(adjCharacter))
                continue;

            int newDistance = distance[index1D] + 1;

            distance[adjIndex1D] = newDistance;
            passedCharacters.Add(adjCharacter);

            maxDistance = Math.Max(maxDistance, newDistance);

            if (maxDistance > 'Z' - 'A')
                break;

            Recursion(ref maxDistance,
                      map,
                      width,
                      height,
                      distance,
                      passedCharacters,
                      rowOffsets,
                      colOffsets,
                      adjIndex1D);

            if (maxDistance > 'Z' - 'A')
                break;
        }

        passedCharacters.Remove(map[index1D]);
    }
}