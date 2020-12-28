#include <stdc++.h>

using namespace std;

// 双端队列维护最大值
class MaxQueue {
public:
    queue<int> queue_Contains;
    deque<int> maxDeque;
    MaxQueue() {

    }

    int max_value() {
        if (maxDeque.empty())
            return -1;
        return maxDeque.front();
    }

    void push_back(int value) {
        while (!maxDeque.empty() && maxDeque.back() < value)
            maxDeque.pop_back();
        maxDeque.emplace_back(value);
        queue_Contains.emplace(value);
    }

    int pop_front() {
        if (queue_Contains.empty())
            return -1;
        int ans = queue_Contains.front();
        if (ans == maxDeque.front())
            maxDeque.pop_front();
        queue_Contains.pop();
        return ans;
    }
};
