namespace LeetcodeGrind.Solutions
{
    // 3019. Number of Changing Keys
    public class P3019
    {
        public int CountKeyChanges(string s)
        {
            s = s.ToLower();
            var count = 0;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] != s[i - 1])
                {
                    count++;
                }
            }
            return count;
        }
    }
}
