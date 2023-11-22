namespace LeetcodeGrind.Solutions;

// 2299. Strong Password Checker II
public class P2299
{
    public bool StrongPasswordCheckerII(string password)
    {
        if (password.Length < 8)
            return false;

        var special = "!@#$%^&*()-+".ToHashSet();
        var hasDigit = false;
        var hasLower = false;
        var hasUpper = false;
        var hasSpecial = false;

        if (special.Contains(password[0]))
            hasSpecial = true;
        if (char.IsDigit(password[0]))
            hasDigit = true;
        if (char.IsLower(password[0]))
            hasLower = true;
        if (char.IsUpper(password[0]))
            hasUpper = true;

        for (int i = 1; i < password.Length; i++)
        {
            if (password[i] == password[i - 1])
                return false;

            if (special.Contains(password[i]))
                hasSpecial = true;
            if (char.IsDigit(password[i]))
                hasDigit = true;
            if (char.IsLower(password[i]))
                hasLower = true;
            if (char.IsUpper(password[i]))
                hasUpper = true;
        }

        return hasDigit && hasLower && hasUpper && hasSpecial;
    }
}
