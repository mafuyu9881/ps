// 시간 제한: 1초
// 메모리 제한: 1024MB
// 20 <= (취침 시각) <= 23, 0 <= (취침 시각) <= 3
// 5 <= (기상 시각) <= 10

internal class Program
{
    private static void Main(string[] args)
    {
        int begin_sleep = int.Parse(Console.ReadLine()!);
        int end_sleep = int.Parse(Console.ReadLine()!);

        // 전 날에 잠들었을 경우
        if (begin_sleep > end_sleep)
        {
            begin_sleep -= 24;
        }

        Console.Write(end_sleep - begin_sleep);
    }
}