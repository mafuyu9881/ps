internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = { Console.ReadLine()!, Console.ReadLine()!, Console.ReadLine()! };

        string fizz = "Fizz";
        string buzz = "Buzz";
        string fizzbuzz = "FizzBuzz";

        for (int i = 0; i < tokens.Length; ++i)
        {
            string token = tokens[i];
            
            if (token.Contains(fizz) || token.Contains(buzz))
                continue;

            int output_n = int.Parse(token) + (3 - i);

            string output_s;
            bool divisible_by_3 = output_n % 3 == 0;
            bool divisible_by_5 = output_n % 5 == 0;
            if (divisible_by_3 && divisible_by_5)
                output_s = fizzbuzz;
            else if (divisible_by_3)
                output_s = fizz;
            else if (divisible_by_5)
                output_s = buzz;
            else
                output_s = output_n.ToString();

            Console.Write(output_s);
            break;
        }
    }
}