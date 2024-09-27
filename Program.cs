// 시간 제한: 1.5초
// 메모리 제한: 4MB

using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int set_length = 20;
        bool[] set = new bool[set_length];

        int m = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < m; ++i)
        {
            string[] tokens = Console.ReadLine()!.Split();
            
            string command = tokens[0];

            if (command == "add")
            {
                set[data_to_index(int.Parse(tokens[1]))] = true;
            }
            else if (command == "remove")
            {
                set[data_to_index(int.Parse(tokens[1]))] = false;
            }
            else if (command == "check")
            {
                if (set[data_to_index(int.Parse(tokens[1]))])
                {
                    output.AppendLine("1");
                }
                else
                {
                    output.AppendLine("0");
                }
            }
            else if (command == "toggle")
            {
                int index = data_to_index(int.Parse(tokens[1]));
                bool data = set[index];
                set[index] = !data;
            }
            else if (command == "all")
            {
                for (int j = 0; j < set_length; ++j)
                {
                    set[j] = true;
                }
            }
            else if (command == "empty")
            {
                for (int j = 0; j < set_length; ++j)
                {
                    set[j] = false;
                }
            }
        }
        Console.Write(output);
    }

    private static int data_to_index(int data)
    {
        return data - 1;
    }
}