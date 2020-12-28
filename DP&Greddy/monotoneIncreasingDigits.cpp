#include <stdc++.h>

using namespace std;

class Solution {
public:
    // 找到第一个位置i使得[0, i - 1]的数位单调递增且num[i - 1] > num[i],
    // 让低位的数字全部变成9
    int monotoneIncreasingDigits(int N) {
        string num = to_string(N);
        int length = num.size();
        int i = 1;
        while ( i < length && num[i - 1] <= num[i])
            i++;

        if (i < length){
            // 从i - 1 位开始减一
            while (i < length && num[i - 1] > num[i]){
                num[i - 1]--;
                i--;
            }
            i++;
            // 将每一位都设为9
            while (i < length)
                num[i++] = '9';
        }

        return stoi(num);
    }
};