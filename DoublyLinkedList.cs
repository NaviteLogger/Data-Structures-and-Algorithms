using System;
using System.Collections.Generic;

namespace DoublyLinkedList
{
    /// <summary>Dynamic (linked) list class definition</summary>
    public class DynamicList<T>
    {
        private class ListNode
        {
            //Single element
            public T Element
            {
                get
                {
                    return this.Element;
                }
                set
                {
                    this.Element = value;
                }
            }

            //Reference to the next element of the same class
            public ListNode NextNode
            {
                get
                {
                    return this.NextNode;
                }
                set
                {
                    this.NextNode = value;
                }
            }
            
        }
    }
}
