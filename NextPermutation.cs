using System;
using System.ComponentModel;
public class Solution {
    public void NextPermutation (int[] nums) {
        int length = nums.Length;
        if (nums == null || length <= 1)
            return;
        for (int i = length - 2; i >= 0; i--) {
            if (nums[i] < nums[i + 1]) {
                int bigNum = FindBig (nums, i);
                int tmp = nums[i];
                nums[i] = nums[bigNum];
                nums[bigNum] = tmp;
                Array.Sort (nums, i + 1, length - i - 1);
                break;
            }
            if (i == 0)
                Array.Sort (nums);
        }
    }

    public int FindBig (int[] nums, int pos) {
        int minSize = int.MaxValue;
        for (int i = pos + 1; i < nums.Length; i++)
            if (nums[pos] < nums[i])
                minSize = Math.Min (minSize, nums[i]);

        return Array.IndexOf (nums, minSize, pos + 1, nums.Length - pos - 1);
    }
}