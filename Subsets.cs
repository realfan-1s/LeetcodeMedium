using System.Collections;
using System.Collections.Generic;
public class Solution {
    // 使用二进制 n，i = 2 ^ n - 1,每位对应数组中的数字是否选择,
    // i的二进制表示的第j位是否为1，i>>j&1
    private IList<IList<int>> Subsets(int[] nums) {
        IList<IList<int>> res = new List<IList<int>>();
        for (int i = 0; i < 1 << nums.Length; i++)
        {
            List<int> now = new List<int>();
            for (int j = 0; j < nums.Length; j++)
                if (((i >> j) & 1) == 1)
                    now.Add(nums[j]);
            res.Add(now.ToArray());
        }

        return res;
    }
}

// 可能会含有重复数组的情况
public class solution {

    IList<IList<int>> res = new List<IList<int>>();
    List<int> ans = new List<int>();
    int length;

    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        length = nums.Length;
        Array.Sort(nums);
        dfs(nums, 0);
        return res;
    }

    private void dfs(int[] nums, int u)
    {
        res.Add(ans.ToArray());
        for (int i = u; i < length; i++)
        {
            if (i > u && nums[i] == nums[i - 1])
                continue;

            ans.Add(nums[i]);
            dfs(nums, u + 1);
            ans.RemoveAt(ans.Count - 1);
        }
    }
}

