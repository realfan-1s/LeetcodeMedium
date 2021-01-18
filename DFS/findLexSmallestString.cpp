#include <stdc++.h>

using namespace std;

/*
暴力枚举
在不进行轮转的情况下，只有奇数位上的数字可以修改
倘若轮转位是奇数，则也可以通过先轮转在修改的方式改变偶数位置上的数
每一位上的数字最多累加10次，因为每次只取个位数，余数范围是0-9
经过若干次(最多 s.size() 次)轮转操作后，s也会回到初始状态。
*/
class Solution1 {
public:
    string findLexSmallestString(string s, int a, int b) {
        string ans = s;
        int len = s.size();

        for (int i = 0; i < len + 1; ++i){
            // 轮转
            s = s.substr(b, len) + s.substr(0, b);
            // 奇数位一定可以修改
            for (int m = 0; m < 10; ++m){
                for (int n = 1; n < len; n += 2){
                    s[n] = (s[n] - '0' + a) % 10 + '0';
                }

                // 若轮转数为奇，可以修改偶数位
                if (b % 2 == 1){
                    for (int m = 0; m < 10; ++m){
                        for (int n = 0; n < len; n += 2){
                            s[n] = (s[n] - '0' + a) % 10 + '0';
                        }
                        ans = min(ans, s);
                    }
                } else{
                    ans = min(ans, s);
                }
            }
        }

        return ans;
    }
};

// 裴蜀定理剪枝:若a,b是整数,且gcd(a,b)=d，那么对于任意的整数x,y,ax+by都一定是d的倍数，特别地，一定存在整数x,y，使ax+by=d成立。
// 每一次轮转之后，一定要让s[1]达到最小，若轮转数位奇，s[0]也要最小
class Solution2 {
private:
    int gcd(int x, int y){
        return y == 0 ? x : gcd(y, x % y);
    }
public:
    string findLexSmallestString(string s, int a, int b) {
        int len = s.size();
        string ans = s;
        // 用于轮转的工具字符串
        string tool = s + s;
        int ga = gcd(10, a), gb = gcd(len, b);

        auto add = [&] (string& p, int pos){
            int added = 0, curr = p[pos] - '0';

            for (int i = ga; i < 10; i += ga){
                int num = (p[pos] - '0' + i) % 10;
                if (num < curr){
                    curr = num;
                    added = i;
                }
            }

            if (added)
                for (int i = pos; i < len; i += 2)
                    p[i] = (p[i] - '0' + added) % 10 + '0';
        };

        //轮转
        for (int i = 0; i < len; i += gb){
            string temp = tool.substr(i, len);
            add(temp, 1);
            if (gb % 2 == 1)
                add(temp, 0);

            ans = min(ans, temp);
        }

        return ans;
    }
};