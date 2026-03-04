public class Program
{
    public static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int a = tokens[0];
        int b = tokens[1];

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int c = tokens[0];
        int d = tokens[1];

        int hanyangRequiredTime = a + c;
        int yongdapRequiredTime = b + d;

        string output;
        if (hanyangRequiredTime < yongdapRequiredTime)
        {
            output = "Hanyang Univ.";
        }
        else if (hanyangRequiredTime > yongdapRequiredTime)
        {
            output = "Yongdap";
        }
        else
        {
            output = "Either";
        }
        
        Console.Write(output);
    }
}