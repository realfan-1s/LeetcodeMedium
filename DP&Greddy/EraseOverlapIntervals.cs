using System.Collections.Generic;
using System.Collections;
using System;

// 贪心 类似射箭问题
public class Solution1 {
    public int EraseOverlapIntervals(int[][] intervals) {
        int len = intervals.Length;
        if (len == 0)
            return 0;

        Array.Sort(intervals, (x, y) => (x[0].CompareTo(y[0]) + 2 * x[1].CompareTo(y[1])));
        int right = intervals[0][1];
        int ans = 1;

        for (int i = 1; i < len; ++i){
            if (intervals[i][0] >= right){
                ++ans;
                right = intervals[i][1];
            }
        }

        return len - ans;
    }
}

// 动态规划
public class Solution2 {
    public int EraseOverlapIntervals(int[][] intervals) {
        int len = intervals.Length;
        if (len == 0)
            return 0;

        Array.Sort(intervals, (x, y) => (x[0].CompareTo(y[0]) + 2 * x[1].CompareTo(y[1])));
        List<List<int>> dp = new List<List<int>>();

        for (int i = 0; i < len; ++i){
            int left = 0, right = dp.Count;
            while (left < right){
                int mid = left + (right - left) / 2;
                if (dp[mid][1] > intervals[i][0])
                    right = mid;
                else
                    left = mid + 1;
            }

            if (left >= dp.Count)
                dp.Add(intervals[i].ToList());
        }

        return len - dp.Count;
    }
}