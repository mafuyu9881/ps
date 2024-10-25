// 1 <= (최댓값의 최솟값) <= 30000
// 0 <= log (최댓값의 최솟값) <= 14.xxx (단, log의 밑은 2)

using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        
        int n = tokens[0];
        int m = tokens[1];

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int[] beadValues = new int[n];
        for (int i = 0; i < n; ++i)
        {
            beadValues[i] = tokens[i];
        }

        int minOfMaxGroupBeadValue = 0;
        int left = 1;
        int right = 30000;
        LinkedList<int>? groupedBeadCountList = null;
        LinkedListNode<int>? maxGroupedBeadCountNode = null;
        while (left <= right)
        {
            int mid = (left + right) / 2;

            LinkedList<int>? tempGroupedBeadCountList = null;
            LinkedListNode<int>? tempMaxGroupedBeadCountNode = null;
            if (Validation(out tempGroupedBeadCountList,
                           out tempMaxGroupedBeadCountNode,
                           beadValues,
                           mid,
                           m))
            {
                right = mid - 1;
                minOfMaxGroupBeadValue = mid;
                groupedBeadCountList = tempGroupedBeadCountList;
                maxGroupedBeadCountNode = tempMaxGroupedBeadCountNode;
            }
            else
            {
                left = mid + 1;
            }
        }

        StringBuilder output = new();
        
        output.AppendLine($"{minOfMaxGroupBeadValue}");

        while (groupedBeadCountList!.Count != m)
        {
            LinkedListNode<int>? separatingCountNode = null;
            while (separatingCountNode == null)
            {
                for (var node = groupedBeadCountList!.First; node != null; node = node.Next)
                {
                    if (node == maxGroupedBeadCountNode)
                        continue;

                    if (node.Value < 2)
                        continue;

                    separatingCountNode = node;
                    break;
                }
            }

            int separatedCount = separatingCountNode!.Value / 2;
            separatingCountNode.ValueRef -= separatedCount;
            groupedBeadCountList.AddAfter(separatingCountNode, separatedCount);
        }

        for (var node = groupedBeadCountList!.First; node != null; node = node.Next)
        {
            output.Append($"{node.Value} ");
        }

        Console.Write(output);
    }

    private static bool Validation(out LinkedList<int>? outGroupedBeadCountList,
                            out LinkedListNode<int>? outMaxGroupedBeadCountNode,
                            int[] beadValues,
                            int mid,
                            int m)
    {
        outGroupedBeadCountList = new();
        outMaxGroupedBeadCountNode = null;

        LinkedListNode<int>? groupedBeadCountNode = null;
        int groupedBeadValue = 0;
        for (int i = 0; i < beadValues.Length; ++i)
        {
            int beadValue = beadValues[i];

            // 1. (i == 0)
            // 2. (groupedBeadCountNode == null)
            // 3. (outGroupedBeadCountList.Count == 0)
            // 1, 2, 3 모두 첫 순회임을 나타내는 조건입니다.
            // 컴파일 경고를 피하기 위해 2번의 조건문으로 선택했습니다.
            if (groupedBeadCountNode == null ||
                groupedBeadValue + beadValue > mid)
            {
                groupedBeadCountNode = outGroupedBeadCountList.AddLast(0);
                groupedBeadValue = 0;
            }

            ++groupedBeadCountNode.ValueRef;
            groupedBeadValue += beadValue;

            // 구슬 묶음의 총합이 요구된 매개변수 값보다 크다면,
            // 이 매개변수는 실현될 수 없는 값입니다.
            if (groupedBeadValue > mid)
                return false;

            // 구슬 묶음의 총합이 요구된 매개변수와 일치하는 묶음을 기억해둡니다.
            // 이후의 정답 출력 단계에서 각 묶음을 구성하는 구슬의 개수를 출력할 때
            // 전체 묶음의 수가 부족할 경우
            // 일부 묶음을 분할하여 요구된 묶음의 개수 m을 채워야하는데,
            // 이 때 이 묶음을 분할해선 안되기 때문입니다.

            // 물론 outGroupedBeadCountList에 이 조건을 만족하는 묶음이 항상 있을 수는 없습니다.
            // 하지만 매개변수 탐색의 과정 상, 반복 과정에서 필연적으로 그런 mid 값이 나타나기 때문에,
            // 이렇게 작성할 수 있습니다.

            if (groupedBeadValue == mid)
            {
                if ((outMaxGroupedBeadCountNode == null) ||
                    (outMaxGroupedBeadCountNode != null &&
                    groupedBeadCountNode.Value < outMaxGroupedBeadCountNode.Value))
                {
                    outMaxGroupedBeadCountNode = groupedBeadCountNode;
                }
            }
        }

        return outGroupedBeadCountList.Count <= m;
    }
}