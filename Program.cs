using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        long[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), long.Parse);
        long n = tokens[0]; // [2, 5]
        long b = tokens[1]; // [1, 100'000'000'000]

        int[][] basis = new int[n][];
        for (int row = 0; row < basis.Length; ++row) // max tc = 5
        {
            // element = [0, 1'000]
            basis[row] = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // max tc = 5
        }

        int[][] output = new int[basis.Length][];
        for (int row = 0; row < output.Length; ++row) // max tc = 5
        {
            output[row] = new int[basis[row].Length];
            output[row][row] = 1;
        }

        while (b > 0) // max tc = log2(100'000'000'000) = 36.xxx
        {
            if ((b & 1) == 1)
            {
                output = Multiply(output, basis);
            }

            basis = Multiply(basis, basis);
            b >>= 1;
        }

        StringBuilder sb = new();
        for (int row = 0; row < output.Length; ++row)
        {
            for (int col = 0; col < output[row].Length; ++col)
            {
                sb.Append($"{output[row][col]} ");
            }
            sb.AppendLine();
        }
        Console.Write(sb);
    }

    // in this case, we consider a and b as a square matrices
    private static int[][] Multiply(int[][] a, int[][] b)
    {
        int n = a.Length;

        int[][] output = new int[n][];
        for (int i = 0; i < n; ++i) // max tc = 5
        {
            output[i] = new int[n];
            for (int j = 0; j < n; ++j) // max tc = 5
            {
                for (int k = 0; k < n; ++k) // max tc = 5
                {
                    output[i][j] = (output[i][j] + a[i][k] * b[k][j]) % 1000;
                }
            }
        }
        return output;
    }
}