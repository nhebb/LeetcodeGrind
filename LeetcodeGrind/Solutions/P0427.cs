namespace LeetcodeGrind.QuadTree;

// 427. Construct Quad Tree
public class QuadTree
{
    public Node Construct(int[][] grid)
    {
        Node BuildTree(int r, int c, int n)
        {
            var val = grid[r][c] == 1;
            if (n == 1)
                return new Node(val, true);

            // split into quadrants and recursively build tree
            n /= 2;
            var tl = BuildTree(r, c, n);            // top left
            var tr = BuildTree(r, c + n, n);        // top right
            var bl = BuildTree(r + n, c, n);        // bottom left
            var br = BuildTree(r + n, c + n, n);    // bottom right

            // check if all 4 corners have the same value and are leaves
            var isLeaf = tl.val == tr.val && tr.val == bl.val && bl.val == br.val
                && tl.isLeaf && tr.isLeaf && bl.isLeaf && br.isLeaf;

            return isLeaf
                ? new Node(val, isLeaf)
                : new Node(val, isLeaf, tl, tr, bl, br);
        }

        return BuildTree(0, 0, grid.Length);
    }
}

// Definition for a QuadTree node.
public class Node
{
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node()
    {
        val = false;
        isLeaf = false;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }

    public Node(bool _val, bool _isLeaf)
    {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }

    public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
    {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
    }
}
