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
        
        // 음...
        var unknown_people_arr = unknown_people.ToArray();
        int unknown_people_arr_length = unknown_people_arr.Length;
        merge_sort(unknown_people_arr);

        StringBuilder output = new();
        output.AppendLine($"{unknown_people_arr_length}");
        for (int i = 0; i < unknown_people_arr_length; ++i)
        {
            output.AppendLine(unknown_people_arr[i]);
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

    private static void merge_sort(Span<string> arr)
    {
        int arr_length = arr.Length;

        if (arr_length < 2)
            return;

        int mid_index = arr_length / 2;
        
        merge_sort(arr.Slice(0, mid_index));
        merge_sort(arr.Slice(mid_index));
        merge(arr, mid_index);
    }

    private static void merge(Span<string> arr, int mid_index)
    {
        string[] backedup = arr.ToArray();

        int arr_length = arr.Length;

        int read_left_index = 0;
        int read_right_index = mid_index;
        int written_index = 0;

        while (read_left_index < mid_index && read_right_index < arr_length)
        {
            if (compare_string(backedup[read_left_index], backedup[read_right_index]))
            {
                arr[written_index] = backedup[read_left_index];
                ++read_left_index;
            }
            else
            {
                arr[written_index] = backedup[read_right_index];
                ++read_right_index;
            }
            ++written_index;
        }

        while (read_left_index < mid_index)
        {
            arr[written_index] = backedup[read_left_index];
            ++read_left_index;
            ++written_index;
        }

        while (read_right_index < arr_length)
        {
            arr[written_index] = backedup[read_right_index];
            ++read_right_index;
            ++written_index;
        }
    }

    // left의 우선 순위가 더 높다면 true를 반환합니다.
    // l과 r이 동일한 경우는 없음이 전제됩니다.
    // 문자열은 소문자로만 구성되어 있다고 전제됩니다.
    private static bool compare_string(string l, string r)
    {
        int l_length = l.Length;
        int r_length = r.Length;

        int shorter_length = Math.Min(l_length, r_length);

        for (int i = 0; i < shorter_length; ++i)
        {
            if (l[i] < r[i])
            {
                return true;
            }
            else if (l[i] > r[i])
            {
                return false;
            }
        }
        
        return l_length < r_length;
    }
}