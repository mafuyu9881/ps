using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] arr = new int[] { 2, 5, 1, 4, 3 };

        MergeSort(arr);

        StringBuilder output = new();
        for (int i = 0; i < arr.Length; ++i)
        {
            output.AppendLine($"{arr[i]}");
        }
        Console.Write(output);
    }

    private static void BubbleSort(int[] arr)
    {
        int iterableLength = arr.Length - 1;

        for (int i = 0; i < iterableLength; ++i)
        {
            for (int j = 0; j < iterableLength; ++j)
            {
                int jElement = arr[j];
                int nextJ = j + 1;
                int nextJElement = arr[nextJ];

                if (jElement > nextJElement)
                {
                    arr[j] = nextJElement;
                    arr[nextJ] = jElement;
                }
            }
        }
    }

    private static void InsertionSort1(int[] arr)
    {
        for (int i = 1; i < arr.Length; ++i)
        {
            for (int j = i; j > 0; --j)
            {
                int jElement = arr[j];
                int prevJ = j - 1;
                int prevJElement = arr[prevJ];

                if (jElement < prevJElement)
                {
                    arr[j] = prevJElement;
                    arr[prevJ] = jElement;
                }
                else
                {
                    break;
                }
            }
        }
    }

    private static void InsertionSort2(int[] arr)
    {
        //for (int i = 1; i < arr.Length; ++i)
        //{
        //    int objectiveElement = arr[i];
        //    int objectiveIndex = i;
        //    for (int j = i - 1; j > -1; --j)
        //    {
        //        if (arr[j] > objectiveElement)
        //        {
        //            arr[j + 1] = arr[j];
        //            objectiveIndex = j;
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }
        //    arr[objectiveIndex] = objectiveElement;
        //}

        //for (int i = 1; i < arr.Length; ++i)
        //{
        //    int objectiveElement = arr[i];
        //    int j = i - 1;
        //    while (j > -1)
        //    {
        //        if (objectiveElement < arr[j])
        //        {
        //            arr[j + 1] = arr[j];
        //            --j;
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }
        //    arr[j + 1] = objectiveElement;
        //}

        for (int i = 1; i < arr.Length; ++i)
        {
            int objectiveElement = arr[i];
            int j = i - 1;
            for (; j > -1; --j)
            {
                if (objectiveElement < arr[j])
                {
                    arr[j + 1] = arr[j];
                }
                else
                {
                    break;
                }
            }
            arr[j + 1] = objectiveElement;
        }
    }

    private static void SelectionSort(int[] arr)
    {
        //const int InvalidIndex = -1;
        //int arrLength = arr.Length;
        //int iterableLength = arrLength - 1;

        //for (int i = 0; i < iterableLength; ++i)
        //{
        //    int selectedIndex = InvalidIndex;
        //    for (int j = 0; j < arrLength - i; ++j)
        //    {
        //        if (selectedIndex == InvalidIndex ||
        //            arr[selectedIndex] < arr[j])
        //        {
        //            selectedIndex = j;
        //        }
        //    }
        //    int temp = arr[selectedIndex];
        //    arr[selectedIndex] = arr[iterableLength - i];
        //    arr[iterableLength - i] = temp;
        //}

        int arrLength = arr.Length;

        for (int i = 0; i < arrLength - 1; ++i)
        {
            int selectedIndex = i;
            for (int j = i + 1; j < arrLength; ++j)
            {
                if (arr[j] < arr[selectedIndex])
                {
                    selectedIndex = j;
                }
            }
            int temp = arr[i];
            arr[i] = arr[selectedIndex];
            arr[selectedIndex] = temp;
        }
    }

    private static void MergeSort(Span<int> arr)
    {
        int arrLength = arr.Length;
        if (arrLength < 2)
            return;

        int midIndex = arrLength / 2;

        MergeSort(arr.Slice(0, midIndex));
        MergeSort(arr.Slice(midIndex));
        Merge(arr, midIndex);
    }

    private static void Merge(Span<int> arr, int midIndex)
    {
        int arrLength = arr.Length;

        int[] backedup = arr.ToArray();

        int leftReadIndex = 0;
        int rightReadIndex = midIndex;
        int writtenIndex = 0;
        
        while (leftReadIndex < midIndex && rightReadIndex < arrLength)
        {
            if (backedup[leftReadIndex] < backedup[rightReadIndex])
            {
                arr[writtenIndex] = backedup[leftReadIndex];
                ++leftReadIndex;
            }
            else
            {
                arr[writtenIndex] = backedup[rightReadIndex];
                ++rightReadIndex;
            }
            ++writtenIndex;
        }
        
        while (leftReadIndex < midIndex)
        {
            arr[writtenIndex] = backedup[leftReadIndex];
            ++leftReadIndex;
            ++writtenIndex;
        }

        while (rightReadIndex < arrLength)
        {
            arr[writtenIndex] = backedup[rightReadIndex];
            ++rightReadIndex;
            ++writtenIndex;
        }
    }
}