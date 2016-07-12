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
            for (int i = 0; i < 100; i++)
            {
                temp.next = new ListNode(i + 2);
                temp = temp.next;
            }

            Solution.ReorderList(head);


            while (head!=null)
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
                head.next = list[count - i-1];
                list[count - i-1].next = list[i + 1];
            }
            list[i].next = null;            
            head = list[0];
        }
    }
}
