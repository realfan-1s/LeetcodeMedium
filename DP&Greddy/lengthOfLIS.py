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


# 贪心+二分查找,要使得上升序列尽可能长，就要让序列上升的尽可能慢
# 求子序列长度，而不是顺序输出，所以可以插入，结果还是长度3。
class Solution:
    def lengthOfLIS(self, nums: List[int]) -> int:
        ans = []
        for n in nums:
            if not ans or n > ans[-1]:
                ans.append(n)
            else:
                left = 0
                right = len(ans) - 1
                pos = right

                while left <= right:
                    mid = left + (right - left) // 2
                    if ans[mid] >= n:
                        pos = mid
                        right = mid - 1
                    else:
                        left = mid + 1

                ans[pos] = n

        return len(ans)
