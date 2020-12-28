#include <stdc++.h>

using namespace std;

struct TreeNode {
    int val;
    TreeNode *left;
    TreeNode *right;
    TreeNode(int x) : val(x), left(NULL), right(NULL) {}
};

// 迭代法对二叉树进行前中后序遍历
class Solution1 {
public:
    vector<int> preorderTraversal(TreeNode* root) {
        vector<int> ans;

        stack<TreeNode*> stk;
        TreeNode* node = root;
        while (node || !stk.empty()){
            while (node){
                ans.emplace_back(node->val);
                stk.push(node);
                node = node->left;
            }
            node = stk.top();
            stk.pop();
            node = node->right;
        }
        return ans;
    }
};

class Solution2 {
public:
    vector<int> inorderTraversal(TreeNode* root) {
        vector<int> ans;
        stack<TreeNode*> stk;
        TreeNode* node = root;
        while (node || !stk.empty())
        {
            while (node){
                stk.push(node);
                node = node->left;
            }
            node = stk.top();
            stk.pop();
            ans.emplace_back(node->val);
            node = node->right;
        }

        return ans;
    }
};

class Solution3 {
public:
    vector<int> postorderTraversal(TreeNode* root) {
        vector<int> res;
        if (root == nullptr)
            return res;

        stack<TreeNode*> stk;
        TreeNode* prev;
        while (root != nullptr || !stk.empty()){
            while (root != nullptr){
                stk.emplace(root);
                root = root->left;
            }
            root = stk.top();
            stk.pop();
            if (root->right == nullptr || root->right == prev){
                res.emplace_back(root->val);
                prev = root;
                root = nullptr;
            } else {
                stk.emplace(root);
                root = root->right;
            }
        }

        return res;
    }
};

class Morris1{
/*
    新建临时节点，令此节点为root；
    若当前节点左子节点为空，加入答案并遍历右子节点
    如果当前节点的左子节点不为空，在当前节点的左子树中找到当前节点在中序遍历下的前驱节点：
        如果前驱节点的右子节点为空，将前驱节点的右子节点设置为当前节点。然后将当前节点加入答案，并将前驱节点的右子节点更新为当前节点。当前节点更新为当前节点的左子节点。
        如果前驱节点的右子节点为当前节点，将它的右子节点重新设为空。当前节点更新为当前节点的右子节点。
。
*/
public:
    vector<int> preorderTraversal(TreeNode* root) {
        vector<int> res;
        if (!root)
            return res;
        TreeNode* prev;
        TreeNode* prev2 = root;

        while (prev2){
            if (prev2->left){
                prev = prev2->left;
                while (prev->right && prev->right != prev2)
                    prev = prev->right;

                if (!prev->right){
                    prev->right = prev2;
                    res.push_back(prev2->val);
                    prev2 = prev2->left;
                    continue;
                } else
                    prev->right = nullptr;
            } else
                res.emplace_back(prev2->val);
            prev2 = prev2->right;
        }

        return res;
    }
};

class Morris2{
    /*
    如果x无左孩子，先将 x 的值加入答案数组，再访问 xx 的右孩子，即 x = x.right
    如果x有左孩子，则找到x左子树上最右的节点，我们记为prev。根据prev的右孩子是否为空，进行如下操作。如果prev的右孩子为空，则将其右孩子指向x，然后访问x的左孩子，即 x = x.left。
    如果prev的右孩子不为空，则此时其右孩子指向 x，说明我们已经遍历完x的左子树，prev的右孩子置空，将 x 的值加入答案数组，然后访问 x 的右孩子，即 x = x.right。
    */
public:
    vector<int> inorderTraversal(TreeNode* root) {
        vector<int> res;
        TreeNode* prev = nullptr;
        TreeNode* prev2 = root;

        while (prev2){
            if (prev2 -> left){
                prev = prev2->left;
                while (prev->right && prev->right != prev2)
                    prev = prev->right;

                if (!prev->right){
                    prev->right = root;
                    prev2 = prev2->left;
                // 说明我们已经遍历完x的左子树
                } else {
                    res.push_back(prev2->val);
                    prev->right = nullptr;
                    prev2 = prev2->right;
                }
            } else {
                res.push_back(prev2->val);
                prev2 = prev2->right;
            }
        }
        return res;
    }
};

class Morris3{
public:
    vector<int> postorderTraversal(TreeNode* root) {
        vector<int> res;
        if (!root)
            return res;
        TreeNode* prev;
        TreeNode* prev2 = root;

        while (prev2){
            if (prev2->left){
                prev = prev2->left;
                while (prev->right && prev->right != prev2)
                    prev = prev->right;

                if (!prev->right){
                    prev->right = prev2;
                    prev2 = prev2->left;
                    continue;
                } else {
                    prev->right = nullptr;
                    addPath(res, prev2->left);
                }
            }
            prev2 = prev2->right;
        }

        addPath(res, root);
        return res;
    }
private:
    void addPath (vector<int>& ans, TreeNode* node){
        int count = 0;
        while (node) {
            ++count;
            ans.emplace_back(node->val);
            node = node->right;
        }

        reverse(ans.end() - count, ans.end());
    }
};
