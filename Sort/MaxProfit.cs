using System.Linq.Expressions;
using System;
public class Solution {
    const int mod = 1000000007;
    public int MaxProfit(int[] inventory, int orders) {
        int length = inventory.Length;
        Array.Sort(inventory, (x, y) => -x.CompareTo(y));
        int j = 0;
        long ans = 0;
        while (orders > 0){
            while (j < length && inventory[j] >= inventory[0])
                j++;
            int next = 0;
            if (j < length)
                next = inventory[j];
            long bucks = j, delta = inventory[0] - next;
            long times = bucks * delta;
            if (times > orders){
                long rem = orders / bucks;
                long an =inventory[0] - rem + 1;
                ans += (an + inventory[0]) * rem / 2 * bucks;
                ans += (inventory[0] - rem) * (orders % bucks);
            }else{
                long an = next + 1;
                ans += (inventory[0] + an) * times / 2;
                inventory[0] = next;
            }
            orders -= (int)times;
            ans %= mod;
        }
        return (int)ans;
    }
}