#include <stdc++.h>

using namespace std;

struct TreeNode {
    int val;
    TreeNode *left;
    TreeNode *right;
    TreeNode(int x) : val(x), left(NULL), right(NULL) {}
};

// 递归遍历二叉树，如果x节点的子树中包含p节点和q节点
class Solution1 {
public:
    TreeNode* lowestCommonAncestor(TreeNode* root, TreeNode* p, TreeNode* q) {
        DFS(root, p, q);
        return ans;
    }
protected:
    TreeNode* ans;
private:
    bool DFS(TreeNode* root, TreeNode* p, TreeNode* q){
        if (!root)
            return false;

        bool leftChild = DFS(root->left, p, q);
        bool rightChild = DFS(root->right, p, q);
        if ((leftChild && rightChild) || ((root->val == p->val || root->val == q->val) &&
        (leftChild || rightChild)))
            ans = root;

        return leftChild || rightChild || (root->val == p->val || root->val == q->val);
    }
};

// 哈希表存储父节点,根节点开始遍历整棵二叉树，用哈希表记录每个节点的父节点指针
// 从 p 节点开始不断往它的祖先移动，并用数据结构记录已经访问过的祖先节点。
// 我们再从q节点开始不断往它的祖先移动，如果有祖先已经被访问过，即是p和q的深度最深的公共祖先，
class Solution2 {
public:
    TreeNode* lowestCommonAncestor(TreeNode* root, TreeNode* p, TreeNode* q) {
        ancestor[root->val] = nullptr;
        DFS(root);

        while (p){
            visited[p->val] = true;
            p = ancestor[p->val];
        }
        while (q)
        {
            if (visited[q->val])
                return q;
            q = ancestor[q->val];
        }
        return nullptr;
    }
protected:
    unordered_map<int, TreeNode*> ancestor;
    unordered_map<int, bool> visited;
private:
    void DFS(TreeNode* root){
        if (root->left){
            ancestor[root->left->val] = root;
            DFS(root->left);
        }
        if (root->right){
            ancestor[root->right->val] = root;
            DFS(root->right);
        }
    }
};

// 后序遍历
class Solution {
public:
    TreeNode* lowestCommonAncestor(TreeNode* root, TreeNode* p, TreeNode* q) {
        if (root == nullptr || root == q || root == p)
            return root;

        TreeNode* left = lowestCommonAncestor(root->left, p, q);
        TreeNode* right = lowestCommonAncestor(root->right, p, q);
        if (left && right)
            return root;
        return left ? left : right;
    }
};