// 시간 제한: 1초
// 메모리 제한: 128MB
// 입력되는 문자열 한 줄의 최대 길이: 100

using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        SortedSet<char> begin_brackets = new();
        begin_brackets.Add('(');
        begin_brackets.Add('[');

        SortedSet<char> end_brackets = new();
        end_brackets.Add(')');
        end_brackets.Add(']');

        Dictionary<char, char> opposite_bracket_map = new Dictionary<char, char>
        {
            {'(', ')'},
            {')', '('},
            {'[', ']'},
            {']', '['},
        };

        StringBuilder output = new();
        while (true)
        {
            string input = Console.ReadLine()!;
            if (input == ".")
                break;
            
            Stack<char> stack = new();

            for (int i = 0; i < input.Length; ++i)
            {
                char c = input[i];

                if (begin_brackets.Contains(c))
                {
                    stack.Push(c);
                }

                if (end_brackets.Contains(c))
                {
                    if (stack.Count == 0 ||
                        opposite_bracket_map[c] != stack.Peek())
                    {
                        // stack.Count == 0 케이스의 대응 코드입니다.
                        // 이를 통해 일관된 코드로 yes 혹은 no를 작성할 수 있게합니다.
                        stack.Push(c);
                        break;
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
            }

            output.AppendLine((stack.Count == 0) ? "yes" : "no");
        }
        Console.Write(output);
    }
}