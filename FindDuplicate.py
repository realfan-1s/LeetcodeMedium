# 查找哈希表,时间复杂度O(n),空间复杂度O(n)
def HashTableSearch(nums: list[int]) -> int:
    numDict = {}
    for i, n in enumerate(nums):
        if n in numDict:
            return n
        else:
            numDict[n] = i


# 快慢指针法，构造环状链表
# 有环链表，重复数就是入环口
def TwoPointers(nums: list[int]):
    # 生成快慢指针
    slow = 0
    fast = 0
    # 开始寻找环
    while True:
        # 慢指针每次前进一步， 快指针每次前进两步
        slow = nums[slow]
        fast = nums[nums[fast]]
        if slow == fast:
            break

    """
    因为上面快慢指针是在环中某个位置相遇的，这个位置不一定是环的入口
    因此接下来我们还需要找环的入口，即重复的数字
    """

    # 将快指针重新指向数组开头
    fast = 0
    # 开始寻找环的入口
    while True:
        # 慢指针每次走一步
        slow = nums[slow]
        # 快指针每次也走一步
        fast = nums[fast]
        if slow == fast:
            # 相遇的位置一定是环的入口，即重复数字
            return slow