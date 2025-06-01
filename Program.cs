class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 2'000]

        // length = n = [1, 2'000]
        // element = [1, 1'000'000'000]
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int goods = 0;
        {
            
        }
        Console.Write(goods);
    }
}