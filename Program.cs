internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();

        // 1 <= B < A <= V <= 10억이다.
        // 'https://discord.com/channels/1285075305987309590/1285593827498790912'에 따라 일반적인 코테 환경에선 1초에 10억번 정도의 연산이 지원된다.
        // 그러나 문제에서 제시한 시간 제한이 0.25초인 것으로 보아, 간단한 반복문으로는 풀게 해주지 않을 모양으로 생각된다.

        int a = int.Parse(tokens[0]);
        int b = int.Parse(tokens[1]);
        int v = int.Parse(tokens[2]);

        int v_b = v - b;
        int a_b = a - b;

        int days = (v - b) / (a - b);

        if (v_b % a_b > 0)
        {
            ++days;
        }

        Console.Write(days);
        
        // 나이브하게 푼 버전의 코드
        //int days = 0;

        //while (true)
        //{
        //    ++days;

        //    v -= a;

        //    if (v < 1)
        //        break;

        //    v += b;
        //}

        //Console.Write(days);
    }
}