class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int cycles = 0;
        {
            int temp = n;
            do
            {
                int a = temp / 10;
                int b = temp % 10;
                int sum = a + b;

                temp = (b * 10) + (sum % 10);
                ++cycles;
            }
            while (temp != n);
        }

        Console.Write(cycles);
    }
}