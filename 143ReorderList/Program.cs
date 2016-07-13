using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _143ReorderList
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            ListNode temp = head;
            for (int i = 0; i < 4; i++)
            {
                temp.next = new ListNode(i + 2);
                temp = temp.next;
            }

            Solution.ReorderList2(head);


            while (head != null)
            {
                Console.WriteLine(head.val);
                head = head.next;
            }
            Console.ReadKey();
        }
    }



    //节点的声明
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    //工作类
    public class Solution
    {
        //自己的麻烦办法
        public static void ReorderList(ListNode head)
        {
            List<ListNode> list = new List<ListNode>();
            int count = 0;
            while (head != null)
            {
                list.Add(head);
                head = head.next;
                count++;
            }
            head = list[0];
            int i = 0;
            for (i = 0; i < count / 2; i++)
            {
                head = list[i];
                head.next = list[count - i - 1];
                list[count - i - 1].next = list[i + 1];
            }
            list[i].next = null;
            head = list[0];
        }

        //借鉴的简单办法
        public static void ReorderList2(ListNode head)
        {
            if (head == null || head.next == null || head.next.next == null)
                return;
            if (head.next.next.next == null)
            {
                ListNode temptt = head.next;
                head.next = head.next.next;
                head.next.next = temptt;
                head.next.next.next = null;
                return;
            }
            //找到中间结点
            ListNode t1 = head;
            ListNode t2 = head;
            while (t2.next!=null&&t2.next.next != null)
            {
                t1 = t1.next;
                t2 = t2.next.next;
            }
            bool flag = t2.next == null ? true : false;
            //从t1.next开始就为后半段（不大于整段的1/2），需要反转
            ListNode now = t1.next.next;
            ListNode after = now.next;
            now.next = t1.next;
            ListNode temp = t1;
            //偶数个
            if (!flag)
            {
                t1.next.next = null;
            }
            //奇数个
            else
            {
                t1.next = null;
                now.next.next = t1;
            }
            while (after != null)
            {
                temp = after.next;
                after.next = now;
                now = after;
                after = temp;
            }

            //合并
            t1 = head;
            t2 = head;
            flag = true;
            while (t1.next != null)
            {
                if (flag)
                {
                    temp = t1.next;
                    t1.next = now;
                    t1 = now;
                    now = now.next;
                    flag = !flag;
                }
                else
                {
                    t1.next = temp;
                    t2 = temp;
                    t1 = t1.next;
                    flag = !flag;
                }
            }
        }
    }
}
