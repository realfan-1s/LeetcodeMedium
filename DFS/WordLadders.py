from collections import defaultdict


class solution:
    # 用word[:i] + '*' + word[i + 1:]为键存储各个形式的单词转换形式
    def DFS(self, beginWord: str, endWord: str, wordList: list[str]):
        if endWord not in wordList or not beginWord or not endWord or not wordList:
            return 0

        wordDict = defaultdict(list)
        n = len(beginWord)
        # 用word[:i] + '*' + word[i + 1:]为键存储各个形式的单词转换形式
        # 并设置字典来保存单词的转换形式
        for word in wordList:
            for i in range(n):
                wordDict[word[:i] + '*' + word[i + 1:]].append(word)

        queue = [(beginWord, 1)]
        visited = {beginWord: True}

        while queue:
            currentWord, level = queue.pop(0)
            for i in range(n):
                wordChange = currentWord[:i] + '*' + currentWord[i + 1:]

                for word in wordDict[wordChange]:
                    if word == endWord:
                        return level + 1
                    # 进行BFS搜索，并标记上已访问过的
                    if word not in visited:
                        visited[word] = True
                        queue.append((word, level + 1))

                wordDict[wordChange] = []
        return 0


# 双向广度优先搜索根据给定字典构造的图可能会很大，而广度优先搜索的搜索空间大小依赖于每层节点的分支数量。
# 假如每个节点的分支数量相同，搜索空间会随着层数的增长指数级的增加。
class Solution:
    def __init__(self):
        self.length = 0
        self.wordDict = defaultdict(list)

    def visitWordNode(self, queue: list, visited: dict, others_visited: dict):
        currentWord, level = queue.pop(0)
        for i in range(self.length):
            wordChange = currentWord[:i] + '*' + currentWord[i + 1:]
            for word in self.wordDict[wordChange]:
                if word in others_visited:
                    return level + others_visited[word]
                if word not in visited:
                    visited[word] = level + 1
                    queue.append((word, level + 1))

        return None

    def ladderLength(self, beginWord, endWord, wordList):
        if endWord not in wordList or not beginWord or not endWord or not wordList:
            return 0

        self.length = len(beginWord)

        for word in wordList:
            for i in range(self.length):
                self.wordDict[word[:i] + '*' + word[i + 1:]].append(word)

        queue_Begin = [(beginWord, 1)]
        queue_End = [(endWord, 1)]

        visited_Begin = {beginWord: 1}
        visited_End = {endWord: 1}
        ans = None

        while queue_Begin and queue_End:
            ans = self.visitWordNode(queue_Begin, visited_Begin, visited_End)

            if ans:
                return ans

            ans = self.visitWordNode(queue_End, visited_End, visited_Begin)

            if ans:
                return ans
        return 0
