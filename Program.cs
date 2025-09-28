class Program
{
    static void Main(string[] args)
    {
        int day = int.Parse(Console.ReadLine()!);

        int answer = 0;
        int[] cars = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        for (int i = 0; i < cars.Length; ++i)
        {
            if (cars[i] % 10 == day)
            {
                ++answer;
            }
        }
        Console.Write(answer);
    }
}