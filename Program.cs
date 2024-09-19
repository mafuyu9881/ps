internal class Program
{
    private static void Main(string[] args)
    {
        int[] lookup = new int[10001];

        int n = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < n; ++i)
        {
            ++lookup[int.Parse(Console.ReadLine()!)];
        }
        
        using (StreamWriter stream_writer = new(Console.OpenStandardOutput()))
        {
            for (int i = 1; i < lookup.Length; ++i)
            {
                // c#도 컴파일 단계에서 이 lookup[i]에 대한 최적화가 이루어질까?
                for (int j = 0; j < lookup[i]; ++j)
                {
                    stream_writer.WriteLine(i);
                }
            }
        }
    }
}