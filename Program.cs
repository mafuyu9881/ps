using STLine = (int st0, int st1);

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [3, 6]

        char[] map = new char[n * n];
        for (int row = 0; row < n; ++row) // max tc = 6
        {
            char[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), char.Parse); // max tc = 6
            for (int col = 0; col < n; ++col) // max tc = 6
            {
                map[row * n + col] = tokens[col];
            }
        }

        const char X = 'X';
        const int InvalidIndex = -1;

        LinkedList<STLine> horizontals = new();
        for (int row = 0; row < n; ++row) // max tc = 6
        {
            int lastSTIndex = InvalidIndex;

            for (int col = 0; col < n; ++col) // max tc = 6
            {
                int currIndex = row * n + col;

                char currCharacter = map[currIndex];
                if (currCharacter == X)
                    continue;

                if (lastSTIndex != InvalidIndex && currCharacter != map[lastSTIndex])
                    horizontals.AddLast((lastSTIndex, currIndex));

                lastSTIndex = currIndex;
            }
        }

        LinkedList<STLine> verticals = new();
        for (int col = 0; col < n; ++col) // max tc = 6
        {
            int lastSTIndex = InvalidIndex;

            for (int row = 0; row < n; ++row) // max tc = 6
            {
                int currIndex = row * n + col;

                char currCharacter = map[currIndex];
                if (currCharacter == X)
                    continue;

                if (lastSTIndex != InvalidIndex && currCharacter != map[lastSTIndex])
                    verticals.AddLast((lastSTIndex, currIndex));

                lastSTIndex = currIndex;
            }
        }
        
        int obstacles = 0;
        while (true)
        {
            LinkedListNode<STLine>? selfNode = null;
            LinkedList<STLine>? opponents = null;
            if (horizontals.Count > 0)
            {
                selfNode = horizontals.First;
                opponents = verticals;
            }
            else if (verticals.Count > 0)
            {
                selfNode = verticals.First;
                opponents = horizontals;
            }
            
            if (selfNode == null || opponents == null) // check opponents too to avoid compiler's warning
                break;

            int selfST0Index = selfNode.Value.st0;
            int selfST0Row = selfST0Index / n;
            int selfST0Col = selfST0Index % n;
            int selfST1Index = selfNode.Value.st1;
            int selfST1Row = selfST1Index / n;
            int selfST1Col = selfST1Index % n;

            for (var opponentNode = opponents.First; opponentNode != null; opponentNode = opponentNode.Next)
            {
                int oppoST0Index = opponentNode.Value.st0;
                int oppoST1Index = opponentNode.Value.st1;

                if (opponents == verticals)
                {
                    int oppoCol = oppoST0Index % n;
                    if (oppoCol <= selfST0Col || oppoCol >= selfST1Col)
                        continue;

                    int selfRow = selfST0Index / n;
                    int oppoST0Row = oppoST0Index / n;
                    int oppoST1Row = oppoST1Index / n;
                    if (selfRow <= oppoST0Row || selfRow >= oppoST1Row)
                        continue;

                    opponents.Remove(opponentNode);
                    break;
                }
                else
                {
                    int oppoRow = oppoST0Index / n;
                    if (oppoRow <= selfST0Row || oppoRow >= selfST1Row)
                        continue;

                    int selfCol = selfST0Index % n;
                    int oppoST0Col = oppoST0Index % n;
                    int oppoST1Col = oppoST1Index % n;
                    if (selfCol <= oppoST0Col || selfCol >= oppoST1Col)
                        continue;

                    opponents.Remove(opponentNode);
                    break;
                }
            }

            var selves = selfNode.List!;
            selves.Remove(selfNode);

            ++obstacles;
        }

        Console.Write((obstacles > 3) ? "NO" : "YES");
    }
}