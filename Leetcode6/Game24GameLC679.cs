// #Hard problem nicely explained by Cheng (HappyCoding) - https://www.youtube.com/watch?v=I_Ikfbeop8I
// Another pattern of #Backtracking, where you do not remove and add back. Rather create a new List.
namespace Leetcode6
{
    public class Game24GameLC679
    {
        public bool JudgePoint24(int[] cards)
        {
            IList<double> cardList = new List<double>();
            for (int i = 0; i < cards.Length; i++)
                cardList.Add(cards[i]);
            return dfsAndBacktrack(cardList);
        }
        private bool dfsAndBacktrack(IList<double> cards)
        {
            if (cards.Count == 1)
                if (Math.Abs(cards[0] - 24) < 0.0001)
                    return true;

            for (int i = 0; i < cards.Count; i++)
            {
                for (int j = i + 1; j < cards.Count; j++)
                {
                    double c1 = cards[i];
                    double c2 = cards[j];

                    List<double> possibilities = new List<double>() { c1 + c2, c1 - c2, c2 - c1, c1 * c2 };
                    if (c1 != 0) possibilities.Add(c2 / c1);
                    if (c2 != 0) possibilities.Add(c1 / c2);

                    foreach (var v in possibilities)
                    {
                        List<double> newList = new List<double>() { v };
                        for (int k = 0; k < cards.Count; k++)
                        {
                            if (k != i && k != j)
                                newList.Add(cards[k]);
                        }

                        if (dfsAndBacktrack(newList)) return true;
                    }
                }
            }
            return false;
        }
    }
}
