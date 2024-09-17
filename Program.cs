internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();

        int n = int.Parse(tokens[0]);
        int m = int.Parse(tokens[1]);

        tokens = Console.ReadLine()!.Split();

        int[] cards = new int[n];
        for (int i = 0; i < n; ++i)
        {
            cards[i] = int.Parse(tokens[i]);
        }

        int? max_sum = null;
        ComputeMaxSum(ref max_sum, ref cards, m, 3);

        Console.Write(max_sum);
    }

    // tno_cards_to_draw: 뽑을 카드의 개수입니다. (the number of)
    // tno_cards_drawn: 뽑힌 카드의 개수입니다.
    // drawn_card_indices: 이 값 이하의 카드들은 모두 뽑힌 것으로 취급합니다. 그래서 int형임에도 변수명을 복수형으로 작성하였습니다. 또한, 반드시 0 이상의 값이 들어온다고 전제합니다.
    private static void ComputeMaxSum(ref int? max_sum, ref int[] cards, int sum_limit, int tno_cards_to_draw, int? tno_cards_drawn = null, int? drawn_card_indices = null, int? candidate_sum = null)
    {
        // TODO: Span의 Slice 활용을 통해 begin_index를 생략할 수 있을 것이다.
        int begin_index = (drawn_card_indices == null) ? 0 : (drawn_card_indices.Value + 1);

        if (tno_cards_drawn == null)
            tno_cards_drawn = 0;

        if (candidate_sum == null)
            candidate_sum = 0;

        for (int i = begin_index; i < cards.Length; ++i)
        {
            int card = cards[i];
            candidate_sum += card;
            ++tno_cards_drawn;

            if (tno_cards_drawn < tno_cards_to_draw)
            {
                ComputeMaxSum(ref max_sum, ref cards, sum_limit, tno_cards_to_draw, tno_cards_drawn, i, candidate_sum);
            }
            else
            {
                if ((candidate_sum <= sum_limit) &&
                    ((max_sum == null) || (candidate_sum > max_sum)))
                {
                    max_sum = candidate_sum;
                }
            }

            candidate_sum -= card;
            --tno_cards_drawn;
        }
    }
}