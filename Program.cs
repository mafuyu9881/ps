// 시간 제한: 1.5초
// 메모리 제한: 4MB

using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int set_length = 20;
        int set = 0;

        int m = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < m; ++i)
        {
            string[] tokens = Console.ReadLine()!.Split();
            
            string command = tokens[0];

            if (command == "add")
            {
                set |= 1 << data_to_index(int.Parse(tokens[1]));
            }
            else if (command == "remove")
            {
                set &= ~(1 << data_to_index(int.Parse(tokens[1])));
            }
            else if (command == "check")
            {
                int check = 1 << data_to_index(int.Parse(tokens[1]));
                if ((set & check) != 0)
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
                int toggle = 1 << data_to_index(int.Parse(tokens[1]));
                set ^= toggle;
            }
            else if (command == "all")
            {
                set = (1 << (set_length + 1)) - 1;
            }
            else if (command == "empty")
            {
                set = 0;
            }
        }
        Console.Write(output);
    }
    
    private static int data_to_index(int data)
    {
        return data - 1;
    }
}