internal class Program
{
    private static void Main(string[] args)
    {
        int[] arr = { 4, 5, 1, 3, 2, 8, 6, 7 };

        merge_sort(arr);

        return;
    }

    // Span<T>를 활용한 구현
    private static void merge_sort(int[] arr)
    {
        merge_sort(new Span<int>(arr));
    }

    private static void merge_sort(Span<int> arr)
    {
        int arr_length = arr.Length;

        if (arr_length < 2)
            return;
        
        int mid = arr_length / 2;

        merge_sort(arr.Slice(0, mid));
        merge_sort(arr.Slice(mid));
        merge(arr, mid);
    }

    private static void merge(Span<int> arr, int mid)
    {
        int arr_length = arr.Length;
        
        int[] past = arr.ToArray();
        
        int left_read_index = 0;
        int right_read_index = mid;
        int written_index = 0;

        while (left_read_index < mid && right_read_index < arr_length)
        {
            if (past[left_read_index] > past[right_read_index])
            {
                arr[written_index++] = past[right_read_index++];
            }
            else
            {
                arr[written_index++] = past[left_read_index++];
            }
        }

        while (left_read_index < mid)
        {
            arr[written_index++] = past[left_read_index++];
        }

        while (right_read_index < arr_length)
        {
            arr[written_index++] = past[right_read_index++];
        }
    }

    // 기본 제공 자료형만을 활용한 구현
    /*
    private static void merge_sort(ref int[] arr, int left, int right)
    {
        if (left >= right)
            return;

        int mid = (left + right) / 2;
        
        merge_sort(ref arr, left, mid);
        merge_sort(ref arr, mid + 1, right);
        merge(ref arr, left, mid, right);
    }
    
    private static void merge(ref int[] arr, int left, int mid, int right)
    {
        int[] backup = arr.ToArray();

        int i = left;
        int j = mid + 1;
        int k = left;

        // 두 정렬된 영역의 원소를 비교해가며 정렬이 유지되도록 새 컨테이너에 삽입한다.

        while (i <= mid && j <= right)
        {
            if (backup[i] <= backup[j])
            {
                arr[k++] = backup[i++];
            }
            else
            {
                arr[k++] = backup[j++];
            }
        }

        // 위 while문은 i 혹은 j 중 분할된 두 영역 중 한 쪽의 원소가 모두 삽입되고 나면 바로 종료되므로, 다른 한 쪽 영역의 원소들이 삽입되지 않은 채로 남게 된다.
        // 따라서 이 남은 원소들을 아래의 반복문 중 하나를 통해 마저 삽입해준다.

        while (i <= mid)
        {
            arr[k++] = backup[i++];
        }

        while (j <= right)
        {
            arr[k++] = backup[j++];
        }
    }
    */
}