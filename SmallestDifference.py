# 排序+双指针
def TwoPointers(a: list[int], b: list[int]):
    a.sort()
    b.sort()
    aLength = len(a)
    bLength = len(b)
    minNum = 0
    i, j = 0, 0
    while i < aLength and j < bLength:
        res = b[j] - a[i]
        if abs(res) < minNum:
            minNum = abs(res)
        if res == 0:
            return minNum
        elif res > 0:
            i += 1
        else:
            j += 1

    return minNum