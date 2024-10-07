using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] arr = [ 2, 5, 1, 3, 4 ];

        MergeSort(arr);

        StringBuilder output = new();
        for (int i = 0; i < arr.Length; ++i)
        {
            output.Append($"{arr[i]} ");
        }
        Console.Write(output);
    }

    private static void BubbleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; ++i)
        {
            for (int j = 0; j < arr.Length - 1 - i; ++j)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    private static void SelectionSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; ++i)
        {
            int selectedIndex = i;
            for (int j = i + 1; j < arr.Length; ++j)
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

    private static void InsertionSort1(int[] arr)
    {
        for (int i = 1; i < arr.Length; ++i)
        {
            for (int j = i; j > 0; --j)
            {
                if (arr[j] < arr[j - 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j - 1];
                    arr[j - 1] = temp;
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
        for (int i = 1; i < arr.Length; ++i)
        {
            int objectiveIndex = i;
            int objectiveElement = arr[i];
            for (int j = i - 1; j > -1; --j)
            {
                if (objectiveElement < arr[j])
                {
                    arr[j + 1] = arr[j];
                    objectiveIndex = j;
                }
                else
                {
                    break;
                }
            }
            arr[objectiveIndex] = objectiveElement;
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