#include <stdc++.h>

using namespace std;

class Solution {
private:
    bool IsPartition(const string& s, int start, int end){
        int i = start, j = end;
        while (i < j){
            if (s[i++] != s[j--])
                return false;
        }
        return true;
    }
    void TraceBack(const string& s, int start){
        if (start == len){
            ans.emplace_back(res);
            return;
        }

        for (int i = start; i < len; ++i){
            if (IsPartition(s, start, i)){
                res.emplace_back(s.substr(start, i - start + 1));
            }else{
                continue;
            }
            TraceBack(s, i + 1);
            res.pop_back();
        }
    }
public:
    vector<vector<string>> partition(string s) {
        len = s.size();
        TraceBack(s, 0);
        return ans;
    }
private:
    vector<vector<string>> ans;
    int len;
    vector<string> res;
};