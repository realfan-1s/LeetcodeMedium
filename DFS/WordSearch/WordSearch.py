class Solution:
    def exist(self, board: list[list[str]], word: str) -> bool:
        col = len(board)
        row = len(board[0])

        directions = [(0, 1), (0, -1), (1, 0), (-1, 0)]

        def dfs(i, j, u):
            if board[i][j] != word[u]:
                return False
            if u == len(word) - 1:
                return True

            board[i][j] = "."

            for direction in directions:
                x = i + direction[0]
                y = j + direction[1]
                if 0 <= x < col and 0 <= y < row:
                    if dfs(x, y, u + 1):
                        return True

            board[i][j] = word[u]
            return False

        for i in range(col):
            for j in range(row):
                if dfs(i, j, 0):
                    return True

        return False