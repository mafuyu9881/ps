class Program
{
    static void Main(string[] args)
    {
        const int Stations = 4;

        int maxPassengers = 0;
        int currPassengers = 0;
        for (int i = 0; i < Stations; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int alightings = tokens[0];
            int boardings = tokens[1];
            
            currPassengers -= alightings;
            currPassengers += boardings;
            
            maxPassengers = Math.Max(maxPassengers, currPassengers);
        }
        
        Console.Write(maxPassengers);
    }
}