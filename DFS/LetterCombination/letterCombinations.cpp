#include <iostream>
#include <algorithm>
#include <cstring>
#include <queue>
#include <cstdio>

using namespace std;

class Solution
{
public:
    string wordDict[8] = {"abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};

    vector<string> letterCombinations(string digits)
    {
        if (digits.empty())
            return vector<string>();

        vector<string> res(1, "");
        for (auto item : digits)
        {
            vector<string> now;
            for (auto c : wordDict[item - '2'])
                for (auto u : res)
                    now.push_back(u + c);

            res = now;
        }

        return res;
    }
};