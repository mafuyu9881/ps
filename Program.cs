using System.Text;

class Program
{
    static void Main(string[] args)
    {
        const int MinuteSeconds = 60;
        const int HourSeconds = 60 * MinuteSeconds;

        StringBuilder sb = new();
        for (int i = 0; i < 3; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int start = tokens[0] * HourSeconds + tokens[1] * MinuteSeconds + tokens[2];
            int end = tokens[3] * HourSeconds + tokens[4] * MinuteSeconds + tokens[5];
            int interval = end - start;
            sb.AppendLine($"{interval / HourSeconds} {interval % HourSeconds / MinuteSeconds} {interval % MinuteSeconds}");
        }
        Console.Write(sb);
    }
}