using System;
// 桶排序 + 插入
public class Solution1 {
    public int LeastInterval(char[] tasks, int n) {
        int[] strs = new int[26];
        int ans = 0;
        foreach (var word in tasks)
            strs[word - 'A']++;

        Array.Sort(strs, (x, y) => -x.CompareTo(y));
        while (strs[0] > 0){
            int i = 0;
            while (i <= n){
                if (strs[0] == 0)
                    break;
                if (i < 26 && strs[i] > 0)
                    strs[i]--;
                ans++;
                i++;
            }
            Array.Sort(strs, (x, y) => -x.CompareTo(y));
        }
        return ans;
    }
}

// 设计
// 假设tasks中出现次数最多的为P次，则最短时间至少为(p - 1) * (n + 1) + 1
public class Solution2 {
    public int LeastInterval(char[] tasks, int n) {
        int[] strs = new int[26];
        foreach (var word in tasks)
            strs[word - 'A']++;

        Array.Sort(strs);
        int maxVal = strs[25] - 1;
        int waitTime = maxVal * n;
        for (int i = 24; i >= 0 && strs[i] > 0; i--)
            waitTime -= Math.Min(strs[i], maxVal);

        return waitTime > 0 ? tasks.Length + waitTime : tasks.Length;
    }
}