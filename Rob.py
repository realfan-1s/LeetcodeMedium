# 动态规划
# 若第一家偷， 则是第一家至第n-1家的最大值；若第一家不偷， 则是第二家到第n家的最大值
class Solution:
    def DynamicProgramming(self, nums):
        if not nums:
            return 0
        if len(nums) == 1:
            return nums[0]
        max1 = self.dpRank(nums[:-1])
        max2 = self.dpRank(nums[1:])
        return max(max1, max2)

    def dpRank(self, nums):
        n = len(nums)
        dp = [0] * (n + 1)
        dp[1] = nums[0]
        for i in range(2, n + 1):
            dp[i] = max(dp[i - 1], dp[i - 2] + nums[i - 1])
        return dp[n]


print(Solution().DynamicProgramming([1, 2, 1, 1]))
