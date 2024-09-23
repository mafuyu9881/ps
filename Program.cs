// 1 ≤ N ≤ 20,000
// N^2 = 400,000,000
// 시간 제한은 2초
// 주어지는 최대 문자열 길이의 총합은 1,000,000자 (2byte * 1,000,000) = 2,000,000
// 조금 아슬아슬 할 것 같긴 한데, 일단은 N^2으로 풀어본다.
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        LinkedList<string> list = new();
        HashSet<string> added_strings = new();

        for (int i = 0; i < n; ++i)
        {
            string s = Console.ReadLine()!;

            if (added_strings.Contains(s))
                continue;

            int s_length = s.Length;

            LinkedListNode<string> target_node = null!;
            for (LinkedListNode<string> node = list.First!; node != null; node = node.Next!)
            {
                string node_s = node.Value;
                int node_s_length = node_s.Length;

                if (node_s_length > s_length)
                    break;

                if (node_s_length == s_length)
                {
                    bool do_break = false;
                    for (int j = 0; j < s_length; ++j)
                    {
                        char s_j = s[j];
                        char node_s_j = node_s[j];
                        
                        if (s_j == node_s_j)
                        {
                            continue;
                        }
                        else
                        {
                            if (s_j < node_s_j)
                            {
                                do_break = true;
                            }
                            break;
                        }
                    }

                    if (do_break)
                        break;
                }

                target_node = node;
            }

            if (target_node != null)
            {
                list.AddAfter(target_node, s);
            }
            else
            {
                list.AddFirst(s);
            }

            added_strings.Add(s);
        }

        StringBuilder output = new();
        for (LinkedListNode<string> node = list.First!; node != null; node = node.Next!)
        {
            output.AppendLine(node.Value);
        }

        Console.Write(output);
    }
}