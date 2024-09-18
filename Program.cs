internal class Program
{
    private static void Main(string[] args)
    {
        int[] arr = { 4, 5, 1, 3, 2 };

        bubble_sort(ref arr);

        return;
    }
    
    private static void bubble_sort(ref int[] arr)
    {
        int arr_length = arr.Length;

        for (int i = 0; i < arr_length - 1; ++i)
        {
            for (int j = 0; j < arr_length - i - 1; ++j)
            {
                int arr_j = arr[j];
                int arr_j_1 = arr[j + 1];

                if (arr_j > arr_j_1)
                {
                    arr[j] = arr_j_1;
                    arr[j + 1] = arr_j;
                }
            }
        }
    }
}