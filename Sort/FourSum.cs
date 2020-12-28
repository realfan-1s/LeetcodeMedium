using System;
using System.Collections.Generic;
public class Solution {
    public IList<IList<int>> FourSum(int[] nums, int target) {
        List<IList<int>> ans = new List<IList<int>>();
        int length = nums.Length;
        if (nums == null || length < 3)
            return ans;

        Array.Sort(nums);
        for (int i = 0; i < length - 3; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
                continue;
            // 最近的四数之和大于目标值，之后的值也一定大于目标值，结束循环
            if (nums[i] + nums[i + 1] + nums[i + 2] + nums[i + 3] > target)
                break;
            // 当前数字与最大的三个数字之和小于目标值，证明这次循环中一定不存在解，跳过
            if (nums[i] + nums[length -3] + nums[length - 2] + nums[length - 1] < target)
                continue;
            for (int j = i + 1; j < length - 2; j++)
            {
                if (j > i + 1 && nums[j] == nums[j - 1])
                    continue;
                if (nums[i] + nums[j] + nums[j + 1] + nums[j + 2] > target)
                    break;
                if (nums[i] + nums[j] + nums[length - 2] + nums[length - 1] < target)
                    continue;
                int left = j + 1, right = length - 1;
                while (left < right)
                {
                    int sum = nums[i] + nums[j] + nums[left] + nums[right] ;
                    if (sum == target)
                    {
                        ans.Add(new int[4]{nums[i], nums[j], nums[left], nums[right]});
                        while (left < right && nums[left] == nums[left + 1])
                            left++;
                        while (left < right && nums[right] == nums[right - 1])
                            right--;
                        left++;
                        right--;
                    }
                    else if (sum < target)
                        left++;
                    else
                        right--;
                }
            }
        }

        return ans;
    }
}