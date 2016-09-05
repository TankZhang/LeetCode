using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/restore-ip-addresses/
namespace _93RestoreIPAddresses
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "25525511135";
            IList<string> sL = RestoreIpAddresses2(s);
            foreach (string item in sL)
                Console.WriteLine(item);
            Console.ReadKey();
        }

        static IList<string> RestoreIpAddresses(string s)
        {
            List<string> res = new List<string>();
            if (s.Length < 4 || s.Length > 12)
                return res;
            int n = s.Length;
            List<List<int>> iL = new List<List<int>>();
            for (int i1 = 1; i1 < 4; i1++)
                for (int i2 = 1; i2 < 4; i2++)
                    for (int i3 = 1; i3 < 4; i3++)
                        for (int i4 = 1; i4 < 4; i4++)
                            if (i1 + i2 + i3 + i4 == n)
                                iL.Add(new List<int> { i1, i2, i3, i4 });
            for (int k = 0; k < iL.Count; k++)
            {
                int a = Convert.ToInt32(s.Substring(0, iL[k][0]));
                int b = Convert.ToInt32(s.Substring(iL[k][0], iL[k][1]));
                int c = Convert.ToInt32(s.Substring(iL[k][0] + iL[k][1], iL[k][2]));
                int d = Convert.ToInt32(s.Substring(iL[k][0] + iL[k][1] + iL[k][2], iL[k][3]));
                string sTemp = string.Format("{0}{1}{2}{3}", a, b, c, d);
                if (a < 256 && b < 256 && c < 256 && d < 256 && sTemp == s)
                    res.Add(string.Format("{0}.{1}.{2}.{3}",a,b,c,d));
            }
            return res;
        }

        #region 其他版本
        static IList<string> RestoreIpAddresses1(string s)
        {
            List<string> res = new List<string>();
            List<string> ips = new List<string>();

            Find(res, ips, s, 0);
            return res;
        }

        static void Find(IList<string> res, IList<string> ips, string s, int start)
        {
            if (ips.Count == 4 && start == s.Length)
            {
                res.Add(string.Join(".", ips));
                return;
            }

            if (s.Length - start > (4 - ips.Count) * 3) // pruning if right side contains more characters than needed
            {
                return;
            }

            for (int i = start; i < start + 4 && i < s.Length; i++)
            {
                string ip = s.Substring(start, i - start + 1);
                if (int.Parse(ip) > 255 || int.Parse(ip).ToString() != ip) // prevent digit larger or starts with 0
                {
                    return;
                }

                ips.Add(ip);
                Find(res, ips, s, i + 1);
                ips.RemoveAt(ips.Count - 1);
            }
        }
        #endregion

        static IList<string> RestoreIpAddresses2(string s)
        {
            List<string> res = new List<string>();
            List<string> ips = new List<string>();
            Find1(res, ips, s, 0);
            return res;
        }

        static void Find1(List<string> res, List<string> ips, string s, int start)
        {
            if(ips.Count==4&&start==s.Length)
            {
                res.Add(string.Join(".", ips));
                return;
            }
            for (int i = start; i < s.Length && i < start + 4; i++)
            {
                string ip = s.Substring(start, i - start + 1);
                if(int.Parse(ip)>255||int.Parse(ip).ToString()!=ip)
                 return;
                ips.Add(ip);
                Find1(res, ips, s, i+1);
                ips.RemoveAt(ips.Count-1);
            }
        }
    }
}

