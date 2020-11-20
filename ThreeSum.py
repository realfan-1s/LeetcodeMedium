# 「不重复」的本质是什么？我们保持三重循环的大框架不变，只需要保证：
# 第二重循环枚举到的元素不小于当前第一重循环枚举到的元素；
# 第三重循环枚举到的元素不小于当前第二重循环枚举到的元素。


# 双指针+排序,时间复杂度O(N^2),空间复杂度O(logN)
def TwoPointer(nums: list(int)):
    n = len(nums)
    nums.sort()
    ans = []
    # 枚举 a
    for first in range(n):
        # 需要和上一次枚举的数不相同
        if first > 0 and nums[first] == nums[first - 1]:
            continue
        # c 对应的指针初始指向数组的最右端
        third = n - 1
        target = -nums[first]
        for second in range(first + 1, n):
            # 需要和上一次枚举的数不相同
            if second > first + 1 and nums[second] == nums[second - 1]:
                continue
                # 需要保证 b 的指针在 c 的指针的左侧
            while second < third and nums[second] + nums[third] > target:
                third -= 1
            # 如果指针重合，随着 b 后续的增加
            # 就不会有满足 a+b+c=0 并且 b<c 的 c 了，可以退出循环
            if second == third:
                break
            if nums[second] + nums[third] == target:
                ans.append([nums[first], nums[second], nums[third]])

    return ans


# 哈希表
def HashTable(nums: list[int]):
    n = len(nums)
    if not nums or n < 3:
        return []

    nums.sort()
    ans = []
    hashThird = {}

    # 将数字加入哈希表中
    for i, n in enumerate(nums):
        hashThird[n] = i

    for first in range(n):
        if first > 0 and nums[first] == nums[first - 1]:
            continue
        target = -nums[first]

        for second in range(first + 1, n):
            if second > first + 1 and nums[second] == nums[second - 1]:
                continue
            if hashThird.get(target - nums[second]):
                third = hashThird[target - nums[second]]
                if second < third:
                    ans.append([nums[first], nums[second], nums[third]])
                else:
                    break

    return ans
