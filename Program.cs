using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();
        
        int a = int.Parse(tokens[0]);
        int b = int.Parse(tokens[1]);

        StringBuilder output = new();
        output.AppendLine(gcd(a, b).ToString());
        output.Append(lcm(a, b).ToString());

        Console.Write(output);
    }
    
    // 유클리드 호제법을 이용한 최대공약수 계산
    private static int gcd(int a, int b)
    {
        int r = a % b;

        if (r == 0)
        {
            return b;
        }
        else
        {
            return gcd(b, r);
        }
    }

    private static int lcm(int a, int b)
    {
        return a * b / gcd(a, b);
    }
}