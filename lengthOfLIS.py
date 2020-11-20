# 动态规划,最长上升子序列
def DynamicProgramming(nums: list[int]):
    if not nums:
        return 0
    n = len(nums)
    dp = [1] * (n + 1)
    # 首先考虑前i个的最大dp
    for i in range(n):
        for j in range(i):
            dp[i] = max(dp[i], dp[j] + 1)

    return max(dp)