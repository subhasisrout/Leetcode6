namespace Leetcode6
{
    public class BadgeUsageDeliveroo
    {
        public List<string> GetBadgeExitingWithoutEntry(string[][] badges)
        {
            HashSet<string> badgesExitingWithoutEntry = new HashSet<string>();
            Dictionary<string, string> map = new Dictionary<string, string>();
            for (int i = 0; i < badges.Length; i++)
            {
                var currBadge = badges[i];
                if (currBadge[1] == "exit")
                {
                    if (map.ContainsKey(currBadge[0]) && map[currBadge[0]] == "enter")
                    {
                        //valid case. exit will cancel the entry.
                        map.Remove(currBadge[0]);
                    }
                    else
                    {
                        badgesExitingWithoutEntry.Add(currBadge[0]);
                    }
                }
                else // ENTER
                {
                    if (!map.ContainsKey(currBadge[0]))
                        map.Add(currBadge[0], currBadge[1]);
                    else
                        map[currBadge[0]] = currBadge[1];
                }
            }
            return badgesExitingWithoutEntry.ToList();
        }
    }
}
