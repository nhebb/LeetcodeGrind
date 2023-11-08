namespace LeetcodeGrind.Solutions;

// 299. Bulls and Cows
public class P0299
{
    public string GetHint(string secret, string guess)
    {
        var bulls = 0;
        var cows = 0;

        // dicts contain only unmatched characters
        var secretChars = new Dictionary<char, int>();
        var guessChars = new Dictionary<char, int>();

        for (int i = 0; i < secret.Length; i++)
        {
            if (secret[i] == guess[i])
            {
                bulls++;
            }
            else
            {
                if (secretChars.TryGetValue(secret[i], out var secretVal))
                    secretChars[secret[i]] = secretVal + 1;
                else
                    secretChars[secret[i]] = 1;

                if (guessChars.TryGetValue(guess[i], out var guessVal))
                    guessChars[guess[i]] = guessVal + 1;
                else
                    guessChars[guess[i]] = 1;
            }
        }

        foreach (var secretKV in secretChars)
        {
            if (guessChars.ContainsKey(secretKV.Key))
            {
                if (guessChars[secretKV.Key] >= secretKV.Value)
                    cows += secretKV.Value;
                else
                    cows += guessChars[secretKV.Key];
            }
        }

        return $"{bulls}A{cows}B";
    }
}
