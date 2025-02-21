internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 200'000]

        bool[] entered = new bool[200000 + 1]; // sc = 200'001 * 4B = about 0.8MB
        int enteredCount = 0;

        int omitted = 0;
        for (int i = 0; i < n; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int a = tokens[0]; // [1, 200'000]
            int b = tokens[1]; // [0, 1]

            // enter
            if (b == 1)
            {
                if (entered[a])
                {
                    ++omitted;
                }
                else
                {
                    ++enteredCount;
                    entered[a] = true;
                }
            }
            // exit
            else
            {
                if (entered[a])
                {
                    --enteredCount;
                    entered[a] = false;
                }
                else
                {
                    ++omitted;
                }
            }
        }
        Console.Write(omitted + enteredCount);
    }
}