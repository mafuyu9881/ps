internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 50]

        int[,] cables = new int[n, n]; // max sc = 50 * 50 * 4B = 10'000B = 10KB

        int donated = 0;

        for (int s = 0; s < n; ++s) // max tc = 50
        {
            string stringToken = Console.ReadLine()!;
            for (int e = 0; e < n; ++e) // max tc = 50
            {
                char charToken = stringToken[e];

                int newCable = 0;
                if (charToken >= 'a' && charToken <= 'z')
                {
                    newCable = charToken - 'a' + 1;
                }
                else if (charToken >= 'A' && charToken <= 'Z')
                {
                    newCable = charToken - 'A' + 27;
                }

                if (s == e)
                {
                    donated += newCable;
                }
                else if (s < e)
                {
                    cables[s, e] = newCable;
                    cables[e, s] = newCable;
                }
                else
                {
                    int oldCable = cables[e, s];
                    if (oldCable > 0)
                    {
                        donated += Math.Max(newCable, oldCable);
                        newCable = Math.Min(newCable, oldCable);
                    }
                
                    cables[s, e] = newCable;
                    cables[e, s] = newCable;
                }
            }
        }
    }
}