class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None


# DFS+递归+递减
class Solution:
    def pathSum(self, root: TreeNode, sum: int):
        res, path = [], []

        def Recur(root: TreeNode, target: int):
            if not root:
                return
            path.append(root.val)
            target -= root.val
            if target == 0 and not root.left and not root.right:
                res.append(list(path))
            Recur(root.left, target)
            Recur(root.right, target)
            path.pop()

        Recur(root, sum)
        return res
