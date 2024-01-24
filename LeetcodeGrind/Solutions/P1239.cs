namespace LeetcodeGrind.Solutions;

// 1239. Maximum Length of a Concatenated String with Unique Characters
public class P1239
{
    public int MaxLength(IList<string> arr)
    {
        var chars = new HashSet<char>(26);
        var max = 0;

        void BackTrack(int i, int len)
        {
            for (int j = i; j < arr.Count; j++)
            {
                var unique = true;
                for (int k = 0; k < arr[j].Length; k++)
                {
                    if (!chars.Add(arr[j][k]))
                    {
                        unique = false;
                        k--;
                        while (k >= 0)
                        {
                            chars.Remove(arr[j][k]);
                            k--;
                        }
                        break;
                    }
                }

                if (!unique)
                {
                    continue;
                }

                len += arr[j].Length;
                max = Math.Max(max, len);

                BackTrack(j + 1, len);

                len -= arr[j].Length;

                for (int k = 0; k < arr[j].Length; k++)
                {
                    chars.Remove(arr[j][k]);
                }
            }
        }

        BackTrack(0, 0);

        return max;
    }
}
