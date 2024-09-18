internal class Program
{
    private static void Main(string[] args)
    {
        int[] arr = { 4, 5, 1, 3, 2 };

        return;
    }
    
    // 정렬 대상을 올바른 위치까지 차례차례 스왑해나가는 방식
    private static void insertion_sort_1(ref int[] arr)
    {
        for (int i = 1; i < arr.Length; ++i)
        {
            int key = i;

            for (int j = i - 1; j >= 0; --j)
            {
                if (arr[j] > arr[key])
                {
                    int temp = arr[j];
                    arr[j] = arr[key];
                    arr[key] = temp;
                    key = j;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine();
        }
    }

    // 정렬 대상이 들어갈 자리를 먼저 마련하기 위해 다른 원소들을 한 칸씩 옮긴 다음 해당 자리에 대입하는 방식 
    private static void insertion_sort_2(ref int[] arr)
    {
        int i;
        int j;
        int key;

        for (i = 1; i < arr.Length; i++)
        {
            key = arr[i];

            for (j = i - 1; j >= 0; j--)
            {
                if (arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                }
                else
                {
                    break;
                }
            }

            arr[j + 1] = key;
        }
    }
}