class Program
{
    static void Main(string[] args)
    {
        const int Grades = 5;

        int students = int.Parse(Console.ReadLine()!);

        int[,] table = new int[students, Grades];

        for (int i = 0; i < students; ++i)
        {
            int[] history = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int grade = 0; grade < Grades; ++grade)
            {
                table[i, grade] = history[grade];
            }
        }

        int best = 0;
        int bestCount = -1;
        
        int[] candidates = new int[students];
        for (int i = 0; i < students; ++i)
        {
            bool[] met = new bool[students];
            int count = 0;

            for (int grade = 0; grade < Grades; ++grade)
            {
                for (int j = 0; j < students; ++j)
                {
                    if (i == j)
                        continue;

                    if (met[j] == true)
                        continue;

                    if (table[i, grade] != table[j, grade])
                        continue;

                    ++count;
                    met[j] = true;
                }
            }

            if (count > bestCount)
            {
                bestCount = count;
                best = i;
            }
        }

        Console.Write(best + 1);
    }
}