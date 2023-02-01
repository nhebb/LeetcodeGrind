using System.ComponentModel.Design;

namespace LeetcodeGrind;

internal class Program
{
    static void Main(string[] args)
    {
        var answerKey = "TF";
        var k = 1;
        var sw = new SlidingWindow.SlidingWindow();
        var res = sw.MaxConsecutiveAnswers(answerKey, k);
        Console.WriteLine(res);
    }
}