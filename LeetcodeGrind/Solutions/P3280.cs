namespace LeetcodeGrind.Solutions;

// TODO: Submit on lazy day
// 3280. Convert Date to Binary
public class P3280
{
    public string ConvertDateToBinary(string date)
    {
        var dateParts = date.Split('-');
        for (int i = 0; i < dateParts.Length; i++)
        {
            var value = int.Parse(dateParts[i]);
            dateParts[i] = Convert.ToString(value, 2);
        }

        return string.Join("-", dateParts);
    }
}
