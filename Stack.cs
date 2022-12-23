using System;
using System.Collections.Generic;

namespace Stack
{
    public class Stack<T> : System.Collections.Generic.Stack<T>
    {
        //all necessary elements will be inherited from System.Collections.Generic.Stack<T>

        //constructor
        public Stack()
        {
        }

        //constructor
        public Stack(IEnumerable<T> collection) : base(collection)
        {
        }

        //constructor
        public Stack(int capacity) : base(capacity)
        {
        }

        //method for adding element to the stack
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public void Push(T element)
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        {
            base.Push(element);
        }

        //method for removing element from the stack
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public T Pop()
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        {
            return base.Pop();
        }

        //method for getting the top element of the stack
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public T Peek()
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        {
            return base.Peek();
        }

        //method for checking if the stack is empty
        public bool IsEmpty()
        {
            return base.Count == 0;
        }

        //method for getting the number of elements in the stack
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public int Count()
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        {
            return base.Count;
        }

        //method for printing the stack
        public void Print()
        {
            foreach (var element in base.ToArray())
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }

        //method for clearing the stack
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public void Clear()
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        {
            base.Clear();
        }

        //method for converting the stack to array
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public T[] ToArray()
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        {
            return base.ToArray();
        }

        //method for converting the stack to list
        public List<T> ToList()
        {
            return new List<T>(base.ToArray());
        }

        //method for converting the stack to string
        public override string ToString()
        {
            return string.Join(" ", base.ToArray());
        }

        //method for converting the stack to string
        public string ToString(string separator)
        {
            return string.Join(separator, base.ToArray());
        }

        //method for converting the stack to string
        public string ToString(string separator, string format)
        {
            return string.Join(separator, base.ToArray());
        }

        //method for converting the stack to string
        public string ToString(string separator, string format, IFormatProvider provider)
        {
            return string.Join(separator, base.ToArray());
        }

        //method for converting the stack to string
        public string ToString(IFormatProvider provider)
        {
            return string.Join(" ", base.ToArray());
        }

        //method for converting the stack to string
        public string ToString(string format, IFormatProvider provider)
        {
            return string.Join(" ", base.ToArray());
        }

        //method for converting the stack to string
        public string ToStringWithSeparator(string format, string separator)
        {
            return string.Join(separator, base.ToArray());
        }
    }
}