#include <stdc++.h>

using namespace std;

class Solution {
public:
    int length;
    vector<int> searchRange(vector<int>& nums, int target) {
        length = nums.size();
        int left = BinarySearch(nums, target, true);
        int right = BinarySearch(nums, target, false) - 1;
        if (left <= right && right < length && nums[left] == target && nums[right] == target)
            return vector<int>{left, right};
        return vector<int>{-1, -1};
    }
    int BinarySearch(vector<int>& nums, int target, bool lower){
        int left = 0;
        int right = length - 1;
        int ans = length;
        while (left <= right){
            int mid = right + (left - right) / 2;
            if (nums[mid] > target || (lower && nums[mid] >= target)){
                right = mid - 1;
                ans = mid;
            }else
                left = mid + 1;
        }
        return ans;
    }
};