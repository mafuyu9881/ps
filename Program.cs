internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        
        int? output = null;

        for (int candidate = 0; candidate < n; ++candidate)
        {
            string candidate_string = candidate.ToString();
            int candidate_string_length = candidate_string.Length;

            int sum = candidate;
            
            for (int i = 0; i < candidate_string_length; ++i)
            {
                sum += candidate_string[i] - '0';
            }

            if (sum == n)
            {
                output = candidate;
                break;
            }
        }
        
        Console.Write((output == null) ? 0 : output);
    }
}