#include <stdc++.h>

using namespace std;

struct TreeNode {
    int val;
    TreeNode *left;
    TreeNode *right;
    TreeNode(int x) : val(x), left(NULL), right(NULL) {}
};

class Solution {
public:
    vector<vector<int>> zigzagLevelOrder(TreeNode* root) {
        queue<TreeNode*> queue;
        vector<vector<int>> ans;
        queue.push(root);
        int steps = 0;

        while (!queue.empty()){
            vector<int> res;
            int len = queue.size();
            while (len > 0){
                TreeNode* tmp = queue.front();
                queue.pop();

                if (tmp->left)
                    queue.push(tmp->left);
                if (tmp->right)
                    queue.push(tmp->right);

                if (steps % 2 == 1)
                    res.insert(res.begin(), tmp->val);
                else
                    res.push_back(tmp->val);

                --len;
            }
            ans.push_back(res);
            ++steps;
        }
        return ans;
    }
};