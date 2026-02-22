using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int students = int.Parse(Console.ReadLine()!);

        int[] numbers = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        List<int> line = new();
        {
            for (int i = 1; i <= students; ++i)
            {
                line.Insert(line.Count - numbers[i - 1], i);
            }
        }
        
        StringBuilder output = new();
        {
            for (int i = 0; i < line.Count; ++i)
            {
                output.Append($"{line[i]} ");
            }
        }

        Console.Write(output);
    }
}