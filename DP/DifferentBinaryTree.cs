using System.Collections.Generic;
// 获得不同的二叉搜索树数量
public class Solution {
    public int NumTrees(int n) {
        // dp枚举的是长度
        int[] dp = new int[n + 1];
        dp[0] = 1;
        dp[1] = 1;

        //i 用以枚举长度， j用以枚举第j个数的位置
        for (int i = 2; i < n + 1; i++)
            for (int j = 1; j < i + 1; j++)
                dp[i] += dp[j - 1] * dp[i - j];

        return dp[n];
    }
}

public class Solution2 {
    public int NumTrees(int n) {
        long c = 1;
        for (int i = 0; i < n; i++)
            c = c * 2 * (2 * n + 1) / (n + 2);

        return c;
    }
}

// 获取所有不同的二叉搜索树
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution {
    public IList<TreeNode> GenerateTrees(int n) {
        // 二叉搜索树的特性是根节点左子节点的值都小于根节点的值，右子节点的值都大于根节点的值
        if (n == 0)
            return list = new List<TreeNode>();

        return GetNum(1, n);
    }

    private List<TreeNode> GetNum(int start, int end)
    {
        List<TreeNode> list = new List<TreeNode>();
        if (start > end)
        {
            list.Add(null);
            return list;
        }

        for (int i = start; i < end + 1; i++)
        {
            // 从左子树集合中选出一棵左子树，从右子树集合中选出一棵右子树，拼接到根节点上
            List<TreeNode> left = GetNum(start, i - 1);
            List<TreeNode> right = GetNum(i + 1, end);
            foreach (var leftNode in left)
                foreach (var rightNode in right)
                {
                    TreeNode node = new TreeNode(i);
                    node.left = leftNode;
                    node.right = rightNode;
                    list.Add(node);
                }
            
        }
        return list;
    }
}