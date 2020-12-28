using System;
using System.Collections.Generic;
public class Solution {
    public int[] FindSquare(int[][] matrix) {
        int len = matrix.Length;
        // 只有向右和向下两种方向
        int[,,] dp = new int[len, len, 2];
        int[] ans = new int[3];
        if (len == 0)
            return new List<int>().ToArray();
        else if (len == 1){
            if (matrix[0][0] == 0)
                return new int[3]{0, 0, 1};
            else
                return new List<int>().ToArray();
        } else{
            for (int i  = len - 1; i >= 0; --i)
                for (int j = len - 1; j >= 0; --j){
                    if (matrix[i][j] == 0){
                        if (i == len - 1)
                            dp[i, j, 0] = 1;
                        else
                            dp[i, j, 0] = dp[i + 1, j, 0] + 1;

                        if (j == len - 1)
                            dp[i, j, 1] = 1;
                        else
                            dp[i, j, 1] = dp[i, j + 1, 1] + 1;

                        int size = Math.Min(dp[i, j, 0], dp[i, j, 1]);
                        while (size >= ans[2]){
                            // 已经确定长宽分别各自的最大长度，要判断长宽能时存在的最大长度
                            if (dp[i + size - 1, j, 1] >= size && dp[i, j + size - 1, 0] >= size){
                                ans = new int[3]{i, j, size};
                                break;
                            }
                            --size;
                        }
                    }
                }

            return ans[2] == 0 ? new List<int>().ToArray() : ans;
        }
    }
}