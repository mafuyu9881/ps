class Program
{
    static void Main(string[] args)
    {
        int wavelength = int.Parse(Console.ReadLine()!);

        string output;
        if (wavelength >= 620 && wavelength <= 780)
        {
            output = "Red";
        }
        else if (wavelength >= 590 && wavelength < 620)
        {
            output = "Orange";
        }
        else if (wavelength >= 570 && wavelength < 590)
        {
            output = "Yellow";
        }
        else if (wavelength >= 495 && wavelength < 570)
        {
            output = "Green";
        }
        else if (wavelength >= 450 && wavelength < 495)
        {
            output = "Blue";
        }
        else if (wavelength >= 425 && wavelength < 450)
        {
            output = "Indigo";
        }
        else
        {
            output = "Violet";
        }
        Console.Write(output);
    }
}