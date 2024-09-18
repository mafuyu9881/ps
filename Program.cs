using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        
        string[] tokens = Console.ReadLine()!.Split();
        
        float? max_score = null;
        
        // score_sum에 대입될 수 있는 최댓값은 1000개의 과목을 모두 100점을 맞았을 경우 즉 1000000입니다.
        // 따라서 float의 범위 내에서 해결 가능하다고 판단합니다.
        float score_sum = 0.0f;
        for (int i = 0; i < tokens.Length; ++i)
        {
            float score = float.Parse(tokens[i]);

            if (max_score == null || score > max_score)
            {
                max_score = score;
            }

            score_sum += score;
        }

        Console.Write(score_sum / max_score * 100.0f / n);
    }
}