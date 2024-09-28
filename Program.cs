// 시간 제한: 2초
// 메모리 제한: 256MB
// (이름의 길이) <= 20
// 0 < N, M <= 500,000

using System.Collections;
using System.Text;
using Person = System.ValueTuple<string, int>;

internal class Program
{
    private static int buckets_length = 500009;

    private static void Main(string[] args)
    {
        LinkedList<Person>[] buckets = new LinkedList<Person>[buckets_length];

        string[] tokens = Console.ReadLine()!.Split();

        int n = int.Parse(tokens[0]);
        int m = int.Parse(tokens[1]);

        List<string> unknown_people = new();
        for (int i = 0; i < n + m; ++i)
        {
            string name = Console.ReadLine()!;

            int hash = hashing(name);

            var persons = buckets[hash];
            if (persons == null)
            {
                persons = new();
                buckets[hash] = persons;
            }

            LinkedListNode<Person>? person = null;
            for (person = persons.First; person != null; person = person.Next)
            {
                Person person_ref = person.ValueRef;

                if (person_ref.Item1 != name)
                    continue;

                ++person_ref.Item2;

                if (person_ref.Item2 > 1)
                    unknown_people.Add(name);
                
                break;
            }

            if (person == null)
            {
                persons.AddLast(new LinkedListNode<Person>(new(name, 1)));
            }
        }
        
        unknown_people.Sort();
        int unknown_people_count = unknown_people.Count;

        StringBuilder output = new();
        output.AppendLine($"{unknown_people_count}");
        for (int i = 0; i < unknown_people_count; ++i)
        {
            output.AppendLine(unknown_people[i]);
        }
        Console.Write(output);
    }

    private static int hashing(string input)
    {
        int output = 0;
        int r = 1;
        for (int i = 0; i < input.Length; ++i)
        {
            output += Convert.ToInt32(input[i] - 'a' + 1) * r;
            output %= buckets_length;
            r = r * 13 % buckets_length;
        }
        return output;
    }
}