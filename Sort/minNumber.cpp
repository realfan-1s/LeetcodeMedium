#include <stdc++.h>

using namespace std;

class Solution {
public:
    static bool Compare(const string& A, const string& B){
        string str1 = A + B;
        string str2 = B + A;
        return str1 < str2;
    }
    string minNumber(vector<int>& nums) {
        vector<string> strs;
        int length = nums.size();
        string ans = "";
        for (int i = 0; i < length; i++)
            strs.push_back(to_string(nums[i]));

        sort(strs.begin(), strs.end(), Compare);

        for (auto word : strs)
            ans += word;

        while (ans[0] == '0')
            ans.erase(ans.begin());
        return ans == "" ? "0" : ans;
    }

    void FastSort(vector<string>& strs, int left, int right){
        if (left >= right)
            return;
        int i = left, j = right;
        string tmp = strs[left];
        while (i < j){
            while (i < j && Compare(strs[j], strs[left]))
                j--;
            while (i < j && !Compare(strs[i], strs[left]))
                i++;
            tmp = strs[i];
            strs[i] = strs[j];
            strs[j] = tmp;
        }

        tmp = strs[left];
        strs[left] = strs[j];
        strs[j] = tmp;
        FastSort(strs, left, i - 1);
        FastSort(strs, i + 1, right);
    }
};