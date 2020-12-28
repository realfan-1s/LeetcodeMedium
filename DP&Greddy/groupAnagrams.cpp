#include <stdc++.h>
#include <unordered_set>

using namespace std;

class Solution {
public:
    vector<vector<string>> groupAnagrams(vector<string>& strs) {
        int length = strs.size();
        unordered_map<string, vector<string>> wordDict;
        for (int i = 0; i < length; i++){
            auto tmp = strs[i];
            sort(strs[i].begin(), strs[i].end());
            if (wordDict.find(strs[i]) != wordDict.end())
                wordDict[strs[i]].push_back(tmp);
            else
                wordDict.emplace(strs[i], vector<string>{tmp});
        }

        vector<vector<string>> ans;
        for (auto& item : wordDict)
            ans.push_back(item.second);

        return ans;
    }
};