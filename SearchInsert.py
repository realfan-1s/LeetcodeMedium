# 二分查找,若一个问题中待查找的数是整数，且知道范围，通常可以使用二分查找法
def BinarySreach(nums, target):
    """
    首先设定左下标left和右下标right，再计算中间下标mid
    每次根据num[mid]和target间的关系判断，相等则直接返回下标
    若nums[mid]<target，则left右移动；若nums[mid]>target，则right左移
    若查找结束没有相等，则返回left
    """
    left = 0
    right = len(nums) - 1
    while left <= right:
        mid = (right + left) // 2
        if nums[mid] == target:
            return mid
        elif nums[mid] < target:
            left = mid + 1
        else:
            right = mid - 1
    return left


# 哈希表查找
def HashTable(nums, target):
    if nums[-1] < target:
        return len(nums)
    numDict = {}
    for i, n in enumerate(nums):
        numDict[n] = i
    if target in numDict:
        return numDict[target]
    else:
        for item in nums:
            if item > target:
                return numDict[item]
