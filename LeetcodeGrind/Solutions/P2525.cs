namespace LeetcodeGrind.Solutions;

// 2525. Categorize Box According to Criteria
public class P2525
{
    public string CategorizeBox(int length, int width, int height, int mass)
    {
        var heavy = mass >= 100;

        var volume = ((long)width) * length * height;
        var bulky = width >= 10000 ||
                    height >= 10000 ||
                    length >= 10000 ||
                    volume >= 1_000_000_000;

        string cat;
        if (bulky && heavy)
            cat = "Both";
        else if (bulky)
            cat = "Bulky";
        else if (heavy)
            cat = "Heavy";
        else
            cat = "Neither";

        return cat;
    }
}
