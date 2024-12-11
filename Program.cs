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

            string[] tokens = input.Split();

            string substring = tokens[0];
            Queue<char> substringQueue = new();
            for (int i = 0; i < substring.Length; ++i)
            {
                substringQueue.Enqueue(substring[i]);
            }

            string mainstring = tokens[1];
            for (int i = 0; i < mainstring.Length; ++i)
            {
                if (substringQueue.Peek() != mainstring[i])
                    continue;

                substringQueue.Dequeue();

                if (substringQueue.Count < 1)
                    break;
            }
            
            output.AppendLine(substringQueue.Count < 1 ? "Yes" : "No");
        }
        Console.Write(output);
    }
}