using System.Collections.Generic;
using System.Linq;

// Note LinkedList<int> can be effectively used as a Deque (Deck or Double ended queue)

namespace Leetcode
{
    
    public class ImplementStackUsing2QueuesLC225
    {
        //2 queues approach
        public class MyStack
        {
            private Queue<int> mainQ;
            private Queue<int> tempQ;
            public MyStack()
            {
                mainQ = new Queue<int>();
                tempQ = new Queue<int>();
            }

            public void Push(int x)
            {
                //copy mainQ to tempQ 
                tempQ = new Queue<int>();
                while (mainQ.Count != 0)
                {
                    tempQ.Enqueue(mainQ.Dequeue());
                }
                
                // stack push equivalent
                mainQ.Enqueue(x);

                //copy tempQ back to mainQ
                while (tempQ.Count != 0)
                {
                    mainQ.Enqueue(tempQ.Dequeue());
                }
                
                //The above 3 operation rearranges stuff as required in a stack.
            }

            public int Pop()
            {
                return mainQ.Dequeue();
            }

            public int Top()
            {
                return mainQ.Peek();
            }

            public bool Empty()
            {
                return mainQ.Count == 0;
            }
        }

        ////1 queue approach
        public class MyStack2
        {
            private LinkedList<int> mainQ;
            public MyStack2()
            {
                mainQ = new LinkedList<int>();
            }

            public void Push(int x)
            {
                mainQ.AddLast(x);
            }

            public int Pop()
            {
                var x = mainQ.Last();
                mainQ.RemoveLast();
                return x;
            }

            public int Top()
            {
                return mainQ.Last();
            }

            public bool Empty()
            {
                return mainQ.Count == 0;
            }
        }
    }
}
