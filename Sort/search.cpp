#include <stdc++.h>

using namespace std;

class Solution {
public:
    // 旋转一次和旋转n次没有区别

    /*
    循环体内有2个分支
    在循环体外返回目标索引，在循环体内缩减搜索区间
    此时left < right 且 right = mid
    */

    /*
    循环体内有三个分支
    在循环体中返回目标索引
    此时 left <= right 且 right = mid - 1
    */
    int search(vector<int>& arr, int target) {
        int len = arr.size();
        int left = 0, right = len - 1;
        while (left < right){
            int mid = left + (right - left) / 2;
            if (arr[left] == target)
                return left;
            else if (arr[mid] == target)
                right = mid;
            else if (arr[mid] == arr[right])
                --right;
            // 证明[mid, right]单调递增
            else if (arr[mid] < arr[right]){
                if (arr[mid] < target && target <= arr[right])
                    left = mid + 1;
                else
                    right = mid;
            // 证明[mid, right]并非单调递增，即旋转点在[mid, right]中
            }else{
                if (arr[mid] >= target && target >= arr[left])
                    right = mid;
                else
                    left = mid + 1;
            }
        }

        return arr[left] == target ? left : -1;
    }
};