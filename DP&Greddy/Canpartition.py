# 二维数组背包问题
def PackOfTwoDemensions(nums: list[int]):
    n = len(nums)
    numsSum = sum(nums)
    if numsSum % 2 == 1 or n < 2:
        return False

    maxNum = max(nums)
    target = numsSum // 2
    if maxNum > target:
        return False

    dp = [[0] * (target + 1) for _ in range(n)]
    for i in range(n):
        dp[i][0] = True

    dp[0][nums[0]] = True
    for i in range(1, n):
        for j in range(1, target + 1):
            if j >= nums[i]:
                dp[i][j] = dp[i - 1][j] | dp[i - 1][j - nums[i]]
            else:
                dp[i][j] = dp[i - 1][j]
    return True if dp[n - 1][target] == 1 else False


# 空间优化，使用一维数组
def PackOfOneDemension(nums: list[int]):
    n = len(nums)
    numsSum = sum(nums)
    if numsSum % 2 == 1 or n < 2:
        return False

    maxNum = max(nums)
    target = numsSum // 2
    if maxNum > target:
        return False

    dp = [True] + [False] * target
    for i, num in enumerate(nums):
        for j in range(target, num - 1, -1):
            dp[j] |= dp[j - num]

    return True if dp[target] == 1 else False
