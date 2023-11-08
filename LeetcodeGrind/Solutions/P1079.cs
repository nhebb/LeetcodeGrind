using System.Text;

namespace LeetcodeGrind.Solutions;

// 1079. Letter Tile Possibilities
public class P1079
{
    public int NumTilePossibilities(string tiles)
    {
        var visited = new bool[tiles.Length];
        var hs = new HashSet<string>();
        var sb = new StringBuilder();

        void Backtrack(int index)
        {
            if (sb.Length > 0)
                hs.Add(sb.ToString());

            if (index == tiles.Length)
                return;

            for (int i = 0; i < tiles.Length; i++)
            {
                if (visited[i])
                    continue;

                visited[i] = true;
                sb.Append(tiles[i]);
                Backtrack(index + 1);
                sb.Length--;
                visited[i] = false;
            }
        }

        Backtrack(0);

        return hs.Count;
    }
}
