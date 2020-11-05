using System;
using System.Reflection.Metadata.Ecma335;
using System.Collections;
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}

public class Solution {
    Queue<int> queue = new Queue<int>();
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode pivot1 = l1;
        ListNode pivot2 = l2;
        Plus(pivot1, pivot2, false);

        var dummy = new ListNode(0);
        var j = dummy;

        while (queue.Count > 0)
        {
            j.next = new ListNode(queue.Dequeue());
            j = j.next;
        }
        return dummy.next;
    }

    private void Plus(ListNode head1, ListNode head2, bool PlusOne)
    {
        if (head1 == null && head2 == null)
        {
            if (PlusOne)
                queue.Enqueue(1);
            return;
        }
        else if (head1 == null && head2 != null)
            Left(head2, PlusOne);
        else if (head2 == null && head1 != null)
            Left(head1, PlusOne);
        else
        {
            int ans = head1.val + head2.val + Convert.ToInt32(PlusOne);
            queue.Enqueue(ans % 10);
            PlusOne = (ans / 10 == 1 ? true : false);
            Plus(head1.next, head2.next, PlusOne);
        }
    }

    private void Left(ListNode head, bool PlusOne)
    {
        int ans = head.val + Convert.ToInt32(PlusOne);
        queue.Enqueue(ans % 10);
        if (head.next == null)
        {
            if (PlusOne)
                queue.Enqueue(1);
            return;
        }
        PlusOne = ans / 10 == 1 ? true : false;
        Left(head.next, PlusOne);
    }
}