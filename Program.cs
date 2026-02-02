using System.Text;

class Program
{
    static void Main(string[] args)
    {
        const int GridSize = 9;

        int maxValue = 0;
        int maxValueRow = 0;
        int maxValueCol = 0;
        for (int row = 0; row < GridSize; ++row)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < GridSize; ++col)
            {
                int value = tokens[col];
                if (value < maxValue)
                    continue;

                maxValue = value;
                maxValueRow = row;
                maxValueCol = col;
            }
        }

        StringBuilder output = new();
        output.AppendLine($"{maxValue}");
        output.AppendLine($"{maxValueRow + 1} {maxValueCol + 1}");
        Console.Write(output);
    }
}