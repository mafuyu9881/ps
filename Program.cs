internal class Program
{
    private static void Main(string[] args)
    {
        int l = int.Parse(Console.ReadLine()!);

        string s = Console.ReadLine()!;
        
        ulong sum = 0;
        ulong r_term = 1;
        ulong m = 1234567891L;
        for (int i = 0; i < l; ++i)
        {
            // 아래의 코드는 50점으로 이어지는 코드이다.
            // sum += Convert.ToUInt64(s[i] - 'a' + 1) * r_term % m;
            sum += Convert.ToUInt64(s[i] - 'a' + 1) * r_term;
            sum %= m;
            r_term = r_term * 31L % m;
        }
        
        Console.Write(sum);
    }
}