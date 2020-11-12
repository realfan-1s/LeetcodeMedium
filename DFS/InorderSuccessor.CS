public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode (int x) { val = x; }
}

public class Solution {
    public TreeNode InorderSuccessor (TreeNode root, TreeNode p) {
        if (root == null || p == null)
            return null;
        // 按照中序遍历的顺序对所有节点进行遍历
        TreeNode tmp = InorderSuccessor (root.left, p);
        if (tmp != null)
            return tmp;
        if (root.val > p.val)
            return root;
        return InorderSuccessor (root.right, p);
    }
}