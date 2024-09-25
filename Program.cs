using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        stack stack = new();

        int n = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < n; ++i)
        {
            string[] tokens = Console.ReadLine()!.Split();

            string command = tokens[0];

            if (command == "push")
            {
                stack.push(int.Parse(tokens[1]));
            }
            else if (command == "pop")
            {
                output.AppendLine(stack.pop().ToString());
            }
            else if (command == "size")
            {
                output.AppendLine(stack.size().ToString());
            }
            else if (command == "empty")
            {
                output.AppendLine(stack.empty().ToString());
            }
            else if (command == "top")
            {
                output.AppendLine(stack.top().ToString());
            }
        }
        Console.Write(output);
    }
}

// 메모리 지역성보다 삽입 삭제 과정에서 발생하는 메모리 재할당의 오버헤드가 더 클 것 같아 구현체로 링크드리스트를 채택.
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
            get { return prev!; }
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
            get { return next!; }
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
    
    private node? first = null;
    private int count = 0;

    public void push(int data)
    {
        node new_node = new(data);

        if (first != null)
        {
            first.Prev = new_node;
            first = new_node;
        }
        else
        {
            first = new_node;
        }

        ++count;
    }

    public int pop()
    {
        int output = top();

        if (first != null)
        {
            node? new_first = first.Next;
            if (new_first != null)
            {
                new_first.Prev = null;
            }
            first = new_first;

            --count;
        }

        return output;
    }

    public int top()
    {
        if (first != null)
        {
            return first.Data;
        }
        else
        {
            return -1;
        }
    }

    public int empty()
    {
        if (first != null)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }

    public int size()
    {
        return count;
    }
}