using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Solutions;

// 3136. Valid Word
public class P3136
{
    // HashSets solution
    public bool IsValid(string word)
    {
        if (word.Length < 3)
            return false;

        word = word.ToLower();
        var vowels = "aeiou".ToHashSet();
        var consonants = "bcdfghjklmnpqrstvwxyz".ToHashSet();
        var allowed = "abcdefghijklmnopqrstuvwxyz0123456789".ToHashSet();

        var hasVowel = false;
        var hasConsonant = false;

        foreach (var c in word)
        {
            if (!allowed.Contains(c))
                return false;
            hasVowel |= vowels.Contains(c);
            hasConsonant |= consonants.Contains(c);
        }

        return hasVowel && hasConsonant;
    }
}
