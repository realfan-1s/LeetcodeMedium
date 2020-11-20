"""
浅拷贝只复制指向某个对象的指针，而不复制对象本身，新旧对象还是共享同一块内存。
但深拷贝会另外创造一个一模一样的对象，新对象跟原对象不共享内存，修改新对象不会改到原对象。
"""

from collections import deque


# Definition for a Node.
class Node:
    def __init__(self, x: int, next: 'Node' = None, random: 'Node' = None):
        self.val = int(x)
        self.next = next
        self.random = random


# hashtable,时空复杂度O(n)
class Solution:
    def copyRandomList(self, head: 'Node') -> 'Node':
        visited = {}

        def BFS(head: 'Node'):
            if not head:
                return head

            # 创建复制的新节点
            clone = Node(head.val, None, None)
            queue = deque()
            queue.append(head)
            visited[head] = clone

            while queue:
                tmp = queue.pop()

                if tmp.next and tmp.next not in visited:
                    visited[tmp.next] = Node(tmp.next.val, [], [])
                    queue.append(tmp.next)

                if tmp.random and tmp.random not in visited:
                    visited[tmp.random] = Node(tmp.random.val, [], [])
                    queue.append(tmp.random)

                visited[tmp].next = visited.get(tmp.next)
                visited[tmp].random = visited.get(tmp.random)
            return clone

        return BFS(head)


# 优化的迭代
class solution:
    def CopyRandomList(self, head: 'Node') -> 'Node':
        """
        我们也可以不使用哈希表的额外空间来保存已经拷贝过的结点，而是将链表进行拓展，
        在每个链表结点的旁边拷贝，比如 A->B->C 变成 A->A'->B->B'->C->C'，
        然后将拷贝的结点分离出来变成 A->B->C和A'->B'->C'，最后返回 A'->B'->C'。
        """
        if not head:
            return head
        cur = head
        # 克隆新结点,并确保克隆的节点在原节点之后
        while cur:
            newNode = Node(cur.val, None, None)
            newNode.next = cur.next
            cur.next = newNode
            cur = newNode.next

        # 链接random
        cur = head
        while cur:
            cur.next.random = cur.random.next if cur.random else None
            cur = cur.next.next

        # 将两个链表分开
        cur_Old_Node = head
        cur_New_Node = head.next
        new_Head = head.next
        while cur_Old_Node:
            cur_Old_Node.next = cur_Old_Node.next.next
            cur_New_Node.next = cur_New_Node.next.next if cur_New_Node.next else None
            cur_Old_Node = cur_Old_Node.next
            cur_New_Node = cur_New_Node.next

        return new_Head
