class Solution:
    def exist(self, board: list[list[str]], word: str):
        if not board:
            return False
        for i in range(len(board)):
            for j in range(len(board[0])):
                if self.dfs(board, word, i, j):
                    return True

        return False

    def dfs(self, board, word, i, j):
        if len(word) == 0:
            return True
        if i < 0 or j < 0 or i >= len(board) or j >= len(
                board[0]) or board[i][j] != word[0]:
            return False
        tmp = board[i][j]
        board[i][j] = '0'
        res = self.dfs(board, word[1:], i - 1,
                       j) or self.dfs(board, word[1:], i + 1, j) or self.dfs(
                           board, word[1:], i, j - 1) or self.dfs(
                               board, word[1:], i, j + 1)
        board[i][j] = tmp

        return res