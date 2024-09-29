// 시간 제한: 0.15초
// 메모리 제한: 128MB
// 1 <= N <= 10^6

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int[] dp = new int[n + 1];
        dp[1] = 0;
        for (int i = 2; i <= n; ++i)
        {
            dp[i] = dp[i - 1] + 1;
            if (i % 2 == 0)
            {
                dp[i] = Math.Min(dp[i], dp[i / 2] + 1);
            }
            if (i % 3 == 0)
            {
                dp[i] = Math.Min(dp[i], dp[i / 3] + 1);
            }
        }
        Console.Write(dp[n]);
    }
}

// 실패 코드
// 1. k에서 k * 3, k * 2, k + 1로의 분기는
// 2. min(..) 함수를 이용하는 편이 가독성이 좋았을 듯
//int k = 1;
//while ()
//{
//    int new_computing_count = dp[k]!.Value + 1;
//    ref int? dp_k_mul_3 = ref dp[k * 3];
//    if (dp_k_mul_3 == null ||
//        dp_k_mul_3 > new_computing_count)
//    {
//        dp_k_mul_3 = new_computing_count;
//    }
//    ref int? dp_k_mul_2 = ref dp[k * 2];
//    if (dp_k_mul_2 == null ||
//        dp_k_mul_2 > new_computing_count)
//    {
//        dp_k_mul_2 = new_computing_count;
//    }
//    ref int? dp_k_add_1 = ref dp[k + 1];
//    if (dp_k_add_1 == null ||
//        dp_k_add_1 > new_computing_count)
//    {
//        dp_k_add_1 = new_computing_count;
//    }
//}