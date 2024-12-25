using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        const int InvalidIndex = -1;

        int n = int.Parse(Console.ReadLine()!);

        int[] absMinHeap = new int[100000];
        int count = 0;

        StringBuilder output = new();
        for (int i = 0; i < n; ++i)
        {
            int x = int.Parse(Console.ReadLine()!); // -2^31 < x < 2^31
            if (x != 0)
            {
                absMinHeap[count] = x;

                int writtenIndex = count;
                while (true)
                {
                    int parentIndex = writtenIndex / 2;
                    if (writtenIndex % 2 == 0)
                        parentIndex -= 1;

                    if (parentIndex < 0)
                        break;

                    int childData = absMinHeap[writtenIndex];
                    int parentData = absMinHeap[parentIndex];
                    if (CheckSwapRequired(parentData, childData) == false)
                        break;

                    absMinHeap[writtenIndex] = parentData;
                    absMinHeap[parentIndex] = childData;
                    writtenIndex = parentIndex;
                }
                
                ++count;
            }
            else
            {
                if (count < 1)
                {
                    output.AppendLine("0");
                }
                else
                {
                    output.AppendLine($"{absMinHeap[0]}");

                    absMinHeap[0] = absMinHeap[count - 1];
                    int parentIndex = 0;

                    while (true)
                    {
                        int leftChildIndex = parentIndex * 2 + 1;
                        int rightChildIndex = parentIndex * 2 + 2;

                        if (leftChildIndex >= count)
                            leftChildIndex = InvalidIndex;
                        
                        if (rightChildIndex >= count)
                            rightChildIndex = InvalidIndex;

                        // it's very important to use nextParentIndex in following conditions
                        // by using this, we can compare data among parent, left child, right child
                        int nextParentIndex = parentIndex;

                        if (leftChildIndex != InvalidIndex &&
                            CheckSwapRequired(absMinHeap[nextParentIndex], absMinHeap[leftChildIndex]))
                            nextParentIndex = leftChildIndex;

                        if (rightChildIndex != InvalidIndex &&
                            CheckSwapRequired(absMinHeap[nextParentIndex], absMinHeap[rightChildIndex]))
                            nextParentIndex = rightChildIndex;

                        if (nextParentIndex == parentIndex)
                            break;

                        int temp = absMinHeap[parentIndex];
                        absMinHeap[parentIndex] = absMinHeap[nextParentIndex];
                        absMinHeap[nextParentIndex] = temp;
                        parentIndex = nextParentIndex;
                    }
                    
                    --count;
                }
            }
        }
        Console.Write(output);
    }

    private static bool CheckSwapRequired(int parentData, int childData)
    {
        int parentPriority = Math.Abs(parentData);
        int childPriority = Math.Abs(childData);

        if (parentPriority == childPriority)
        {
            return parentData > childData;
        }
        else
        {
            return parentPriority > childPriority;
        }
    }
}