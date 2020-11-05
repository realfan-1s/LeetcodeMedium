using System.Collections.Specialized;
using System.Collections.Immutable;
using System.Collections.Concurrent;
using System;
using System.Collections;
using System.Collections.Generic;
public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        int length = beginWord.Length;
        if (!wordList.Contains(endWord))
            return 0;
        
        Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
        
        foreach (var item in wordList)
            for (int i = 0; i < length; i++)
            {
                string ch = $"{item.Substring(0, i)}.{item.Substring(i + 1)}";
                if (dic.ContainsKey(ch))
                    dic[ch].Add(item);
                else
                    dic.Add(ch, new List<string>{item});
            }

            Queue<KeyValuePair<string,int>> queue = new Queue<KeyValuePair<string, int>>();
            queue.Enqueue(new KeyValuePair<string, int>(beginWord,1));

            while (queue.Count > 0)
            {
                (string currentWord, int count) = queue.Dequeue();
                for (int i = 0; i < length; i++)
                {
                    string word = $"{currentWord.Substring(0, i)}.{currentWord.Substring(i + 1)}";
                    if (dic.ContainsKey(word))
                    {
                        foreach (var item in dic[word])
                        {
                            if (item == endWord)
                                return ++count;
                            queue.Enqueue(new KeyValuePair<string, int>(item, count+1));
                        }
                        dic.Remove(word);
                    }
                }
            }    

        return 0;
    }
}