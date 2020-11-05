def SlidingWindow(A):
    n = len(A)
    if n == 1:
        return 1
    if n == 2 and A[0] == A[1]:
        return 1
    res = 1
    slow, fast = 0, 1
    while fast < n - 1:
        if A[fast - 1] < A[fast] > A[fast + 1] or A[fast -
                                                    1] > A[fast] < A[fast + 1]:
            fast += 1
        elif A[fast - 1] == A[fast] == A[fast + 1]:
            fast += 1
            slow = fast
        else:
            res = max(fast - slow + 1, res)
            slow = fast
            fast += 1
    return max(fast - slow + 1, res)


def DynamicProgramming(A: list):
    n = len(A)
    if len(A) == 1 or max(A) == min(A):
        return 1
    dp = [1] * n
    for i in range(2, n - 1):
        if A[i - 1] > A[i] < A[i + 1] or A[i - 1] < A[i] > A[i + 1]:
            dp[i] = dp[i - 1] + 1

    return max(dp) + 1
