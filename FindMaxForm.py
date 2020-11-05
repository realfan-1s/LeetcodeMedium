def FindMaxForm(strs: list[str], m, n):
    """
    动态规划解法，三维dp数组
    """
    z = len(strs)
    dp = [[[0] * (n + 1) for _ in range(m + 1)] for _ in range(z + 1)]
    for i in range(1, z + 1):
        ones = strs[i - 1].count("1")
        zeros = strs[i - 1].count("0")
        for j in range(m + 1):
            for q in range(n + 1):
                dp[i][j][q] = dp[i - 1][j][q]
                if j >= zeros and q >= ones:
                    dp[i][j][q] = max(dp[i - 1][j - zeros][q - ones] + 1,
                                      dp[i][j][q])

    return dp[-1][-1][-1]


def findMaxForm(strs: list[str], m: int, n: int):
    """
    动态规划解法，二维dp数组
    """
    if len(strs) == 0:
        return 0

    dp = [[0] * (n + 1) for _ in range(m + 1)]
    for item in strs:
        ones = item.count("1")
        zeros = item.count("0")
        for j in range(m, zeros - 1, -1):
            for k in range(n, ones - 1, -1):
                dp[j][k] = max(dp[j][k], dp[j - zeros][k - ones] + 1)

    return dp[m][n]
