using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (input == null)
                break;

            string[] tokens = input.Split();
            if (tokens == null)
                break;

            if (tokens.Length < 2)
                break;

            int a = int.Parse(tokens[0]);
            int b = int.Parse(tokens[1]);

            // StringBuilder를 통해 while문 밖에서 한 번만 출력하고 마치고 싶지만,
            // 입력의 끝이 불분명하기 때문에 입력을 종료할 수 없어서 이렇게 작성하였다.
            Console.WriteLine((a + b).ToString());
        }
    }
}

//Console.ReadKey();