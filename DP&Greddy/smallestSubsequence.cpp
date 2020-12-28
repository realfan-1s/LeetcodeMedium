#include <stdc++.h>

using namespace std;

class Solution {
public:
    string smallestSubsequence(string s) {
        int length = s.size();
        stack<char> stk;
        int count[26]{0};
        bool inStack[26]{false};
        for (int i = 0; i < length; i++)
            count[s[i] - 'a']++;

        for (int i = 0; i < length; i++){
            count[s[i] - 'a']--;
            if (inStack[s[i] - 'a'])
                continue;
            while (!stk.empty() && stk.top() > s[i] && count[stk.top() - 'a'] > 0){
                inStack[stk.top() - 'a'] = false;
                stk.pop();
            }
            stk.push(s[i]);
            inStack[s[i] - 'a'] = true;
        }

        string ans;
        while (!stk.empty())
        {
            ans += stk.top();
            stk.pop();
        }
        reverse(ans.begin(), ans.end());
        return ans;
    }
};