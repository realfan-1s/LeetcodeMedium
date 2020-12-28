#include <stdc++.h>

using namespace std;

// 回溯+剪枝
class Solution {
public:
    int length;
    vector<int> ans;
    vector<int> splitIntoFibonacci(string S) {
        length = S.size();
        TraceBack(S, 0, 0, 0);
        return ans;
    }
private:
    bool TraceBack(string& S, int index, long long sums, int prev){
        if (index == length)
            return ans.size() > 2;

        long long cur = 0;

        for (int i = index; i < length; i++){
            // 除非是0否则不能以0开头
            if (i > index && S[index] == '0')
                break;
            cur = cur * 10 + S[i] - '0';
            // 当前值大于int.maxvalue
            if (cur > INT32_MAX)
                break;
            // 当前数若小于列表中最后两数之和，直接进行下一次循环
            // 若已经大于列表中最后两数之和，继续循环当前数字只会越来越大，因此结束循环
            if (ans.size() > 1){
                if (cur < sums)
                    continue;
                else if (cur > sums)
                    break;
            }
            ans.push_back(cur);
            if (TraceBack(S, i + 1, prev + cur, cur))
                return true;
            ans.pop_back();
        }
        return false;
    }
};