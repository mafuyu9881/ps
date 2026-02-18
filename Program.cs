class Program
{
    static void Main(string[] args)
    {
        string word = Console.ReadLine()!;

        int[] counts = new int['Z' - 'A' + 1];

        for (int i = 0; i < word.Length; ++i)
        {
            char c = word[i];

            if (c >= 'a' && c <= 'z')
            {
                c = (char)(c + ('A' - 'a'));
            }

            int index = c - 'A';

            ++counts[index];
        }

        const int InvalidIndex = -1;
        int maxIndex = InvalidIndex;
        bool tied = false;
        for (int i = 0; i < counts.Length; ++i)
        {
            if (maxIndex == InvalidIndex ||
                counts[i] > counts[maxIndex])
            {
                maxIndex = i;
                tied = false;
            }
            else if (counts[i] == counts[maxIndex])
            {
                tied = true;
            }
        }

        if (tied)
        {
            Console.Write("?");
        }
        else
        {
            Console.Write((char)('A' + maxIndex));
        }
    }
}