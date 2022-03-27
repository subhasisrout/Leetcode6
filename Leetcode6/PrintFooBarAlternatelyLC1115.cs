using System;
using System.Threading;

// #RememberPattern
// #ThreadSynchronization
// #ThreadSignalling
// #AutoResetEvent
// #SimilarToLC1114

namespace Leetcode
{
    public class PrintFooBarAlternatelyLC1115
    {
        private int n;
        static AutoResetEvent fooResetEvent = new AutoResetEvent(true);
        static AutoResetEvent barResetEvent = new AutoResetEvent(false);

        public PrintFooBarAlternatelyLC1115(int n)
        {
            this.n = n;
        }

        public void Foo(Action printFoo)
        {

            for (int i = 0; i < n; i++)
            {

                // printFoo() outputs "foo". Do not change or remove this line.
                fooResetEvent.WaitOne(); //meaning it KEEPS ON WAITING unless SOMEOTHER thread SETS it. 
                // In this case, the MAIN THREAD initially SETS it. (See constructor)
                // The subsequent SETs are done by Thread2 (printBar)
                printFoo();
                barResetEvent.Set();
            }
        }

        public void Bar(Action printBar)
        {

            for (int i = 0; i < n; i++)
            {

                // printBar() outputs "bar". Do not change or remove this line. 
                barResetEvent.WaitOne();
                printBar();
                fooResetEvent.Set();
            }
        }
    }
}
