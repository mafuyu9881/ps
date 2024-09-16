using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        StringBuilder output = new();
        
        while (true)
        {
            string? input = Console.ReadLine();
            if (input == null)
                break;

            int side_length_num = 3;

            string[] tokens = input.Split();
            if (tokens == null || tokens.Length < side_length_num)
                break;

            int left_side = 0;
            int? max_side_length_sq = null;
            for (int i = 0; i < side_length_num; ++i)
            {
                int side_length = int.Parse(tokens[i]);
                int side_length_sq = side_length * side_length;

                if (max_side_length_sq == null || side_length_sq > max_side_length_sq)
                    max_side_length_sq = side_length_sq;

                left_side += side_length_sq;
            }

            if (left_side == 0)
                break;

            output.AppendLine(((left_side - max_side_length_sq) == max_side_length_sq) ? "right" : "wrong");
        }
        
        Console.Write(output);
    }
}