public class Solution {
    public int IslandPerimeter(int[][] grid) {
        col = grid.Length;
        row = grid[0].Length;
        List<Tuple<int, int>> direction = new List<tuple<int, int>> (){(1, 0), (-1, 0), (0, 1), (0, -1)};
        int res = 0;

        for (int i = 0; i < col;)
            for (int j = 0; j < row;)
            {
                if (grid[i][j] == 1)
                {
                    foreach (var dir in direction)
                    {
                        int x = i + dir.Item1;
                        int y = j + dir.Item2;
                        if (x < 0 || x >= col || y < 0 || y >= row || grid[x][y] == 0)
                            res++;
                        i = x;
                        j = y;
                    }
                }
                else{
                    i++;
                    j++;
                }
            }

        return res;
    }
}