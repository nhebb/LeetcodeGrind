namespace LeetcodeGrind.Trees.NAry;


public partial class Solution
{
    // Note: Changed class name from Node to NAryNode to
    // avoid naming conflicts with other specialized node classes
    public class NAryNode
    {
        public int val;
        public IList<NAryNode> children;

        public NAryNode() { }

        public NAryNode(int val) => this.val = val;

        public NAryNode(int val, IList<NAryNode> children)
        {
            this.val = val;
            this.children = children;
        }
    }
}
