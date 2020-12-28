#include <stdc++.h>

using namespace std;

class Solution {
public:
    int matrixScore(vector<vector<int>>& A) {
        int col = A[0].size();
        int row = A.size();
        int ans = 0;

        for (int i = 0; i < col; i++){
            int ones = 0;
            for (int j = 0; j < row; j++)
                ones += A[j][i] ^ A[j][0];

            ans += max(ones, row - ones) * (1 << (col - i - 1));
        }
        return ans;
    }
};