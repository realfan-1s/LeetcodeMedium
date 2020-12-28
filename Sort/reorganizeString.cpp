#include <stdc++.h>

using namespace std;

class Solution {
public:
    string reorganizeString(string S) {
        int length = S.size();
        vector<int> bucket(26, 0);
        string ans = "";
        int maxVal = 0;
        int idx = 0;
        for (char word : S){
            bucket[word - 'a']++;
            if (bucket[word - 'a'] > maxVal){
                maxVal = bucket[word - 'a'];
                idx = word - 'a';
            }
        }

        if (length % 2 == 0 && maxVal > length / 2)
            return "";
        if (length % 2 == 1 && maxVal > length / 2 + 1)
            return "";

        while (bucket[idx] > 0){
            ans += (char)(idx + 'a');
        }  

        int pos = 1;
        for (int i = 0; i < 26; i++){
            while (bucket[i] > 0){
                ans.insert(pos, string(1, (char)(i + 'a')));
                pos += 2;
                bucket[i]--;
                if (pos > ans.size()){
                    pos = 1;
                }
            }
        }

        return ans;
    }
};