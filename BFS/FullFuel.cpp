#include <iostream>
#include <algorithm>
#include <cstring>
#include <queue>
#include <cstdio>

using namespace std;

const int N = 1010, M = 20010, C = 110;

int n, m;
int price[N], dist[N][C];          // p 存每个点上的油价，dist 存到每个被拆的点的最低油钱
int h[N], w[M], e[M], ne[M], indx; // 存图
bool st[N][C];

struct Ver
{
    int d, u, c;
    bool operator<(const Ver &t) const
    {
        return d > t.d;
    }
};

void add(int a, int b, int c)
{
    e[++indx] = b;
    w[indx] = c;
    ne[indx] = h[a];
    h[a] = indx;
}

inline int Dijstra(int contain, int start, int end)
{
    priority_queue<Ver> heap;
    memset(dist, 0x3f, sizeof dist);
    memset(st, false, sizeof st);
    heap.push({0, start, 0});
    // 到达该点油钱初始化为0
    dist[start][0] = 0;

    while (heap.size())
    {
        auto t = heap.top();
        heap.pop();

        if (t.u == end)
            return t.d;

        if (st[t.u][t.c])
            continue;
        st[t.u][t.c] = true;

        if (t.c < contain)
        {
            if (dist[t.u][t.c + 1] > t.d + price[t.u])
            {
                dist[t.u][t.c + 1] = t.d + price[t.u];
                heap.push({dist[t.u][t.c + 1], t.u, t.c + 1});
            }
        }

        for (int i = h[t.u]; i; i = ne[i])
        {
            if (t.c >= w[i])
            {
                if (dist[e[i]][t.c - w[i]] > t.d)
                {
                    dist[e[i]][t.c - w[i]] = t.d;
                    heap.push({t.d, e[i], t.c - w[i]});
                }
            }
        }
    }
    return -1;
}

int main()
{
    scanf("%d%d", &n, &m);
    for (int i = 0; i < n; i++)
        scanf("%d", &price[i]);

    // 由于是无向边，必须创建两遍
    while (m--)
    {
        int a, b, c;
        scanf("%d%d%d", &a, &b, &c);
        add(a, b, c);
        add(b, a, c);
    }

    int query;
    scanf("%d", &query);
    while (query--)
    {
        int contian, start, end;
        scanf("%d%d%d", &contian, &start, &end);
        int t = Dijstra(contian, start, end);
        if (t == -1)
            puts("impossible");
        else
            printf("%d\n", t);
    }

    return 0;
}