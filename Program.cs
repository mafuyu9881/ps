class Program
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        int[] answers = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        
        int correctAnswers = 0;
        for (int i = 0; i < answers.Length; ++i)
        {
            if (answers[i] == t)
            {
                ++correctAnswers;
            }
        }
        Console.Write(correctAnswers);
    }
}