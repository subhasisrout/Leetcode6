using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class UniqueEmailAddressLC929
    {
        public int NumUniqueEmails(string[] emails)
        {

            HashSet<string> hashSet = new HashSet<string>();

            for (int i = 0; i < emails.Length; i++)
            {
                string email = emails[i];
                string localName = email.Split(new char[] { '@' })[0];
                string domainName = email.Split(new char[] { '@' })[1];
                if (localName.IndexOf('+') != -1)
                    localName = localName.Substring(0, localName.IndexOf('+'));
                localName = localName.Replace(".", "");

                hashSet.Add(string.Concat(localName, "@", domainName));
            }
            return hashSet.Count;

                //Dictionary<string, HashSet<string>> map = new Dictionary<string, HashSet<string>>();
                //int count = 0;

                //for (int i = 0; i < emails.Length; i++)
                //{
                //    string email = emails[i];
                //    string localName = email.Split(new char[] { '@' })[0];
                //    string domainName = email.Split(new char[] { '@' })[1];
                //    if (localName.IndexOf('+') != -1)
                //        localName = localName.Substring(0, localName.IndexOf('+'));
                //    localName = localName.Replace(".", "");
                //    if (map.ContainsKey(domainName))
                //        map[domainName].Add(localName);
                //    else
                //    {
                //        map.Add(domainName, new HashSet<string>());
                //        map[domainName].Add(localName);
                //    }
                //}

                //foreach (var item in map)
                //{
                //    count += item.Value.Count;
                //}
                //return count;
            }
    }
}
