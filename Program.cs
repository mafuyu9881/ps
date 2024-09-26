// 시간 제한: 2초
// 메모리 제한: 128MB
// 1 ≤ N ≤ 100

using System.Text;
using document = System.Tuple<int, int>;

internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < t; ++i)
        {
            string[] tokens = Console.ReadLine()!.Split();
            
            int tno_documents = int.Parse(tokens[0]);
            int objective_document_index = int.Parse(tokens[1]);

            tokens = Console.ReadLine()!.Split();
            LinkedList<document> documents = new();
            LinkedListNode<document>? objective_document = null;
            for (int j = 0; j < tno_documents; ++j)
            {
                int data = int.Parse(tokens[j]);
                int id = j;
                var document = documents.AddLast(new document(data, id));
                if (j == objective_document_index)
                {
                    objective_document = document;
                }
            }
            
            int count = 0;
            while (documents.Count > 0)
            {
                var document = documents.First;

                bool swap = false;
                for (var other_document = document!.Next; other_document != null; other_document = other_document.Next)
                {
                    if (other_document.Value.Item1 > document.Value.Item1)
                    {
                        swap = true;
                        break;
                    }
                }

                if (swap)
                {
                    // TODO: 헤드 재설정 방식으로 개선
                    documents.AddLast(document.Value);
                    documents.RemoveFirst();
                }
                else
                {
                    ++count;
                    // 어째선지 객체 비교가 기대대로 동작하지 않아 별도의 식별자를 추가했다.
                    if (document.Value.Item2 == objective_document!.Value.Item2)
                    {
                        output.AppendLine(count.ToString());
                        break;
                    }
                    documents.Remove(document);
                }
            }
        }
        Console.Write(output);
    }
}