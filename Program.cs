public class Program
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine()!;
        
        int[] counts = new int[10];
        
        for (int i = 0; i < input.Length; ++i)
        {
            ++counts[input[i] - '0'];
        }

        const int InvalidCount = -1;
        int setCount = InvalidCount;
        {
            for (int i = 0; i < counts.Length; ++i)
            {
                if (i == 6 || i == 9)
                {
                    continue;
                }

                int count = counts[i];

                if (setCount == InvalidCount || setCount < count)
                {
                    setCount = count;
                }
            }

            int sixnineSetCount = counts[6] + counts[9];
            {
                if (sixnineSetCount % 2 == 1)
                {
                    sixnineSetCount += 1;
                }
                sixnineSetCount /= 2;
            }
            
            setCount = Math.Max(setCount, sixnineSetCount);
        }

        Console.Write(setCount);
    }
}