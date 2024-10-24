using System.Text;

internal class Program
{
    private static Dictionary<char, int> romanToArabicDictionary = new()
    {
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000},
    };

    private static void Main(string[] args)
    {
        string roman0 = Console.ReadLine()!;
        string roman1 = Console.ReadLine()!;
        
        int arabic0 = ConvertRomanToArabic(roman0);
        int arabic1 = ConvertRomanToArabic(roman1);
        
        int arabicSum = arabic0 + arabic1;
        string romanSum = ConvertArabicToRoman(arabicSum);
        
        Console.WriteLine(arabicSum);
        Console.WriteLine(romanSum);
    }

    private static int ConvertRomanToArabic(string input)
    {
        int output = 0;

        if (input.Length > 1)
        {
            char prevRoman = input[0];
            for (int i = 1; i < input.Length; ++i)
            {
                char currRoman = input[i];

                int prevArabic = romanToArabicDictionary[prevRoman];
                int currArabic = romanToArabicDictionary[currRoman];

                if (prevArabic < currArabic)
                {
                    output -= prevArabic;
                }
                else
                {
                    output += prevArabic;
                }

                if (i == input.Length - 1)
                {
                    output += currArabic;
                }

                prevRoman = currRoman;
            }
        }
        else
        {
            output = romanToArabicDictionary[input[0]];
        }

        return output;
    }

    private static string ConvertArabicToRoman(int input)
    {
        return ConvertArabicToRoman($"{input}");
    }
    private static string ConvertArabicToRoman(string input)
    {
        StringBuilder output = new();

        int inputLength = input.Length;
        for (int i = 0; i < inputLength; ++i)
        {
            char c = input[i];

            int digit = inputLength - i;

            string s = "";
            if (c == '4')
            {
                if (digit == 1) s = "IV";
                if (digit == 2) s = "XL";
                if (digit == 3) s = "CD";
                output.Append(s);
            }
            else if (c == '5')
            {
                if (digit == 1) s = "V";
                if (digit == 2) s = "L";
                if (digit == 3) s = "D";
                output.Append(s);
            }
            else if (c == '9')
            {
                if (digit == 1) s = "IX";
                if (digit == 2) s = "XC";
                if (digit == 3) s = "CM";
                output.Append(s);
            }
            else if (c > '5')
            {
                if (digit == 1) s = "V";
                if (digit == 2) s = "L";
                if (digit == 3) s = "D";
                output.Append(s);

                if (digit == 1) s = "I";
                if (digit == 2) s = "X";
                if (digit == 3) s = "C";
                for (int j = 0; j < (c - '5'); ++j) output.Append(s);
            }
            else // if (c < '4')
            {
                if (digit == 1) s = "I";
                if (digit == 2) s = "X";
                if (digit == 3) s = "C";
                if (digit == 4) s = "M";
                for (int j = 0; j < (c - '0'); ++j) output.Append(s);
            }
        }

        return $"{output}";
    }
}