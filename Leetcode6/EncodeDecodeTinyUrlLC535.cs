using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #SystemDesign
// Idea taken from https://leetcode.com/discuss/interview-question/124658/Design-a-URL-Shortener-(-TinyURL-)-System/
// #RememberPattern

namespace Leetcode
{
    public class EncodeDecodeTinyUrlLC535
    {
        Dictionary<int, KeyValuePair<string,string>> idShortUrlMap = new Dictionary<int, KeyValuePair<string,string>>();
        public string encode(string longUrl)
        {
            int mapCount = idShortUrlMap.Count;
            string shortUrl = IdToShortUrl(mapCount+1);
            idShortUrlMap.Add(mapCount, new KeyValuePair<string, string>(shortUrl,longUrl));
            return shortUrl;

        }

        public string decode(string shortUrl)
        {
            int id = ShortUrlToId(shortUrl);
            return idShortUrlMap[id].Value;
        }

        private int ShortUrlToId(string shortUrl)
        {
            int id = 0;
            // Explanation - 62 is the base (i.e number of possible characters)
            // +26 and +52 is done so that 'a' should NOT BE EQUAL 'A' which in turn is not equal to '0'
            for (int i = 0; i < shortUrl.Length; i++)
            {
                if (shortUrl[i] >= 'a' && shortUrl[i] <= 'z')
                    id = id * 62 + shortUrl[i] - 'a';
                if (shortUrl[i] >= 'A' && shortUrl[i] <= 'Z')
                    id = id * 62 + shortUrl[i] - 'A' + 26;
                if (shortUrl[i] >= '0' && shortUrl[i] <= '9')
                    id = id * 62 + shortUrl[i] - '0' + 52;
            }
            return id;
        }

        private string IdToShortUrl(int n)
        {
            // Map to store 62 possible characters
            char[] map = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

            StringBuilder shortUrl = new StringBuilder();

            while (n > 0)
            {
                shortUrl.Append(map[n % 62]);
                n = n / 62;
            }

            return new string(shortUrl.ToString().Reverse().ToArray());
        }
    }
}
