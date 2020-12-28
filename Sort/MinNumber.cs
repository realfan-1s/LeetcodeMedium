using System;
using System.Collections.Generic;
public class Solution {
    // 假设存在nums任意两个数字x,y；
    //若拼接字符串x + y > y + x证明字符串"x" > 字符串“y”
    //若拼接字符串x + y < y + x证明字符串"x" < 字符串“y”
    // 时间复杂度O(NlogN)， 空间复杂度O(N)
    List<String> numList = new List<string>();
    public string MinNumber(int[] nums) {
        int length = nums.Length;
        for (int i = 0; i < length; i++)
            numList.Add(Convert.ToString(nums[i]));

        FastSort(0, length - 1);
        return String.Join("", numList.ToArray());
    }
    private void FastSort (int left, int right){
        if (left >= right)
            return;
        int i = left;
        int j = right;
        string tmp = numList[left];
        while (i < j){
            // y + x >= x + y => j对应的值大于参比值
            while (i < j &&
            (numList[j] + numList[left]).CompareTo(numList[left] + numList[j]) >= 0)
                j--;
            // y + x <= x + y => i对应的值小于参比值
            while (i < j &&
            (numList[i] + numList[left]).CompareTo(numList[left] + numList[i]) <= 0)
                i++;
            tmp = numList[i];
            numList[i] = numList[j];
            numList[j] = tmp;
        }
        // 交换中值点
        tmp = numList[left];
        numList[left] = numList[j];
        numList[j] = tmp;
        FastSort(left, i - 1);
        FastSort(i + 1 , right);
    }
}