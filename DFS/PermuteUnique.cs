using System;
using System.Collections.Generic;
using System.Collections;

// 法一
public class Solution {
    IList<IList<int>> ans = new List<IList<int>>();
    List<int> res = new List<int>();
    int length;
    bool[] visited;
    public IList<IList<int>> PermuteUnique(int[] nums) {
        length = nums.Length;
        visited = new bool[length];
        Array.Sort(nums);

        dfs(nums, 0);
        return ans;
    }

    public void dfs(int[] nums, int u)
    {
        if (u == length)
        {
            ans.Add(res.ToArray());
            return;
        }

        for (int i = 0; i < length; i++)
        {
            if (visited[i] || (i > 0 && nums[i] == nums[i - 1] && !visited[i - 1]))
                continue;

            visited[i] = true;
            res.Add(nums[i]);
            dfs(nums, u + 1);
            visited[i] = false;
            res.RemoveAt(res.Count - 1);
        }
    }
}

// 法二
public class solution {
    IList<IList<Int>> ans = new List<IList<int>>();
    int[] res;
    bool[] visited;
    int length;
    public IList<IList<int>> PermuteUnique(int[] nums) {
        length = nums.Length;
        visited = new bool[length];
        res = new int[length];

        Array.Sort(nums);
        dfs(nums, 0, 0);

        return ans;
    }

    public void dfs(int[] nums, int u, int start)
    {
        if (u == length)
        {
            ans.Add(res);
            return;
        }

        for (int i = start; i < length; i++)
            if (!visited[i])
            {
                visited[i] = true;
                res[i] = nums[u];
                dfs(nums, u + 1, (u = 1 < length && nums[u] == nums[u + 1] ? i + 1 : 0));
                visited[i] = false;
            }
    }
}