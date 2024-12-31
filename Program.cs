using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        LinkedList<int> buffer = new();

        Heap maxHeap = new Heap((int a, int b) => a > b);
        Heap minHeap = new Heap((int a, int b) => a < b);
        SortedDictionary<int, int> availables = new();

        StringBuilder output = new();
        int t = int.Parse(Console.ReadLine()!); // max tc = unkown
        for (int i = 0; i < t; ++i)
        {
            int k = int.Parse(Console.ReadLine()!); // max tc = 1,000,000
            for (int j = 0; j < k; ++j)
            {
                string[] tokens = Console.ReadLine()!.Split();

                string command = tokens[0];
                int n = int.Parse(tokens[1]);
                if (command == "I")
                {
                    maxHeap.Enqueue(n); // max tc = log2(1,000,000) = 19.xxxx
                    minHeap.Enqueue(n);
                    
                    if (availables.ContainsKey(n))
                    {
                        ++availables[n];
                    }
                    else
                    {
                        availables.Add(n, 1);
                    }
                }
                else if (command == "D")
                {
                    Heap targetHeap = (n == 1) ? maxHeap : minHeap;
                    targetHeap.DequeueWithValidation(out int dequeuedData, availables);
                }
            }

            if (maxHeap.PeekWithValidation(out int maxData, availables) &&
                minHeap.PeekWithValidation(out int minData, availables))
            {
                output.AppendLine($"{maxData} {minData}");
            }
            else
            {
                output.AppendLine("EMPTY");
            }

            maxHeap.Clear();
            minHeap.Clear();
            availables.Clear();
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

        public bool PeekWithValidation(out int output, SortedDictionary<int, int> availables)
        {
            output = _arr[0]; // peeked data

            while (_count > 0)
            {
                output = _arr[0];

                if (availables.ContainsKey(output))
                {
                    return true;
                }
                else
                {
                    Dequeue(out int dequeuedData);
                }
            }

            return false;
        }

        public bool DequeueWithValidation(out int output, SortedDictionary<int, int> availables)
        {
            output = 0;

            while (_count > 0)
            {
                if (Dequeue(out output) == false)
                    return false;

                if (availables.ContainsKey(output))
                {
                    if (--availables[output] < 1)
                    {
                        availables.Remove(output);
                    }
                    return true;
                }
            }

            return false;
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