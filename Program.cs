// 1 ≤ N ≤ 100,000, 1 ≤ M ≤ 1,000,000,000
// log 1 ≤ log M ≤ log 1,000,000,000 (단, 로그의 밑은 2)
// 0 ≤ log M ≤ 29.xxx

using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        
        int n = tokens[0];
        int m = tokens[1];

        int maxExaminingTime = 0;
        int[] examiningTimeArray = new int[n];
        for (int i = 0; i < n; ++i)
        {
            int examiningTime = int.Parse(Console.ReadLine()!);
            examiningTimeArray[i] = examiningTime;
            maxExaminingTime = Math.Max(maxExaminingTime, examiningTime);
        }

        long output = 0;
        // 전체 심사 시간의 최솟값은 심사대의 수가 심사 인원의 수보다 크거나 같고,
        // 각 심사대의 심사 시간이 모두 최솟값인 1일 때의 값과 같습니다.
        long left = 1;
        long right = maxExaminingTime * (long)m;
        while (left <= right)
        {
            long mid = (left + right) / 2;

            if (Examinable(mid, m, examiningTimeArray))
            {
                right = mid - 1;
                output = mid;
            }
            else
            {
                left = mid + 1;
            }
        }
        Console.Write(output);
    }

    private static bool Examinable(long givenTime, long waitingExaminationCount, int[] examiningTimeArray)
    {
        for (int i = 0; i < examiningTimeArray.Length; ++i)
        {
            waitingExaminationCount -= givenTime / examiningTimeArray[i];

            if (waitingExaminationCount <= 0)
            {
                return true;
            }
        }

        return false;
    }
}