#include <stdc++.h>

using namespace std;

// 二元动态规划,由于存在手续费因此无法使用贪心解决
// dp[i][0]表示第i天交易完后手里没有股票的最大利润，dp[i][1]表示手里持有一支股票的最大利润
class Solution1 {
public:
    int maxProfit(vector<int>& prices, int fee) {
        int length = prices.size();
        vector<vector<int>> dp(length, vector<int>(2));
        dp[0][0] = 0, dp[0][1] = -prices[0];
        for (int i = 1; i < length; ++i){
            dp[i][1] = max(dp[i - 1][1], dp[i - 1][0] - prices[i]);
            dp[i][0] = max(dp[i - 1][0], dp[i - 1][1] + prices[i] - fee);
        }
        return dp[length - 1][0];
    }
};

// 一元动态规划
class Solution2 {
public:
    int maxProfit(vector<int>& prices, int fee) {
        ios::sync_with_stdio(false);
        int length = prices.size();
        int profit = 0, buyin = -prices[0];
        for (int i = 1; i < length; ++i){
            profit = max(profit, buyin + prices[i] - fee);
            buyin = max(buyin, profit - prices[i]);
        }
        return profit;
    }
};