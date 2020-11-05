using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;

public class Solution {
    public IList<string> LetterCombinations(string digits) {

        Dictionary<string, string> numDict = new Dictionary<string, string>() 
        { { "2", "abc" }, { "3", "def" }, { "4", "ghi" }, { "5", "jkl" }, 
        { "6", "mno" }, { "7", "pqrs" }, { "8", "tuv" }, { "9", "wxyz" } };

        if (digits.Length == 0)
            return new List<string>();

        List<string> res = new List<string>(){""};

        foreach (var item in digits)
        {
            string word = char.ToString(item);
            List<string> now = new List<string>();
            foreach (var c in numDict[item])
                foreach (var u in res)
                    now.Add(u + c);
            res = now;
        }

        return res;
    }
}