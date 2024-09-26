// 시간 제한: 2초
// 메모리 제한: 128MB

using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int[] arr = new int[n];
        for (int i = 0; i < n; ++i)
        {
            arr[i] = int.Parse(Console.ReadLine()!);
        }

        stack stack = new();
        int last_pushed = 0;
        StringBuilder output = new();
        Action set_output_as_no = () =>
        {
            if (output != null)
            {
                output = new("NO");
            }
        };
        for (int i = 0; i < n; ++i)
        {
            int objective = arr[i];

            if (stack.empty() ||
                stack.top() < objective)
            {
                if (last_pushed > objective)
                {
                    set_output_as_no();
                    break;
                }

                while (last_pushed < objective)
                {
                    ++last_pushed;
                    stack.push(last_pushed);
                    output.AppendLine("+");
                }
            }

            if (stack.top() != objective)
            {
                set_output_as_no();
                break;
            }

            stack.pop();
            output.AppendLine("-");
        }
        Console.Write(output);
    }
}

public class stack
{
    private class node
    {
        private int data;
        public int Data
        {
            get { return data; }
        }

        private node? prev = null;
        public node? Prev
        {
            get { return prev; }
            set
            {
                if (value != null)
                {
                    value.next = this;
                }
                prev = value;
            }
        }
        private node? next = null;
        public node? Next
        {
            get { return next; }
            set
            {
                if (value != null)
                {
                    value.prev = this;
                }
                next = value;
            }
        }
        
        public node(int data)
        {
            this.data = data;
        }
    }
    
    private node? head = null;
    private int error = -1;
    public int Error { get { return error; } }
    private int count = 0;
    public int Count { get { return count; } }

    public void push(int data)
    {
        node new_node = new(data);
        new_node.Next = head;
        head = new_node;
        ++count;
    }

    public int pop()
    {
        int output;
        if (head != null)
        {
            output = head.Data;

            var head_next = head.Next;
            if (head_next != null)
            {
                head_next.Prev = null;
            }

            head.Next = null;
            head = head_next;
            --count;
        }
        else
        {
            output = Error;
        }
        return output;
    }
    
    public int top()
    {
        return (head != null) ? head.Data : Error;
    }

    public bool empty()
    {
        return Count < 1;
    }
}