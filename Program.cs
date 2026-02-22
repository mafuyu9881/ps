class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int[] sticks = new int[n];
        for (int i = 0; i < n; ++i)
        {
            sticks[i] = int.Parse(Console.ReadLine()!);
        }

        int visible = 0;
        {
            int maxStick = 0;
            for (int i = sticks.Length - 1; i >= 0; --i)
            {
                int stick = sticks[i];

                if (stick > maxStick)
                {
                    ++visible;
                    maxStick = stick;
                }
            }
        }

        Console.Write(visible);
    }
}