using System;
// 中心扩散法
public class Solution
{
    public string LongestPalindrome(string s)
    {
        int length = s.Length;
        if (s == null || length == 0)
            return "";

        int start = 0, end = 0;
        for (int i = 0; i < length; i++)
        {
            int len1 = ExpandAroundCenter(s, i, i);
            int len2 = ExpandAroundCenter(s, i, i + 1);
            int len = Math.Max(len1, len2);

            if (end - start < len)
            {
                start = i - (len - 1) / 2;
                end = i + len / 2;
            }
        }

        return s.Substring(start, end - start + 1);
    }

    private int ExpandAroundCenter(string s, int left, int right)
    {
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            left--;
            right++;
        }
        return right - left - 1;
    }
}

// 动态规划解法
public class Solution2 {
    public string LongestPalindrome(string s) {
        int length = s.Length;
        bool[,] dp = new int[length, length];
        string ans = "";

        for (int len = 1; len <= length; len++)
            for (int i = 0; i < length; i++)
            {
                int j = i + len - 1;
                if (j >= length)
                    break;

                if (len == 1)
                    dp[i, j] = true;
                else if (len == 2)
                    dp[i, j] = (s[i] == s[j]);
                else
                    dp[i, j] = (s[i] == s[j] & dp[i + 1, j - 1]);

                if (dp[i, j] && len > ans.Length)
                    ans = s.Substring(i, l);
            }

        return ans;

    }
}