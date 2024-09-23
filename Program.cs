/*
N <= 10,000
따라서, 브루트 포스로 탐색할 경우 최대 10,000,666의 순회가 요구된다. (실제로는 사이사이에 껴 있는 수들이 있을테니 10,000,666까지는 안 나올 것이다.)
이 정도 순회면 브루트 포스로도 널널하게 풀릴 것 같다. 시도해보자.
*/

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        
        int number = 666;

        while (true)
        {
            // 간단하게 검증할 수 있지만 부하가 큰 방법이다.
            if (number.ToString().Contains("666"))
                --n;

            if (n < 1)
            {
                Console.Write(number);
                break;
            }

            ++number;
        }
    }
}