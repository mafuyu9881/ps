class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 50]

        string s = Console.ReadLine()!;

        int vowels = 0;
        for (int i = 0; i < s.Length; ++i)
        {
            char c = s[i];
            if (c == 'a' ||
                c == 'e' ||
                c == 'i' ||
                c == 'o' ||
                c == 'u')
            {
                ++vowels;
            }
        }
        Console.Write(vowels);
    }
}