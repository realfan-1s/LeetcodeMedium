// 暴力解法, 时间复杂度降低为线性,倘若从i走到j失败了，则从i+1,i+2,...走到jdou'hui'o
public class solution
{
    int CompleteCircuit(int[] gas, int[] cost)
    {
        int length = gas.Length;
        for (int i = 0; i < length; i += j + 1)
        {
            int gasLeft = 0;
            for (int j = 0; j < length; j++)
            {
                // 判断当前加油站的位置
                int k = (i + j) % length;
                gasLeft = gasLeft + gas[k] - cost[k];
                if (gasLeft < 0)
                    break;
            }
            if (j >= length)
                return i;
        }
        return -1;
    }
}