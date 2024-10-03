// 시간 제한: 1초
// 메모리 제한: 256MB
// 1 ≤ N ≤ 100,000

using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int[] maxHeap = new int[n];
        int writtenIndex = -1;
        const int InvalidIndex = -1;

        StringBuilder output = new();
        for (int i = 0; i < n; ++i)
        {
            int command = int.Parse(Console.ReadLine()!);

            if (command != 0)
            {
                if (writtenIndex < 0)
                {
                    maxHeap[0] = command;
                    writtenIndex = 0;
                }
                else
                {
                    ++writtenIndex;
                    maxHeap[writtenIndex] = command;
                    
                    int comparingIndex = writtenIndex;
                    while (comparingIndex > 0)
                    {
                        int parentIndex = comparingIndex / 2;
                        if (comparingIndex % 2 == 0)
                            parentIndex -= 1;

                        int comparingData = maxHeap[comparingIndex];
                        int parentData = maxHeap[parentIndex];

                        if (parentData >= comparingData)
                            break;

                        maxHeap[parentIndex] = comparingData;
                        maxHeap[comparingIndex] = parentData;
                        comparingIndex = parentIndex;
                    }
                }
            }
            else
            {
                if (writtenIndex < 0)
                {
                    output.AppendLine("0");
                }
                else
                {
                    output.AppendLine($"{maxHeap[0]}");

                    maxHeap[0] = maxHeap[writtenIndex];
                    --writtenIndex;

                    int comparingIndex = 0;
                    while (comparingIndex < writtenIndex)
                    {
                        int leftChildIndex = comparingIndex * 2 + 1;
                        int rightChildIndex = comparingIndex * 2 + 2;

                        // leftChildIndex < rightChildIndex이므로 left에 대해서만 검사하면 됩니다.
                        if (leftChildIndex > writtenIndex)
                            break;

                        int selectedIndex = comparingIndex;

                        if (maxHeap[leftChildIndex] > maxHeap[selectedIndex])
                        {
                            selectedIndex = leftChildIndex;
                        }

                        if (rightChildIndex <= writtenIndex &&
                            maxHeap[rightChildIndex] > maxHeap[selectedIndex])
                        {
                            selectedIndex = rightChildIndex;
                        }

                        if (selectedIndex == comparingIndex)
                            break;
                        
                        int temp = maxHeap[comparingIndex];
                        maxHeap[comparingIndex] = maxHeap[selectedIndex];
                        maxHeap[selectedIndex] = temp;

                        comparingIndex = selectedIndex;
                    }
                }
            }
        }
        Console.Write(output);
    }
}