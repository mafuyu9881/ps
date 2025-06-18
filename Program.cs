using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [?, 2000]

        char[] s = new char[n];
        for (int i = 0; i < n; ++i)
        {
            s[i] = Console.ReadLine()![0];
        }

        char[] t = new char[n];
        {
            int writingIndex = 0;

            int lo = 0;
            int hi = n - 1;
            while (writingIndex < n)
            {
                char loC = s[lo];
                char hiC = s[hi];

                if (loC < hiC)
                {
                    t[writingIndex] = loC;
                    ++lo;
                }
                else if (loC > hiC)
                {
                    t[writingIndex] = hiC;
                    --hi;
                }
                else
                {
                    if (lo == hi)
                    {
                        t[writingIndex] = loC;
                        ++lo;
                    }
                    else
                    {
                        bool writeLo = true;
                        int l = lo;
                        int r = hi;
                        while (l < r)
                        {
                            char lC = s[l];
                            char rC = s[r];
                            if (lC < rC)
                            {
                                writeLo = true;
                                break;
                            }
                            else if (lC > rC)
                            {
                                writeLo = false;
                                break;
                            }
                            else
                            {
                                ++l;
                                --r;
                            }
                        }

                        if (writeLo)
                        {
                            t[writingIndex] = loC;
                            ++lo;
                        }
                        else
                        {
                            t[writingIndex] = hiC;
                            --hi;
                        }
                    }
                }
                ++writingIndex;
            }
        }

        StringBuilder sb = new();
        for (int i = 0; i < n; ++i)
        {
            if (i > 0 && i % 80 == 0)
            {
                sb.AppendLine();
            }
            sb.Append(t[i]);
        }
        Console.Write(sb);
    }
}