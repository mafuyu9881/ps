class Program
{
    static void Main(string[] args)
    {
        string serial = Console.ReadLine()!;

        char typecode = serial[0];

        string type;
        if (typecode == 'F')
        {
            type = "Foundation";
        }
        else if (typecode == 'C')
        {
            type = "Claves";
        }
        else if (typecode == 'V')
        {
            type = "Veritas";
        }
        else // if (type == 'E')
        {
            type = "Exploration";
        }

        Console.Write(type);
    }
}