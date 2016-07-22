using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
namespace _225ImplementStackusingQueues
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Stack
    {
        // Push element x onto stack.
        public void Push(int x)
        {
            qa.Enqueue(x);
            while (qb.Count > 0)
                qa.Enqueue(qb.Dequeue());
            while (qa.Count > 0)
                qb.Enqueue(qa.Dequeue());
        }

        // Removes the element on top of the stack.
        public void Pop()
        {
            qb.Dequeue();
        }

        // Get the top element.
        public int Top()
        {
            return qb.Peek();
        }

        // Return whether the stack is empty.
        public bool Empty()
        {
            return qb.Count > 0 ? false : true;
        }

        Queue<int> qa = new Queue<int>();
        Queue<int> qb = new Queue<int>();
    }
}
