class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next


class Solution:
    def sortList(self, head: ListNode) -> ListNode:
        """
        我们需要使用自底向上非递归形式的归并排序算法。
        先将前后两个节点排序
        在将前后四个节点排序
        ......
        另外，当 nn 不是2的整次幂时，每次迭代只有最后一个区间会比较特殊，长度会小一些，遍历到指针为空时需要提前结束。
        """
        dummy = ListNode(0)
        dummy.next = head

        length, i, p = 0, 1, head
        while p:
            p = p.next
            length += 1

        while i < length:
            cur = dummy
            for j in range(1, length - i + 1, 2 * i):
                p = cur.next
                q = p
                # 移动到链段末尾
                for _ in range(i):
                    q = q.next
                x, y = 0, 0
                while x < i and y < i and p and q:
                    if p.val <= q.val:
                        cur.next = p
                        p = p.next
                        cur = cur.next
                        x += 1
                    else:
                        cur.next = q
                        q = q.next
                        cur = cur.next
                        y += 1
                # 将多余的进行归并
                while x < i and p:
                    cur = cur.next = p
                    p = p.next
                    x += 1
                while y < i and q:
                    cur = cur.next = q
                    q = q.next
                    y += 1

                cur.next = q
            i *= 2

        return dummy.next
