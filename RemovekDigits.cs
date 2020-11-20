using System.Collections.Generic;
using System.Buffers;
using System.Linq;
using System;
using System.Collections;
using System.Data.Objects;

public class Solution {
    // 若是单调递增数组，优先从后往前删除数字
    // 若非单调递增数组，从前往后看第一个逆序对（新数字小于前段单调递增数列）    
    public string RemoveKdigits(string num, int k) {
        if (k >= num.Length)
            return "0";

        int i = 1;
        while (i < num.Length && k > 0)
        {
            if (num[i] < num[i - 1] && k > 0)
            {
                num = num.Remove(i - 1, 1);
                i--;
                if (i < 1)
                    i = 1;
                k--;
            }
            else
                i++;
        }

        if (k > 0)
            num = num.Remove(num.Length - k, k);

        while (num.Length > 1 && num[0] == '0')
            num = num.Remove(0, 1);

        return num;
    }
}