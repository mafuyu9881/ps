internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int m = int.Parse(Console.ReadLine()!);

        // length = [1, 15'000]
        // element = [1, 100'000]
        int[] materials = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Array.Sort(materials);

        int armours = 0;
        {
            int i = 0;
            int j = materials.Length - 1;
            while (i < j)
            {
                int sum = materials[i] + materials[j];
                if (sum < m)
                {
                    ++i;
                }
                else if (sum > m)
                {
                    --j;
                }
                else
                {
                    ++armours;
                    ++i;
                    --j;
                }
            }
        }
        Console.Write(armours);
    }
}