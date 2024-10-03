// 시간 제한: 2초
// 메모리 제한: 128MB
// 1,000,000 * 1B = 1,000KB = 1MB

internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();

        int n = int.Parse(tokens[0]);
        int k = int.Parse(tokens[1]);

        int visitedIndicesLength = 200000 * 2 + 1;
        bool[] visitedIndices = new bool[visitedIndicesLength];
        visitedIndices[n] = true;

        LinkedList<int> levelNumbers = new();
        levelNumbers.AddLast(n);

        int seconds = 0;
        while (true)
        {
            LinkedList<int> nextLevelNumbers = new();

            for (var node = levelNumbers.First; node != null; node = node.Next)
            {
                int levelNumber = node.Value;
                if (levelNumber == k)
                    goto Break;

                int prevLevelNumber = levelNumber - 1;
                int nextLevelNumber = levelNumber + 1;
                int twiceLevelNumber = levelNumber * 2;

                if (prevLevelNumber > 0 &&
                    prevLevelNumber < visitedIndicesLength &&
                    visitedIndices[prevLevelNumber] == false)
                {
                    nextLevelNumbers.AddLast(prevLevelNumber);
                    visitedIndices[prevLevelNumber] = true;
                }

                if (nextLevelNumber > 0 &&
                    nextLevelNumber < visitedIndicesLength &&
                    visitedIndices[nextLevelNumber] == false)
                {
                    nextLevelNumbers.AddLast(nextLevelNumber);
                    visitedIndices[nextLevelNumber] = true;
                }

                if (twiceLevelNumber > 0 &&
                    twiceLevelNumber < visitedIndicesLength && 
                    visitedIndices[twiceLevelNumber] == false)
                {
                    nextLevelNumbers.AddLast(twiceLevelNumber);
                    visitedIndices[twiceLevelNumber] = true;
                }
            }

            levelNumbers = nextLevelNumbers;
            ++seconds;
        }
        Break:
        Console.Write(seconds);
    }
}

// 진행 방향이 하나가 아니면 dp를 사용할 수 없다?