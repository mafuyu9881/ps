using System.Text;

class Program
{
    static void Main(string[] args)
    {
        StringBuilder sb = new();
        sb.AppendLine("Gnomes:");
        int n = int.Parse(Console.ReadLine()!);
        for (int i = 0; i < n; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int state = 0;

            for (int j = 1; j < tokens.Length; ++j)
            {
                int prevToken = tokens[j - 1];
                int currToken = tokens[j];
                if (prevToken < currToken)
                {
                    if (state == 2)
                    {
                        state = -1;
                        break;
                    }

                    state = 1;
                }
                else if (prevToken > currToken)
                {
                    if (state == 1)
                    {
                        state = -1;
                        break;
                    }

                    state = 2;
                }
                //else
                //{
                //
                //}
            }

            sb.AppendLine((state == -1) ? "Unordered" : "Ordered");
        }
        Console.Write(sb);
    }
}