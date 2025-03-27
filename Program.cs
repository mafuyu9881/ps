using System.Text;

internal class Program
{
    private struct Participant
    {
        public string Name;
        public int Score;
        public bool Hidden;

        public Participant(string name, int score, bool hidden)
        {
            Name = name;
            Score = score;
            Hidden = hidden;
        }
    }

    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        Participant[] participants = new Participant[n];        

        for (int i = 0; i < n; ++i)
        {
            string[] tokens = Console.ReadLine()!.Split(',', StringSplitOptions.RemoveEmptyEntries);

            string name = ParseString(tokens[0]);
            int score = ParseInteger(tokens[1]); // [1, 10^9]
            bool hidden = ParseInteger(tokens[2]) == 1;

            participants[i] = new(name, score, hidden);
        }

        Array.Sort(participants, (x, y) => y.Score.CompareTo(x.Score));

        StringBuilder sb = new();
        int j = 0;
        while (j < participants.Length)
        {
            LinkedList<Participant> tiedLL = new();
            
            tiedLL.AddLast(participants[j]);
            
            int k = j + 1;
            while (k < participants.Length)
            {
                if (participants[j].Score == participants[k].Score)
                {
                    tiedLL.AddLast(participants[k]);
                    ++k;
                }
                else
                {
                    break;
                }
            }

            Participant[] tiedArr = tiedLL.ToArray();
            Array.Sort(tiedArr, (x, y) => x.Name.CompareTo(y.Name));
            for (int l = 0; l < tiedArr.Length; ++l)
            {
                Participant participant = tiedArr[l];

                if (participant.Hidden)
                    continue;

                sb.AppendLine($"{j + 1} {participant.Name} {participant.Score}");
            }

            j += tiedArr.Length;
        }
        Console.Write(sb);
    }

    private static string ParseString(string token)
    {
        string[] tokens = token.Split(":");

        StringBuilder sb = new(tokens[1]);

        int i = 0;
        while (i < sb.Length)
        {
            char c = sb[i];
            if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
            {
                ++i;
            }
            else
            {
                sb.Remove(i, 1);
            }
        }

        return sb.ToString();
    }

    private static int ParseInteger(string token)
    {
        string[] tokens = token.Split(":");

        StringBuilder sb = new(tokens[1]);

        int i = 0;
        while (i < sb.Length)
        {
            char c = sb[i];
            if (c >= '0' && c <= '9')
            {
                ++i;
            }
            else
            {
                sb.Remove(i, 1);
            }
        }
        
        return int.Parse(sb.ToString());
    }
}