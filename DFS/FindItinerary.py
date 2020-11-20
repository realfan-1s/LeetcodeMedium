import heapq
from collections import defaultdict


class Solution:
    def findItinerary(self, tickets: list[list[str]]):
        """
        Post-Order traversal on edge

        回溯算法模板
        def findItinerary(self, tickets):
            path = [] # 记录路径
            # res = [] # 多条路径，记录结果
            def backtrack(cur):

                if # 结束条件:
                    # res.append(path[:])
                    return True

            for 某节点 in 当前节点可以有的选择:
                # 去掉不合适选择
                path.append(某节点)  # 做选择
                if backtrack(某节点):  # 进入下一层决策树
                    return True
                path.pop()  # 取消选择

            return False
            backtrack(cur)
            return path
        """
        # 将列表转变为图
        from collections import defaultdict
        ticket_dict = defaultdict(list)
        for item in tickets:
            ticket_dict[item[0]].append(item[1])

        path = ['JFK']

        def TraceBack(startPort: str):
            # 路径数（不包括初始点位）与机票数（edge）数量相等时，表明已经遍历所有区域
            if len(path) == len(tickets) + 1:
                return True
            ticket_dict[startPort].sort()
            for _ in ticket_dict[startPort]:
                aimPort = ticket_dict[startPort].pop(0)
                path.append(aimPort)
                if TraceBack(aimPort):
                    return True
                path.pop()
                ticket_dict[startPort].append(aimPort)
            return False

        TraceBack('JFK')
        return path


def DFS(tickets: list[list[str]]):
    ticket_Dict = defaultdict(list)
    for depart, to in tickets:
        ticket_Dict[depart] = to

    # 创建堆,构成图
    for key in ticket_Dict:
        heapq.heapify(ticket_Dict[key])

    stack = list()

    def DepthSearch(cur: str):
        while ticket_Dict[cur]:
            tmp = heapq.heappop(ticket_Dict[cur])
            # 递归找到死胡同（没有子递归可以调用）后递归函数开始返回
            DepthSearch(tmp)
        stack.append(cur)

    DepthSearch('JFK')
    return stack[::-1]