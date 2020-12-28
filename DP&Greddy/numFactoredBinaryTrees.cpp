#include <stdc++.h>

using namespace std;

class Solution {
public:
    int numFactoredBinaryTrees(vector<int>& A) {
        int mod = 1000000007;
        long long ans = 0;
        int length = A.size();
        sort(A.begin(), A.end());
        vector<long long> dp(length, 1);
        unordered_map<int, int> dict;
        for (int i = 0; i < length; i++)
            dict.emplace(A[i], i);

        // 自顶向下
        for (int i = 0; i < length; i++)
            for (int j = 0; j < i; j++){
                if (A[i] % A[j] == 0 && dict.find(A[i] / A[j]) != dict.end()){
                    int tmp = A[i] / A[j];
                    dp[i] += dp[j] * dp[dict[tmp]];
                }
            }

        for (int k =0; k < length; k++){
            ans += dp[k];
        }

        return (int) (ans % mod);
    }
};