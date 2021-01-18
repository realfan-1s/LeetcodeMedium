#include <stdc++.h>

using namespace std;

class LRUCache {
public:
    deque<pair<int, int>> cache;
    int size = 0;
    LRUCache(int capacity) {
        size = capacity;
    }

    int get(int key) {
        for (auto i = cache.begin(); i < cache.end(); ++i){
            if (i->first == key){
                int ans = i->second;
                cache.erase(i);
                cache.push_back(make_pair(key, ans));
                return ans;
            }
        }
        return -1;
    }

    void put(int key, int value) {
        for (auto i = cache.begin(); i < cache.end(); ++i){
            if (i->first == key){
                cache.erase(i);
                cache.push_back(make_pair(key, value));
                return;
            }
        }
        cache.push_back(make_pair(key, value));
        if (cache.size() > size)
            cache.pop_front();
    }
};