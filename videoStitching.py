class Solution:
    def videoStitching(self, clips: list[list[int]], T: int) -> int:
        dp = [0] + [float('inf')] * T
        for i in range(1, T + 1):
            for start, end in clips:
                if start < i <= end:
                    dp[i] = min(dp[i], dp[start] + 1)

        return -1 if dp[T] == float('inf') else dp[T]
