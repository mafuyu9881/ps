// 기초적인 동적 계획법을 통한 구현
internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();
        
        int n = int.Parse(tokens[0]);
        int k = int.Parse(tokens[1]);

        /*
        최종적으로 구하고자 하는 이항 계수를 계산하는 데에 가능한 한 필요한 항목만 추려서 계산합니다.
        예를 들어, n = 4, k = 2 일 경우 이항 계수 테이블은 다음과 같이 작성됩니다.

        테이블[, ] =
                1 0 0
               1 1 0
              1 2 1
             1 3 3
            1 4 6

        테이블[4, 2] = 6
        */

        int row = n + 1;
        int column = k + 1;

        int[,] binomial_coefficients = new int[row, column];

        for (int i = 0; i < row; ++i)
        {
            binomial_coefficients[i, 0] = 1;

            if (i < column)
            {
                if (i > 0)
                {
                    binomial_coefficients[i, 1] = 1;
                }
            
                binomial_coefficients[i, i] = 1;
            }
        }

        for (int i = 1; i < row; ++i)
        {
            for (int j = 1; j < column; ++j)
            {
                binomial_coefficients[i, j] = binomial_coefficients[i - 1, j] + binomial_coefficients[i - 1, j - 1];
            }
        }

        Console.Write(binomial_coefficients[n, k]);
    }
}