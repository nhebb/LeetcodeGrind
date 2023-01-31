using System.ComponentModel.Design;

namespace LeetcodeGrind;

internal class Program
{
    static void Main(string[] args)
    {
        // []
        var board = new char[4][];
        board[0] = new char[4] { 'o', 'a', 'a', 'n' };
        board[1] = new char[4] { 'e', 't', 'a', 'e' };
        board[2] = new char[4] { 'i', 'h', 'k', 'r' };
        board[3] = new char[4] { 'i', 'f', 'l', 'v' };

        var words = new string[] { "oath", "pea", "eat", "rain" };
        var tries = new Tries.Tries();
        var res = tries.FindWords(board, words);
        Console.WriteLine(string.Join(", ", res));
    }
}