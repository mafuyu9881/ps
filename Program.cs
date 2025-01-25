using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int h = tokens[0]; // [1, 500]
        int w = tokens[1]; // [1, 500]

        int[] map = new int[w * h];
        LinkedList<int> objectives = new();
        for (int r = 0; r < h; ++r)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int c = 0; c < w; ++c)
            {
                int idx = r * w + c;
                map[idx] = tokens[c];
                objectives.AddLast(idx);
            }
        }

        Stack<int> s = new();
        bool[] visited = new bool[map.Length];
        LinkedList<LinkedList<int>> pictures = new();
        LinkedList<int> maxPicture = null!;
        LinkedList<int> picture = new();

        while (true) // max tc = 250'000
        {
            while (objectives.Count > 0)
            {
                var node = objectives.First!;
                s.Push(node.Value);
                objectives.Remove(node);
                break;
            }
            
            if (s.Count < 1)
                break;

            int idx = s.Pop();
            if (visited[idx])
                continue;

            visited[idx] = true;
            if (map[idx] == 0)
                continue;

            picture.AddLast(idx);
            
            int r = idx / w;
            int c = idx % w;
            
            bool isolated = true;
            (int r, int c)[] offsets = new (int, int)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
            for (int i = 0; i < offsets.Length; ++i)
            {
                var offset = offsets[i];

                int adjR = r + offset.r;
                if (adjR < 0 || adjR > h - 1)
                    continue;

                int adjC = c + offset.c;
                if (adjC < 0 || adjC > w - 1)
                    continue;

                int adjIdx = adjR * w + adjC;
                if (visited[adjIdx])
                    continue;

                if (map[adjIdx] == 0)
                    continue;

                s.Push(adjIdx);
                isolated = false;
            }

            if (isolated)
            {
                pictures.AddLast(picture);
                if (maxPicture == null || picture.Count > maxPicture.Count)
                {
                    maxPicture = picture;
                }
                picture = new();
            }
        }

        StringBuilder output = new();
        output.AppendLine($"{pictures.Count}");
        output.AppendLine($"{maxPicture.Count}");
        Console.Write(output);
    }
}