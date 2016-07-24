using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/linked-list-cycle/
namespace _141LinkedListCycle
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = head.next;
            Console.WriteLine(HasCycle2(head));
            Console.ReadKey();
        }

       static bool HasCycle(ListNode head)
        {
            HashSet<ListNode> h = new HashSet<ListNode>();
            while (head != null)
            {
                if (h.Contains(head))
                    return true;
                h.Add(head);
                head = head.next;
            }
            return false;
        }

        static bool HasCycle2(ListNode head)
        {
            if (head == null || head.next == null) return false;
            ListNode fast = head.next.next;
            ListNode slow = head.next;
            while(fast!=slow)
            {
                if (fast == null || fast.next == null) return false;
                fast = fast.next.next;
                slow = slow.next;
            }
            return true;
        }
    }


    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }
}
