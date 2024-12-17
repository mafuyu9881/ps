internal class Program
{
    private static void Main(string[] args)
    {
        string input = Console.ReadLine()!;

        int[] tokens = Array.ConvertAll(input.Split(new char[] { '+', '-' }), int.Parse);

        int plusCountBeforeFirstMinus = 0;
        const int InvalidFirstMinusIndex = -1;
        int firstMinusIndex = InvalidFirstMinusIndex;
        for (int i = 0; i < input.Length; ++i)
        {
            char c = input[i];

            if (c == '+')
            {
                ++plusCountBeforeFirstMinus;
            }
            else if (c == '-')
            {
                firstMinusIndex = plusCountBeforeFirstMinus;
                break;
            }
        }

        int output = 0;
        for (int i = 0; i < tokens.Length; ++i)
        {
            
        }
    }
}