using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/remove-duplicates-from-sorted-list/description/
namespace _083RemoveDuplicatesfromSortedList
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
                return head;
            ListNode tmp1 = head, tmp2 = head.next;
            while (tmp2 != null)
            {
                if (tmp1.val == tmp2.val)
                {
                    tmp1.next = tmp2.next;
                    tmp2 = tmp2.next;
                    continue;
                }
                tmp1 = tmp2;
                tmp2 = tmp2.next;
            }
            return head;
        }
        static ListNode DeleteDuplicates2(ListNode head)
        {
            ListNode tmp = head;
            while (head != null && head.next != null)
                if (head.val == head.next.val)
                    head.next = head.next.next;
                else
                    head = head.next;
            return tmp;
        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
