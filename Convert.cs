using System.Collections;
using System.Text;
public class Solution {
    public string Convert (string s, int numRows) {
        if (numRows == 1)
            return s;

        int length = s.Length;
        List<StringBuilder> aList = new List<StringBuilder> ();
        for (int i = 0; i < numRows; i++)
            aList.Add (new StringBuilder ());

        int cur = 0;
        bool turnDir = false;
        for (var i = 0; i < length; i++) {
            aList[cur].Append (s[i]);
            if (cur == 0 || cur == numRows - 1)
                turnDir = !turnDir;
            cur += (turnDir ? 1 : -1);
        }

        StringBuilder ans = new StringBuilder ();
        for (int i = 0; i < numRows; i++)
            ans.Append (aList[i]);

        return ans.ToString ();
    }
}