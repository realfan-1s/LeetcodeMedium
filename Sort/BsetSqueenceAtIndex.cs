using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System;

public class Solution {
    public int BestSeqAtIndex(int[] height, int[] weight) {
        // 对身高升序排序,若身高相同，则按体重降序排序
        List<Tuple<int, int>> people = new List<Tuple<int, int>>();
        for (int i = 0; i < height.Length; i++)
            people.Add(new Tuple<int, int>(height[i], weight[i]));
        people.Sort((x, y) => x.Item1.CompareTo(y.Item1) * 2 - (x.Item2.CompareTo(y.Item2)));

        // p[i]的意义是：长度为(i+1)的weight严格上升子序列中，末尾的weight最小是多少
        List<int> dp = new List<int>();

        for (int i = 0; i < people.Count; i++)
        {
            if (dp.Count == 0 || people[i].Item2 > dp[dp.Count - 1])
                dp.Add(people[i].Item2);
            else
            {
                int left = 0;
                int right = dp.Count;
                while (left < right)
                {
                    int mid = (left + right) / 2;
                    if (dp[mid] >= people[i].Item2)
                        right = mid;
                    else
                        left = mid + 1;
                }

                dp[left] = people[i].Item2;
            }
        }

        return dp.Count;
    }
}