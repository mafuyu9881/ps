public class Program
{
    public static void Main(string[] args)
    {
        string s = Console.ReadLine()!;

        SortedSet<char> mobis = new SortedSet<char>() { 'M', 'O', 'B', 'I', 'S' };
        for (int i = 0; i < s.Length; ++i)
        {
            mobis.Remove(s[i]);
        }

        Console.Write(mobis.Count > 0 ? "NO" : "YES");
    }
}