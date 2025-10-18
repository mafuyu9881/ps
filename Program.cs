using System.Text;

class Program
{
    static void Main(string[] args)
    {
        StringBuilder output = new();

        while (true)
        {
            string? name = Console.ReadLine();
            if (name == null || name == "")
                break;

            for (int i = 0; i < name.Length; ++i)
            {
                char c = name[i];
                if (c == 'e')
                {
                    c = 'i';
                }
                else if (c == 'i')
                {
                    c = 'e';
                }
                else if (c == 'E')
                {
                    c = 'I';
                }
                else if (c == 'I')
                {
                    c = 'E';
                }
                output.Append(c);
            }
            output.AppendLine();
        }

        Console.Write(output);
    }
}