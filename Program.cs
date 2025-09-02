using System.Text;

class Program
{
    static void Main(string[] args)
    {
        StringBuilder output = new();
        while (true)
        {
            string[] tokens = Console.ReadLine()!.Split();
            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            int weight = int.Parse(tokens[2]);
            if (name == "#" && age == 0 && weight == 0)
                break;

            output.AppendLine($"{name} {((age > 17 || weight >= 80) ? "Senior" : "Junior")}");
        }
        Console.Write(output);
    }
}