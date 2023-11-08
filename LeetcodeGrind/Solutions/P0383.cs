namespace LeetcodeGrind.Solutions;

// 383. Ransom Note
public class P0383
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        var dm = new Dictionary<char, int>();
        for (int i = 0; i < magazine.Length; i++)
        {
            if (dm.TryGetValue(magazine[i], out int val))
                dm[magazine[i]] = val + 1;
            else
                dm[magazine[i]] = 1;
        }

        for (int i = 0; i < ransomNote.Length; i++)
        {
            if (dm.TryGetValue(ransomNote[i], out int val))
            {
                dm[ransomNote[i]] = val - 1;
                if (dm[ransomNote[i]] == 0)
                    dm.Remove(ransomNote[i]);
            }
            else
            {
                return false;
            }
        }
        return true;
    }
}
