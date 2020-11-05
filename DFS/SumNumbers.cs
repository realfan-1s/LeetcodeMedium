using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Collections;
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

// 回溯算法
public class Solution {
    public static int path = 0;
    public int SumNumbers(TreeNode root) {
        if (root is null)
            return 0;

        if (root.left is null && root.right is null)
            return path * 10 + root.val;

        path = path * 10 + root.val;
        int res = SumNumbers(root.left) + SumNumbers(root.right);
        path /= 10;

        return res;
    }
}

// 栈
public class solution{
    int sum;
    Stack<int> path = new Stack<int>();

    public int SumNumbers(TreeNode root){
        dfs(root);
        return sum;
    }

    void dfs(TreeNode root){
        if (root is null)
            return;

        path.Push(root.val);
        if (root.left is null && root.right is null)
        {
            var arr = path.ToArray();
            var t = 0;
            for (int i = 0; i < arr.Length; i++)
                t += arr[i] * (int)Math.Pow(10, i);

            sum += t;
        }

        dfs(root.left);
        dfs(root.right);
        path.Pop();
    }
}