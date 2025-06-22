class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 26]

        string s = Console.ReadLine()!;

        int[] count = new int['z' - 'a' + 1];

        int maxLength = 0;
        {
            int kinds = 0;
            int lo = 0;
            int hi = 0;
            while (hi < s.Length)
            {
                int newCharIndex = s[hi] - 'a';
                if (count[newCharIndex] == 0)
                {
                    ++kinds;
                }
                ++count[newCharIndex];

                while (kinds > n)
                {
                    int oldCharIndex = s[lo] - 'a';
                    --count[oldCharIndex];
                    if (count[oldCharIndex] == 0)
                    {
                        --kinds;
                    }
                    ++lo;
                }

                ++hi;

                maxLength = Math.Max(maxLength, (hi - 1) - lo + 1);
            }
        }
        Console.Write(maxLength);
    }
}