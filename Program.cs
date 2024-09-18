internal class Program
{
    private static void Main(string[] args)
    {
        int[] arr = { 4, 5, 1, 3, 2 };

        selection_sort(ref arr);

        return;
    }
    
    private static void selection_sort(ref int[] arr)
    {
        int arr_length = arr.Length;

        for (int i = 0; i < arr_length; ++i)
        {
            int elected_index = i;

            for (int j = i; j < arr_length; ++j)
            {
                if (arr[j] < arr[elected_index])
                {
                    elected_index = j;
                }
            }

            int temp = arr[i];
            arr[i] = arr[elected_index];
            arr[elected_index] = temp;
        }
    }
}