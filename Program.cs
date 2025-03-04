using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        // element = [2, 20]
        int[] integerTokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = integerTokens[0];
        int width = integerTokens[1];

        char[] map = new char[height * width];
        for (int row = 0; row < height; ++row) // max tc = 20
        {
            string stringToken = Console.ReadLine()!;
            for (int col = 0; col < width; ++col) // max tc = 20
            {
                map[row * width + col] = stringToken[col];
            }
        }

        const char Blocked = '#';

        List<string> words = new();
        for (int row = 0; row < height; ++row) // max tc = 20
        {
            for (int col = 0; col < width; ++col) // max tc = 20
            {
                char c = map[row * width + col];

                if (c == Blocked)
                    continue;

                if (col == 0 || map[row * width + col - 1] == Blocked)
                {
                    StringBuilder word = new();
                    
                    for (int wordCol = col; wordCol < width; ++wordCol) // max tc = 20
                    {
                        char wordC = map[row * width + wordCol];
                        
                        if (wordC == Blocked)
                            break;

                        word.Append(wordC);
                    }

                    if (word.Length > 1)
                    {
                        words.Add($"{word}");
                    }
                }

                if (row == 0 || map[(row - 1) * width + col] == Blocked)
                {
                    StringBuilder word = new();

                    for (int wordRow = row; wordRow < height; ++wordRow) // max tc = 20
                    {
                        char wordC = map[wordRow * width + col];

                        if (wordC == Blocked)
                            break;

                        word.Append(wordC);
                    }

                    if (word.Length > 1)
                    {
                        words.Add($"{word}");
                    }
                }
            }
        }

        words.Sort(); // max tc = about 400 * log2(400) = 400 * 8.xxx

        Console.Write(words[0]);
    }
}