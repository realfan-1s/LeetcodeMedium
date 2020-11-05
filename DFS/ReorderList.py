class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next


def LinearList(head: ListNode):
    # 链表不支持下标访问，我们无法随机访问链表中的任意元素
    # 利用线性表存储该链表，然后利用线性表可以下标访问的特点，直接按顺序访问指定元素
    if not head:
        return

    vec = list()
    node = head
    while node:
        vec.append(node)
        node = node.next

    i, j = 0, len(vec) - 1
    while i < j:
        vec[i].next = vec[j]
        i += 1
        vec[j].next = vec[i]
        j -= 1

    vec[i].next = None


# 寻找链表中点 + 链表逆序 + 合并链表
class Solution:
    """
    1.找到原链表的中点
    2.将原链表的右半端反转
    3.将原链表的两端合并。
    """
    def ReorderList(self, head: ListNode):
        if not head:
            return

        mid = self.MiddleNode(head)
        l1 = head
        l2 = mid.next
        mid.next = None
        l2 = self.ReverseNode(l2)
        self.MergeList(l1, l2)

    def MiddleNode(self, head: ListNode):
        slow, fast = head, head
        while fast.next and fast.next.next:
            slow = slow.next
            fast = fast.next.next
        return slow

    def ReverseNode(self, node: ListNode):
        previous = None
        cur = node
        while cur:
            tmp = cur.next
            cur.next = previous
            previous = cur
            cur = tmp

        return previous

    def MergeList(self, l1: ListNode, l2: ListNode):
        while l1 and l2:
            l1_tmp = l1.next
            l2_tmp = l2.next

            l1.next = l2
            l1 = l1_tmp

            l2.next = l1
            l2 = l2_tmp
