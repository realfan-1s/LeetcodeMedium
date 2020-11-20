class Solution():
    """
    DFS, 将每块“1”（岛屿）看做是一个独立的graph
    """
    def NumsOfIsland(self, grid: list[list[str]]):
        self.Directions = [(0, 1), (0, -1), (1, 0), (-1, 0)]
        result = 0
        self.n = len(list)
        self.m = len(list[0])
        # 在二位数组中发现了未被"染色"的数组，就进行一次DFS
        for i in range(self.n):
            for j in range(self.m):
                if grid[i][j] == "1":
                    result += 1
                    self.DFS(grid, i, j)
        return result

    def DFS(self, grid: list[list[str]], i: int, j: int):
        # 对目标数字进行染色
        grid[i][j] = '0'
        for direction in self.Directions:
            x = i + direction[0]
            y = j + direction[1]
            if x < 0 or y < 0 or x >= len(list) or y >= len(
                    list[0]) or grid[x][y] == "0":
                continue
            self.DFS(grid, x, y)