using System.Linq;
using System;
using System.Collections.Generic;
public class Solution {
    List<string> ans = new List<string>();
    List<string> res = new List<string>();
    int length;
    List<string> wordList = new List<string>();
    bool[] visited;
    public string[] Permutation(string s) {
        length = s.Length;
        visited = new bool[length];

        foreach (var item in s)
        {
            wordList.Add(item.ToString());
        }

        wordList.Sort();
        dfs(wordList, 0);
        return ans.ToArray();
    }

    private void dfs(List<string> words, int start)
    {
        if (res.Count == words.Count)
        {
            ans.Add(String.Join("", (res.ToArray())));
            return;
        }

        for (int i = 0; i < length; i++)
        {
            // 若当前的字母已经被访问过或者当前字母与前一个相同并且前一个未被访问
            if (visited[i] || (i > 0 && words[i] == words[i - 1] && !visited[i - 1]))
                continue;

            res.Add(words[i]);
            visited[i] = true;
            dfs(words, i + 1);
            res.RemoveAt(res.Count - 1);
            visited[i] = false;
        }
    }
}

public class Solution {
    public int[] FindSwapValues(int[] array1, int[] array2) {
        int sum(int[] array) => Enumerable.Sum(array);

        int sumArray1 = sum(array1);
        int sumArray2 = sum(array2);

        for (int i = 0; i < array1.Length; i++)
            for (int j = 0; j < array2.Length; j++)
            {
                if (sumArray1 - array1[i] + array2[j] == sumArray2 + array1[i] - array2[j])
                    return new int[2] { i, j };
            }

        return new int[2];
    }
}

