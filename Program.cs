using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        Vector3[] points = new Vector3[n];
        for (int i = 0; i < n; ++i)
        {
            float[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), float.Parse);
            points[i] = new(tokens[0], tokens[1], 0.0f);
        }

        float area = 0;
        Vector3 p0 = points[0];
        for (int i = 1; i < n - 1; ++i)
        {
            Vector3 p1 = points[i];
            Vector3 p2 = points[i + 1];

            Vector3 p0p1 = p1 - p0;
            Vector3 p0p2 = p2 - p0;

            area += Vector3.Cross(p0p1, p0p2).Length() * 0.5f;
        }
        Console.WriteLine(area.ToString("0.0"));
    }
}