class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next


# 快慢指针法
def SlowAndQuickPointers(head: ListNode, n: int):
    dummy = ListNode(0)
    dummy.next = head
    i, j = dummy, dummy
    # step1: 快指针先走n步
    for _ in range(n):
        j = j.next

    # step2: 快慢指针同时走，直到fast指针到达尾部节点，此时slow到达倒数第N个节点的前一个节点
    while j and j.next:
        i = i.next
        j = j.next

    # step3: 删除节点，并重新连接
    i.next = i.next.next
    return dummy.next


# 循环迭代找到
def Recursion(head: ListNode, n: int):
    dummy = ListNode(0)
    dummy.next = head

    # step1:获取链表的长度
    cur = head
    length = 0
    while cur:
        cur = cur.next
        length += 1

    # step2:找到倒数第N个节点的前一个节点
    cur = dummy
    for i in range(length - n):
        cur = cur.next

    # step3：删除节点，重新连接
    cur.next = cur.next.next
    return dummy.next


# 循环迭代--回溯时进行循环计数
class Solution:
    def BackTracking(self, head: ListNode, n: int):
        if not head:
            self.count = 0
            return head

        head.next = self.removeNthFromEnd(head.next, n)  # 递归调用
        self.count += 1  # 回溯时进行节点计数
        return head.next if self.count == n else head
