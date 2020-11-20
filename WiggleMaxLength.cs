using System;
using System.Collections.Generic;
public class Solution {
    public int WiggleMaxLength(int[] nums) {
        int length = nums.Length;
        if (length < 2)
            return length;

        int up = 1, down = 1;

        for (int i = 1; i < length; i++)
        {
            int s = nums[i] - nums[i - 1];

            if (s > 0)
                up = down + 1;
            else if (s < 0)
                down = up + 1;
        }

        return Math.Max(down, up);
    }
}

// 二维动态规划解法
public class solution
{
    public int WiggleMaxLength(int[] nums)
    {
        int length = nums.Length;
        if (length < 2)
            return length;

        int[] up = new int[length];
        int[] down = new int[length];

        for (int i = 1; i < length; i++)
            for (int j = 0; j < i; j++)
            {
                if (nums[i] > nums[j])
                    up[i] = Math.Max(up[i], down[j] + 1);
                else if(nums[i] < nums[j])
                    down[i] = Math.Max(down[i], up[j] + 1);
            }

        return 1 + Math.Max(up[length - 1], down[length - 1]);
    }
}