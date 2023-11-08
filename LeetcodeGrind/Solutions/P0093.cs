namespace LeetcodeGrind.Solutions;

// 93. Restore IP Addresses
// 3 variants of the solution - I can't remember which performs best.
public class P0093
{
    public IList<string> RestoreIpAddresses(string s)
    {
        var ans = new List<string>();
        var ip = new int[4];
        var hs = new HashSet<string>();

        bool AddDigit(char c, int block)
        {
            if (ip[block] == -1)
            {
                ip[block] = c - '0';
                return true;
            }

            var newVal = ip[block] * 10 + c - '0';
            if (newVal <= 255)
            {
                ip[block] = newVal;
                return true;
            }

            return false;
        }

        void RemoveDigit(int block)
        {
            if (ip[block] >= 10)
                ip[block] /= 10;
            else
                ip[block] = -1;
        }


        void Backtrack(int i, int blockNum, int blockVal, int pos)
        {
            if (i >= s.Length) return;

            if (blockNum == 3)
            {
                if (pos == 2)
                {
                }
            }
        }

        Backtrack(0, 0, -1, 0);

        return ans;
    }

    public IList<string> RestoreIpAddresses2(string s)
    {
        var ans = new List<string>();
        var segments = new List<int>();

        if (s.Length > 12)
            return ans;

        void Backtrack(int i)
        {
            if (i == s.Length && segments.Count == 4)
            {
                string ip = string.Join(".", segments);
                ans.Add(ip);
                return;
            }
            else
            {
                for (int len = 1; len <= 3; len++)
                {
                    var num = int.Parse(s.Substring(i, len));
                    if (num >= 0 && num <= 255)
                    {
                        segments.Add(num);
                        Backtrack(len + i);
                        segments.RemoveAt(segments.Count - 1);
                    }
                }
            }
        }

        Backtrack(0);
        return ans;
    }

    public IList<string> RestoreIpAddresses3(string s)
    {
        var li = new List<string>();
        var ans = new List<string>();
        if (s.Length > 12)
            return ans;

        bool IsValid(string str)
        {
            if (str.Length > 3)
                return false;

            int num = int.Parse(str);

            if (num < 0 || num > 255 || str.Length != num.ToString().Length)
                return false;

            return true;
        }

        void Backtrack(int st)
        {
            if (st == s.Length && li.Count == 4)
            {
                string ip = string.Join(".", li);
                ans.Add(ip);
                return;
            }

            for (int len = 1; len <= s.Length - st; len++)
            {
                string str = s.Substring(st, len);

                if (IsValid(str))
                {
                    li.Add(str);
                    Backtrack(st + len);
                    li.RemoveAt(li.Count - 1);
                }
            }
        }

        Backtrack(0);
        return ans;
    }
}
