class Program
{
    static void Main(string[] args)
    {
        string line = Console.ReadLine()!;

        int vowels = 0;
        for (int i = 0; i < line.Length; ++i)
        {
            char c = line[i];
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