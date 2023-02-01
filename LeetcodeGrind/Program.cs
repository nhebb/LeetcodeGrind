using System.ComponentModel.Design;

namespace LeetcodeGrind;

internal class Program
{
    static void Main(string[] args)
    {
        //var board = new char[4][];
        //board[0] = new char[4] { 'o', 'a', 'a', 'n' };
        //board[1] = new char[4] { 'e', 't', 'a', 'e' };
        //board[2] = new char[4] { 'i', 'h', 'k', 'r' };
        //board[3] = new char[4] { 'i', 'f', 'l', 'v' };

        var tasks = new string[] { "A", "B", "C", "A", "A", "B", "A" };
        var pq = new PriorityQueue<(string, int),int> ();

        foreach (var task in tasks.GroupBy(x => x)
                      .Select(group => new
                      {
                          Val = group.Key,
                          Count = group.Count()
                      }))
        {
            pq.Enqueue((task.Val, task.Count), -task.Count);
        }


        //var tries = new Tries.Tries();
        //var res = tries.FindWords(board, words);
        //Console.WriteLine(string.Join(", ", res));
        //var sentence = "(((((*(()((((*((**(((()()*)()()()*((((**)())*)*)))))))(())(()))())((*()()(((()((()*(())*(()**)()(())";
        //var g = new Greedy.Greedy();
        //var res = g.CheckValidString(sentence);
    }
}