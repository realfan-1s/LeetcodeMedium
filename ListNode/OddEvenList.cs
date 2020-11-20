using System.Runtime.CompilerServices;
namespace LeetCode328 {
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode (int val = 0, ListNode next = null) {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution {
        public ListNode OddEvenList (ListNode head) {
            if (head == null)
                return null;
            ListNode evenHead = head.next;
            ListNode slow = head;
            ListNode fast = evenHead;

            while (fast != null && fast.next != null) {
                slow.next = fast.next;
                slow = slow.next;
                fast.next = slow.next;
                fast = fast.next;
            }
            slow.next = evenHead;
            return head;
            head
        }
    }
}