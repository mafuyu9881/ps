internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        string[] outputs = new string[] { "YONSEI", "Leading the Way to the Future" };

        Console.WriteLine(outputs[n]);
    }
}