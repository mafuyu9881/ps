internal class Program
{
    private static void Main(string[] args)
    {
        string input = Console.ReadLine()!;

        string[] tokens = input.Split();
        if (tokens == null || tokens.Length < 1)
            return;

        int n = int.Parse(tokens[0]);

        input = Console.ReadLine()!;
        string[] applicant_tokens = input.Split();
        if (applicant_tokens == null)
            return;

        input = Console.ReadLine()!;
        string[] tp_tokens = input.Split();
        if (tp_tokens == null || tp_tokens.Length < 2)
            return;

        int t = int.Parse(tp_tokens[0]);
        int p = int.Parse(tp_tokens[1]);

        int t_sum = 0;

        for (int i = 0; i < applicant_tokens.Length; ++i)
        {
            int applicant = int.Parse(applicant_tokens[i]);

            t_sum += applicant / t;

            if (applicant % t > 0)
            {
                t_sum += 1;
            }
        }

        Console.WriteLine(t_sum.ToString());
        Console.Write($"{n / p} {n % p}");
    }
}