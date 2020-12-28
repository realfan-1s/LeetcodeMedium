using System.Text;
// 插空 + 桶排序
public class Solution {
    public string ReorganizeString(string S) {
        int length = S.Length;
        StringBuilder ans = new StringBuilder();
        int[] strs = new int[26];
        int max = 0;
        int idx = 0;
        for (int i = 0; i < length; i++){
            strs[S[i] - 'a']++;
            if (max < strs[S[i] - 'a']){
                max = strs[S[i] - 'a'];
                idx = S[i] - 'a';
            }
        }

        if (length % 2 == 0 && max > length / 2)
            return "";
        if (length % 2 == 1 && max > length / 2 + 1)
            return "";

        while (strs[idx] > 0){
            ans.Append((char)(idx + 'a'));
            strs[idx]--;
        }
        int pos = 1;
        for (int i = 0; i < 26; i++){
            while (strs[i] > 0){
                ans.Insert(pos, (char)(i + 'a'));
                pos += 2;
                strs[i]--;
                if (pos > ans.Length)
                    pos = 1;
            }
        }

        return ans.ToString();
    }
}