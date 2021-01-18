#include <stdc++.h>

using namespace std;

class Solution {
public:
    vector<int> findClosedNumbers(int num) {
        bitset<32> small(num);
        bitset<32> big(num);
        int smallNum = -1, bigNum = -1;

        for (int i = 1; i < 32; ++i){
            if (small[i] == 1 && small[i - 1] == 0){
                small.flip(i);
                small.flip(i - 1);

                int left = 0, right = i - 2;
                while (left < right){
                    while (left < right && small[left] == 0)    ++left;
                    while (left < right && small[right] == 1)   --right;
                    small.flip(left);
                    small.flip(right);
                }
                smallNum = (int)small.to_ulong();
                break;
            }
        }

        for (int i = 1; i < 32; ++i){
            if (big[i] == 1 && big[i - 1] == 0){
                big.flip(i);
                big.flip(i - 1);

                int left = 0, right = i - 2;
                while (left < right){
                    while (left < right && big[left] == 0)    ++left;
                    while (left < right && big[right] == 1)   --right;
                    big.flip(left);
                    big.flip(right);
                }
                bigNum = (int)big.to_ulong();
                break;
            }
        }


        return {smallNum, bigNum};
    }
};