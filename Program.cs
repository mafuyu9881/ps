// 시간 제한: 1초
// 메모리 제한: 128MB
// 괄호 문자열의 길이는 2 이상 50 이하

using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        SortedSet<char> begin_parenthesises = new();
        begin_parenthesises.Add('(');

        SortedSet<char> end_parenthesises = new();
        end_parenthesises.Add(')');

        int n = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < n; ++i)
        {
            string ps = Console.ReadLine()!;
            
            Stack<char> stack = new();
            for (int j = 0; j < ps.Length; ++j)
            {
                char c = ps[j];
                
                if (begin_parenthesises.Contains(c))
                {
                    stack.Push(c);
                }

                if (end_parenthesises.Contains(c))
                {
                    if (stack.Count < 1)
                    {
                        // 에러를 명시
                        stack.Push(c);
                        break;
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
            }
            
            output.AppendLine((stack.Count < 1) ? "YES" : "NO");
        }
        Console.Write(output);
    }
}