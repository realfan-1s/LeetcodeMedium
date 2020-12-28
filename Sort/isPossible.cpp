#include <stdc++.h>

using namespace std;
// 桶排序 + 贪心,贪心在每次数量下降的地方结束
class Solution1 {
public:
    bool isPossible(vector<int>& nums) {
        int maxVal = nums.back();
        int minVal = nums.front();
        vector<int> bucket(maxVal - minVal + 1, 0);
        for (int num : nums)
            ++bucket[num - minVal];

        int cur = 0;
        while (cur < bucket.size()){
            int ptr = cur + 1;
            // 贪心
            while (ptr < bucket.size() && bucket[ptr - 1] <= bucket[ptr])
                ptr++;

            // 如结果不满足题意
            if (ptr - cur < 3)
                return false;
            while (--ptr >= cur){
                bucket[ptr]--;
            }
            while (cur < bucket.size() && !bucket[cur])
                cur++;
        }
        return true;
    }
};

// 最小堆+哈希表
class Solution2 {
public:
    bool isPossible(vector<int>& nums) {
        // 如存在子序列以x - 1结尾且长度为k，则加入x；否则新建仅包含x的子序列
        // 显然应该让最短的子序列尽可能长，因此应该将 xx 加入其中最短的子序列。
        unordered_map<int, priority_queue<int, vector<int>, greater<int>>> tmp;
        for (auto& num : nums){
            // 未找到
            if (tmp.find(num) == tmp.end()){
                tmp[num] = priority_queue<int, vector<int>, greater<int>>();
            }
            // x - 1可以找到
            if (tmp.find(num - 1) != tmp.end()){
                int currentLen = tmp[num - 1].top();
                tmp[num - 1].pop();
                // 对应x - 1长度的堆仅有一个
                if (tmp[num - 1].empty())
                    tmp.erase(num - 1);
                tmp[num].push(currentLen + 1);
            }else{
                tmp[num].push(1);
            }
        }

        for (auto i = tmp.begin(); i != tmp.end(); i++){
            auto heap = i->second;
            if (heap.top() < 3)
                return false;
        }
        return true;
    }
};