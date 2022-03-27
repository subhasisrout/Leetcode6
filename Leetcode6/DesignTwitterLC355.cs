using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode
{
    public class DesignTwitterLC355
    {
        private Dictionary<int, HashSet<int>> followerMap;
        private Dictionary<int, List<Tweet>> tweetMapForUser;


        /** Initialize your data structure here. */
        public DesignTwitterLC355()
        {
            tweetMapForUser = new Dictionary<int, List<Tweet>>();
            followerMap = new Dictionary<int, HashSet<int>>();
        }

        /** Compose a new tweet. */
        public void PostTweet(int userId, int tweetId)
        {
            if (tweetMapForUser.ContainsKey(userId))
                tweetMapForUser[userId].Add(new Tweet() { TweetId = tweetId, TweetTime = DateTime.UtcNow });
            else
                tweetMapForUser.Add(userId, new List<Tweet>() { new Tweet() { TweetId = tweetId, TweetTime = DateTime.UtcNow } });
        }

        /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
        public IList<int> GetNewsFeed(int userId)
        {
            HashSet<int> followedUsersAndSelf = new HashSet<int>();
            if (followerMap.ContainsKey(userId))
                followedUsersAndSelf = followerMap[userId];
            followedUsersAndSelf.Add(userId); // Adding self
            List<Tweet> allTweets = new List<Tweet>();
            foreach (var user in followedUsersAndSelf)
            {
                if (tweetMapForUser.ContainsKey(user))
                    allTweets.AddRange(tweetMapForUser[user]);
            }
            allTweets.Sort((a, b) => (b.TweetTime.CompareTo(a.TweetTime)));
            var reducedTweets = allTweets.Take(10);
            return reducedTweets.Select(x => x.TweetId).ToList();
        }

        /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
        public void Follow(int followerId, int followeeId)
        {
            if (followerMap.ContainsKey(followerId))
                followerMap[followerId].Add(followeeId);
            else
                followerMap.Add(followerId, new HashSet<int>() { followeeId });

        }

        /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
        public void Unfollow(int followerId, int followeeId)
        {
            if (followerMap.ContainsKey(followerId) && followerMap[followerId].Contains(followeeId))
                followerMap[followerId].Remove(followeeId);
        }
    }

    public class Tweet
    {
        public int TweetId { get; set; }
        public DateTime TweetTime { get; set; }
    }

    /**
     * Your Twitter object will be instantiated and called as such:
     * Twitter obj = new Twitter();
     * obj.PostTweet(userId,tweetId);
     * IList<int> param_2 = obj.GetNewsFeed(userId);
     * obj.Follow(followerId,followeeId);
     * obj.Unfollow(followerId,followeeId);
     */
}
