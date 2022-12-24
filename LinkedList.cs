using System;
using System.Collections.Generic;
using List;

namespace DoublyLinkedList
{
    /// <summary>Dynamic (linked) list class definition</summary>
    public class LinkedList<T> : System.Collections.Generic.LinkedList<T>
    {
        //all necessary elements will be inherited from System.Collections.Generic.LinkedList<T>

        public LinkedList()
        {
        }

        public LinkedList(IEnumerable<T> collection) : base(collection)
        {
        }

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public void AddLast(T element)
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        {
            _ = base.AddLast(element);
        }

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public void AddFirst(T element)
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        {
            _ = base.AddFirst(element);
        }

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public void RemoveLast()
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        {
            base.RemoveLast();
        }

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public void RemoveFirst()
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        {
            base.RemoveFirst();
        }

        public T GetLast()
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return base.Last.Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        public T GetFirst()
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return base.First.Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        public bool IsEmpty()
        {
            return base.Count == 0;
        }

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public int Count()
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        {
            return base.Count;
        }
        
    }
}