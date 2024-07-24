using System.Text;

namespace LeetcodeGrind.Solutions;

// 2191. Sort the Jumbled Numbers
public class P2191
{
    private class MappedNumber
    {
        public int Order { get; set; }
        public int Number { get; set; }
        public int MappedValue { get; set; }

        public MappedNumber(int order, int number, int[] map)
        {
            Order = order;
            Number = number;
            SetMappedValue(map);
        }

        private void SetMappedValue(int[] map)
        {
            var s = Number.ToString();
            var sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                sb.Append(map[s[i] - '0']);
            }

            MappedValue = int.Parse(sb.ToString());
        }
    }

    public int[] SortJumbled(int[] mapping, int[] nums)
    {
        var values = new List<MappedNumber>();
        for (int i = 0; i < nums.Length; i++)
        {
            values.Add(new MappedNumber(i, nums[i], mapping));
        }

        return values.OrderBy(v => v.MappedValue)
                     .ThenBy(v => v.Order)
                     .Select(v => v.Number)
                     .ToArray();
    }
}
