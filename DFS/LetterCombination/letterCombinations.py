class Solution:
    def letterCombinations(self, digits: str) -> list[str]:
        """
        state = {}
        for 每个数字
            for 当前数字的备选字母
                for state中的所有字符串
        """
        if not digits:
            return []

        char = {
            "2": "abc",
            "3": "def",
            "4": "ghi",
            "5": "jkl",
            "6": "mno",
            "7": "pqrs",
            "8": "tuv",
            "9": "wxyz"
        }

        res = [""]
        for item in digits:
            now = []
            for c in char[item]:
                for u in res:
                    now.append(c + u)

            res = now

        return res
        