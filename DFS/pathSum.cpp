#include <stdc++.h>

using namespace std;

struct TreeNode {
    int val;
    TreeNode *left;
    TreeNode *right;
    TreeNode(int x) : val(x), left(NULL), right(NULL) {}
};

// 路径不一定非得从二叉树的根节点或叶节点开始或结束，但是其方向必须向下(只能从父节点指向子节点方向)。
class Solution {
public:
    int ans = 0;
    int* spaces;
    int pathSum(TreeNode* root, int sum) {
        int dep = Depth(root);
        spaces = new int[dep];
        DFS(root, sum, 0);
    }

    void DFS(TreeNode* root, int tar, int index){
        if (root == nullptr)
            return;
        spaces[index] = root->val;
        int tmp = 0;
        for (int i = index; i > -1; --i){
            tmp += spaces[index];
            if (tmp == tar)
                ans++;
        }
        DFS(root->left, tar, index + 1);
        DFS(root->right, tar ,index + 1);
    }

    int Depth(TreeNode* root){
        if (root == nullptr)
            return 0;
        return max(Depth(root->left), Depth(root->right)) + 1;
    }
};