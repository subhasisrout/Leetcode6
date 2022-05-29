namespace Leetcode6
{
    public class SenderWithLargestWordCountLC2284
    {
        public string LargestWordCount(string[] messages, string[] senders)
        {
            Dictionary<string, (int, int)> dict = new Dictionary<string, (int, int)>();
            int n = senders.Length;
            for (int i = 0; i < n; i++)
            {
                string sender = senders[i];
                string message = messages[i];
                if (!dict.ContainsKey(sender))
                    dict.Add(sender, (GetWordCount(message), GetWordASCII(sender)));
                else
                {
                    int currCount = dict[sender].Item1;
                    int senderASCII = dict[sender].Item2;
                    dict[sender] = (currCount + GetWordCount(message), senderASCII);
                }
            }

            List<KeyValuePair<string, (int, int)>> list = dict.ToList(); //#dotnetsortdictbyvalue
            list.Sort(new CustomComparer()); //#dotnetsort
            return list[0].Key;
        }
        int GetWordASCII(string word)
        {
            int total = 0;
            for (int i = 0; i < word.Length; i++)
            {
                total += (int)word[i]; //#dotnetascii
            }
            return total;
        }
        int GetWordCount(string sentence)
        {
            return sentence.Split(new char[] { ' ' }).Length;
        }
        class CustomComparer : IComparer<KeyValuePair<string, (int, int)>> //#dotnetcustomcomparer
        {
            int GetWordASCII(string word)
            {
                int total = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    total += (int)word[i];
                }
                return total;
            }
            public int Compare(KeyValuePair<string, (int, int)> x, KeyValuePair<string, (int, int)> y)
            {
                if (x.Value.Item2 != y.Value.Item2)
                    return y.Value.Item2.CompareTo(x.Value.Item1);
                else
                    return GetWordASCII(y.Key).CompareTo(GetWordASCII(x.Key));
            }
        }
    }


}

