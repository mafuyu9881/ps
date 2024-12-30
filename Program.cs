using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        LinkedList<int> buffer = new();

        Heap maxHeap = new Heap((int a, int b) => a > b);
        Heap minHeap = new Heap((int a, int b) => a < b);

        StringBuilder output = new();
        int t = int.Parse(Console.ReadLine()!);
        for (int i = 0; i < t; ++i)
        {
            int k = int.Parse(Console.ReadLine()!);
            for (int j = 0; j < k; ++j)
            {
                string[] tokens = Console.ReadLine()!.Split();

                string command = tokens[0];
                int n = int.Parse(tokens[1]);
                if (command == "I")
                {
                    maxHeap.Enqueue(n);
                    minHeap.Enqueue(n);
                }
                else if (command == "D")
                {
                    Heap mainHeap;
                    Heap subHeap;
                    if (n == 1)
                    {
                        mainHeap = maxHeap;
                        subHeap = minHeap;
                    }
                    else // if (n == -1)
                    {
                        mainHeap = minHeap;
                        subHeap = maxHeap;
                    }

                    if (mainHeap.Dequeue(out int dequeuedMainData))
                    {
                        while (subHeap.Count > 0) // max tc = log 1,000,000 = 19.xxxx
                        {
                            subHeap.Dequeue(out int data);

                            if (data == dequeuedMainData)
                            {
                                break;
                            }
                            else
                            {
                                buffer.AddLast(data);
                            }
                        }

                        while (buffer.Count > 0) // max tc = 19.xxxx
                        {
                            var node = buffer.First!;
                            subHeap.Enqueue(node.Value);
                            buffer.RemoveFirst();
                        }
                    }
                }
            }

            if (maxHeap.Dequeue(out int maxData))
            {
                minHeap.Dequeue(out int minData);
                output.AppendLine($"{maxData} {minData}");
            }
            else
            {
                output.AppendLine("EMPTY");
            }

            maxHeap.Clear();
            minHeap.Clear();
        }
        Console.Write(output);
    }

    private class Heap
    {
        private Func<int, int, bool> _priority;
        private int[] _arr;
        private int _count;
        public int Count => _count;

        public Heap(Func<int, int, bool> priority)
        {
            _priority = priority;
            _arr = new int[1000000]; // sc = 4B * 1,000,000 = 4MB
            _count = 0;
        }

        public void Enqueue(int data)
        {
            _arr[_count] = data;

            int writtenIndex = _count;
            while (writtenIndex > 0)
            {
                int parentIndex = (writtenIndex - 1) / 2;
                
                int parentData = _arr[parentIndex];
                int writtenData = _arr[writtenIndex];
                if (_priority(parentData, writtenData))
                    break;

                _arr[parentIndex] = writtenData;
                _arr[writtenIndex] = parentData;
                writtenIndex = parentIndex;
            }

            ++_count;
        }

        public bool Dequeue(out int output)
        {
            output = _arr[0];

            if (_count < 1)
                return false;

            _arr[0] = _arr[_count - 1];
            --_count;
            int parentIndex = 0;
            while (true)
            {
                int leftChildIndex = parentIndex * 2 + 1;
                int rightChildIndex = parentIndex * 2 + 2;

                int nextParentIndex = parentIndex;

                if (leftChildIndex < _count &&
                    _priority(_arr[leftChildIndex], _arr[nextParentIndex]))
                    nextParentIndex = leftChildIndex;

                if (rightChildIndex < _count &&
                    _priority(_arr[rightChildIndex], _arr[nextParentIndex]))
                    nextParentIndex = rightChildIndex;

                if (nextParentIndex == parentIndex)
                    break;

                int temp = _arr[parentIndex];
                _arr[parentIndex] = _arr[nextParentIndex];
                _arr[nextParentIndex] = temp;

                parentIndex = nextParentIndex;
            }

            return true;
        }

        public void Clear()
        {
            _count = 0;
        }
    }
}