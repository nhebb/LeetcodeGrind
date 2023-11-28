namespace LeetcodeGrind.Solutions;

// 925. Long Pressed Name
public class P0925
{
    public bool IsLongPressedName(string name, string typed)
    {
        if (name[0] != typed[0] || typed.Length < name.Length)
            return false;

        var i = 1;
        var j = 1;

        while (i < name.Length && j < typed.Length)
        {
            if (name[i] == typed[j])
            {
                i++;
                j++;
            }
            else if (name[i] != typed[j] && typed[j] == typed[j - 1])
            {
                j++;
                if (j == typed.Length)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        while (j < typed.Length && name[^1] == typed[j])
        {
            j++;
        }

        return i == name.Length && j == typed.Length;
    }
}
