using System.Text;

class Program
{
    static void Main(string[] args)
    {
        StringBuilder output = new();
        while (true)
        {
            float[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries), float.Parse);
            float x = tokens[0];
            float y = tokens[1];

            string area;
            if (x == 0 || y == 0)
            {
                area = "AXIS";
            }
            else if (x > 0 && y > 0)
            {
                area = "Q1";
            }
            else if (x < 0 && y > 0)
            {
                area = "Q2";
            }
            else if (x < 0 && y < 0)
            {
                area = "Q3";
            }
            else// if (x > 0 && y < 0)
            {
                area = "Q4";
            }
            output.AppendLine(area);

            if (x == 0 && y == 0)
            {
                break;
            }
        }
        Console.Write(output);
    }
}