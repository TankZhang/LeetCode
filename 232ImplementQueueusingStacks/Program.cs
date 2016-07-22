using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/implement-queue-using-stacks/
namespace _232ImplementQueueusingStacks
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Queue
    {
        // Push element x to the back of queue.
        public void Push(int x)
        {
            while (sb.Count >0)
                sa.Push(sb.Pop());
            sa.Push(x);
            while (sa.Count > 0)
                sb.Push(sa.Pop());
        }

        // Removes the element from front of queue.
        public void Pop()
        {
            if (sb.Count > 0)
                sb.Pop();
        }

        // Get the front element.
        public int Peek()
        {
            return sb.Peek();
        }

        // Return whether the queue is empty.
        public bool Empty()
        {
            return sb.Count > 0 ? false : true;
        }
        Stack<int> sa = new Stack<int>();
        Stack<int> sb = new Stack<int>();
    }
}
