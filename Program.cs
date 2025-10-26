class Program
{
    static void Main(string[] args)
    {
        double weight = double.Parse(Console.ReadLine()!);
        double height = double.Parse(Console.ReadLine()!);
        double bmi = weight / (height * height);
        string message;
        if (bmi > 25)
        {
            message = "Overweight";
        }
        else if (bmi > 18.5)
        {
            message = "Normal weight";
        }
        else
        {
            message = "Underweight";
        }
        Console.Write(message);
    }
}