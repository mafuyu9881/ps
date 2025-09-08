class Program
{
    static void Main(string[] args)
    {
        int[] sequence = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int a = sequence[0];
        int b = sequence[1];
        int c = sequence[2];

        int output;
        if (a == b && b == c)
        {
            output = 10000 + a * 1000;
        }
        else if (a != b && b != c && c != a)
        {
            output = Math.Max(a, Math.Max(b, c)) * 100;
        }
        else
        {
            int face;
            if (a == b)
            {
                face = a;
            }
            else if (b == c)
            {
                face = b;
            }
            else //if (c == a)
            {
                face = c;
            }
            output = 1000 + face * 100;
        }
        Console.Write(output);
    }
}