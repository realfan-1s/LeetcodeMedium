public class Solution {
    int len;
    bool[] visited;
    public int FindCircleNum (int[][] M) {
        len = M.Length;
        visited = new bool[len];

        int res = 0;
        for (int i = 0; i < len; i++)
            if (!visited[i]) {
                DFS (M, i);
                res++;
            }

        return res;
    }

    private void DFS (int[][] M, int i) {
        for (int j = 0; j < len; j++)
            if (M[i][j] == 1 && !visited[j]) {
                visited[j] = true;
                DFS (M, j);
            }
    }
}