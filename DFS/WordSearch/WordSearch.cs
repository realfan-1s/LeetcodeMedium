public class Solution {
    public bool Exist(char[][] board, string word) {
        int col = board.Length;
        int row = board[0].Length;

        int[,] directions = new int[4,2] { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };

        bool dfs(int i, int j, int u)
        {
            if (board[i][j] == word[u])
                return false;
            if (u == word.Length - 1)
                return true;

            board[i][j] = ".";

            for (int k = 0; k < directions.GetLength(0); k++)
            {
                int x = i + direction[k, 0];
                int y = j + direction[k, 1];

                if (x >= 0 && x < col && y >= 0 && y < row)
                    if (dfs(x, y, u + 1))
                        return true;
            }

            board[i][j] = word[u];
            return false;
        }

        for (int i = 0; i < col; i++)
            for (int j = 0; j < row; j++)
            {
                if (dfs(i, j, 0))
                    return true;
            }

        return false;
    }
}