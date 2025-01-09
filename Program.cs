internal class Program
{
    private static void Main(string[] args)
    {
        int dimension = int.Parse(Console.ReadLine()!);

        int plans = int.Parse(Console.ReadLine()!);
        // max tc = 50
        long[] movedComponents = Array.ConvertAll(Console.ReadLine()!.Split(), long.Parse);
        
        SortedSet<long> uniqueComponents = new();
        for (int i = 0; i < plans; ++i) // max tc = 50
        {
            uniqueComponents.Add(movedComponents[i]);
        }
        
        SortedDictionary<long, int> compressedComponentMap = new();
        while (uniqueComponents.Count > 0) // max tc = 50
        {
            long component = uniqueComponents.Min;
            uniqueComponents.Remove(component);

            compressedComponentMap.Add(component, compressedComponentMap.Count);
        }

        int[][] coordinateHistory = new int[plans + 1][];
        for (int i = 0; i < coordinateHistory.Length; ++i)
        {
            coordinateHistory[i] = new int[compressedComponentMap.Count];
        }

        string operators = Console.ReadLine()!;

        int output = 1;
        for (int i = 1; i <= plans; ++i) // max tc = 50
        {
            for (int k = 0; k < compressedComponentMap.Count; ++k) // max tc = 50
            {
                coordinateHistory[i][k] = coordinateHistory[i - 1][k];
            }

            long component = movedComponents[i - 1];
            int compressedComponent = compressedComponentMap[component]; // max tc = log2(50) = 5.xxx
            
            if (operators[i - 1] == '+')
            {
                ++coordinateHistory[i][compressedComponent];
            }
            else // if (operators[i] == '-')
            {
                --coordinateHistory[i][compressedComponent];
            }

            for (int j = 0; j < i; ++j) // max tc = 50
            {
                bool duplicated = true;
                for (int k = 0; k < compressedComponentMap.Count; ++k) // max tc = 50
                {
                    if (coordinateHistory[i][k] == coordinateHistory[j][k])
                        continue;

                    duplicated = false;
                }

                if (duplicated == false)
                    continue;

                output = 0;
                break;
            }

            if (output == 0)
                break;
        }
        Console.Write(output);
    }
}