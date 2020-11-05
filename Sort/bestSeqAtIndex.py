import bisect


# 二分查找+动态规划,身高、体重都升序排序
def DynamicPrograming(height: list[int], weight: list[int]):
    hw = sorted(zip(height, weight))
    # dp[i]:长度为(i+1)的(height, weight)双严格上升子序列中，末尾的weight最小是多少
    dp = []
    temp = []

    for j in range(len(hw)):
        # temp:记录要填入的体重与位置
        temp.append((hw[j][1], bisect.bisect_left(dp, hw[j][1])))
        # 到达尽头或下一个的体重严格增大时，开始填入
        if j == len(hw) - 1 or hw[j][0] < hw[j + 1][0]:
            for w, i in temp:
                if i == len(dp):
                    dp.append(w)
                else:
                    dp[i] = min(dp[i], w)
            temp = []

    return len(dp)


# 身高升序排序，若身高相同则按照体重降序排序
def DynamicProgramming(height: list[int], weight: list[int]):
    peoples = []
    for i in range(len(height)):
        peoples.append((height[i], weight[i]))

    peoples.sort(key=lambda x: [x[0], -x[1]])

    dp = []
    for i in range(len(peoples)):
        if not dp or peoples[i][1] > dp[-1]:
            dp.append(peoples[i][1])
        else:
            left = 0
            right = len(dp)
            # 查找第一个大于等于persons[i][1]的位置
            while left < right:
                mid = (left + right) // 2
                if dp[mid] >= peoples[i][1]:
                    right = mid
                else:
                    left = mid + 1

            dp[left] = peoples[i][1]

    return len(dp)
