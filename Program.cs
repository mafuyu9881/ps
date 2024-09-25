using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        queue queue = new();

        int n = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < n; ++i)
        {
            string[] tokens = Console.ReadLine()!.Split();

            string command = tokens[0];

            if (command == "push")
            {
                queue.push(int.Parse(tokens[1]));
            }
            else if (command == "pop")
            {
                output.AppendLine(queue.pop().ToString());
            }
            else if (command == "size")
            {
                output.AppendLine(queue.size().ToString());
            }
            else if (command == "empty")
            {
                output.AppendLine(queue.empty().ToString());
            }
            else if (command == "front")
            {
                output.AppendLine(queue.print_front().ToString());
            }
            else if (command == "back")
            {
                output.AppendLine(queue.print_back().ToString());
            }
        }
        Console.Write(output);
    }
}

// 메모리 지역성보다 삽입 삭제 과정에서 발생하는 메모리 재할당의 오버헤드가 더 클 것 같아 구현체로 링크드리스트를 채택.
public class queue
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
    
    private node? front = null;
    private node? back = null;
    private int count = 0;

    public void push(int data)
    {
        node? new_node = new(data);
        if (back != null)
        {
            back.Next = new_node;
        }
        back = new_node;

        if (front == null)
        {
            front = new_node;
        }

        ++count;
    }

    public int pop()
    {
        if (front == null)
            return -1;

        int output = front.Data;
        
        node? new_front = front.Next;
        if (new_front != null)
        {
            new_front.Prev = null;
            front = new_front;
        }
        else
        {
            front = null;
            back = null;
        }

        --count;

        return output;
    }

    public int size()
    {
        return count;
    }

    public int empty()
    {
        //return Math.Min(1, count);
        if (count > 0)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }

    public int print_front()
    {
        if (front != null)
        {
            return front.Data;
        }
        else
        {
            return -1;
        }
    }

    public int print_back()
    {
        if (back != null)
        {
            return back.Data;
        }
        else
        {
            return -1;
        }
    }
}