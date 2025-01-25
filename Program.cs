using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int h = tokens[0]; // [1, 500]
        int w = tokens[1]; // [1, 500]

        int[] map = new int[w * h];
        LinkedList<int> candidates = new();
        for (int r = 0; r < h; ++r) // max tc = 500
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int c = 0; c < w; ++c) // max tc = 500
            {
                int idx = r * w + c;
                map[idx] = tokens[c];
                candidates.AddLast(idx);
            }
        }

        Queue<int> q = new();
        bool[] visited = new bool[map.Length];
        LinkedList<LinkedList<int>> pictures = new();
        LinkedList<int> maxPicture = new();
        LinkedList<int> picture = new();

        while (true) // max tc = 250'000
        {
            while (q.Count < 1 && candidates.Count > 0)
            {
                var node = candidates.First!;
                int candidateIdx = node.Value;
                candidates.Remove(node);

                if (visited[candidateIdx])
                    continue;

                if (map[candidateIdx] == 0)
                    continue;

                picture = new();
                pictures.AddLast(picture);
                visited[candidateIdx] = true;
                q.Enqueue(node.Value);
                break;
            }
            
            if (q.Count < 1)
                break;

            int idx = q.Dequeue();
            int r = idx / w;
            int c = idx % w;

            picture.AddLast(idx);
            if (picture.Count > maxPicture.Count)
            {
                maxPicture = picture;
            }
            
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

                visited[adjIdx] = true;
                q.Enqueue(adjIdx);
            }
        }

        // in line 46 and 84, we have to code them in both places rather than line 57
        // if we code it on line 57, we will face duplicated elements in q

        StringBuilder output = new();
        output.AppendLine($"{pictures.Count}");
        output.AppendLine($"{maxPicture.Count}");
        Console.Write(output);
    }
}