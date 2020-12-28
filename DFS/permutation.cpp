#include <stdc++.h>

using namespace std;

class Solution {
public:
    vector<string> ans;
    int length;
    bool* visited;
    string cur;
    vector<string> permutation(string s) {
        length = s.size();
        visited = new bool[length]{false};
        sort(s.begin(), s.end());
        TraceBack(s);
        return ans;
    }
    void TraceBack(string& s){
        if (cur.size() == length){
            ans.push_back(cur);
            return;
        }
        for (int i = 0; i < length; i++){
            if (visited[i] || (i > 0 && !visited[i - 1] && s[i - 1] == s[i]))
                continue;

            visited[i] = true;
            cur += s[i];
            TraceBack(s);
            cur.erase(cur.end() - 1);
            visited[i] = false;
        }
    }
};