internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];
        int t = tokens[1];

        LR[] lrs = new LR[n];
        for (int i = 0; i < n; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);;
            lrs[i] = new(tokens[0], tokens[1]);
        }

        const int InvalidMinimumS = int.MaxValue;
        int minimumS = InvalidMinimumS;
        int low = 1 - 1;
        int high = t + 1;
        while (low < high - 1)
        {
            int mid = (low + high) / 2;

            if (Check(ref minimumS, lrs, t, mid) == LowerUpper.Lower)
            {
                high = mid;
            }
            else
            {
                low = mid;
            }
        }
        Console.Write((minimumS != InvalidMinimumS) ? minimumS : -1);
    }

    private enum LowerUpper
    {
        Lower,
        Upper,
    }
    private static LowerUpper Check(ref int minimumS, LR[] lrs, int t, int s)
    {
        int remainT = t;
        int clearance = 0;
        for (int i = 0; i < lrs.Length; ++i)
        {
            int l = lrs[i].L;
            int r = lrs[i].R;

            if (s < l)
                return LowerUpper.Upper;
            
            clearance += Math.Min(s, r) - l;

            remainT -= l;
        }

        if (remainT < 0)
            return LowerUpper.Lower;

        if (remainT > clearance)
            return LowerUpper.Upper;

        minimumS = Math.Min(minimumS, s);

        return LowerUpper.Lower;
    }

    private struct LR
    {
        private int _l;
        private int _r;
        public int L => _l;
        public int R => _r;
        public LR(int l, int r)
        {
            _l = l;
            _r = r;
        }
    }
}