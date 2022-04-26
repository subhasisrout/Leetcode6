// Inspired from https://leetcode.com/problems/design-underground-system/discuss/554879/C%2B%2BJavaPython-HashMap-and-Pair-Clean-and-Concise-O(1)
// #Dictionary .Remove #String_String key

namespace Leetcode6
{
    public class DesignUndergroundSystemLC1396
    {
        public class UndergroundSystem
        {
            Dictionary<int, KeyValuePair<string, int>> checkinMap = null; // id -- station,time
            Dictionary<string, KeyValuePair<double, int>> routeMap = null;// route -- totalTime, count

            public UndergroundSystem()
            {
                checkinMap = new Dictionary<int, KeyValuePair<string, int>>();
                routeMap = new Dictionary<string, KeyValuePair<double, int>>();
            }

            public void CheckIn(int id, string stationName, int t)
            {
                checkinMap.Add(id, new KeyValuePair<string, int>(stationName, t));
            }

            public void CheckOut(int id, string stationName, int t)
            {
                var checkinData = checkinMap[id];
                var checkinStation = checkinData.Key;
                var checkinTime = checkinData.Value;
                checkinMap.Remove(id);

                string route = checkinStation + "_" + stationName;
                double timeTaken = (t - checkinTime) * 1.0;

                if (!routeMap.ContainsKey(route))
                    routeMap.Add(route, new KeyValuePair<double, int>(timeTaken, 1));
                else
                {
                    var routeTimeSoFar = routeMap[route].Key;
                    var routeCountSoFar = routeMap[route].Value;
                    routeMap[route] = new KeyValuePair<double, int>(timeTaken + routeTimeSoFar, routeCountSoFar + 1);
                }

            }

            public double GetAverageTime(string startStation, string endStation)
            {
                string key = startStation + "_" + endStation;
                double totalTime = routeMap[key].Key;
                int count = routeMap[key].Value;
                return totalTime / count;
            }
        }
    }
}
