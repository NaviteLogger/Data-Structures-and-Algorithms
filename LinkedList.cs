using System;

namespace LinkedList
{

    /// <summary>Linked (linked) list class definition</summary>
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

            public ListNode(T element)
            {
                this.Element = element;
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                NextNode = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            }

            public ListNode(T element, ListNode previousNode)
            {
                this.Element = element;
                previousNode.NextNode = this;
            }
        }
        private ListNode? head; //pointer to the first element
        private ListNode? tail; //pointer to the last element
        private int count;     //number of elements

        //Constructor with default values
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DynamicList()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        /// <summary>Add element at the end of the list</summary>
        /// <param name="item">The element to be added</param>
        public void Add(T item)
        {
            if (this.head == null)
            {
                // We have an empty list -> create a new head and tail
                this.head = new ListNode(item);
                this.tail = this.head;
            }
            else
            {
                // We have a non-empty list -> append the item after tail
#pragma warning disable CS8604 // Possible null reference argument.
                ListNode newNode = new ListNode(item, this.tail);
#pragma warning restore CS8604 // Possible null reference argument.
                this.tail = newNode;
            }
            this.count++;
        }

        /// <summary>Removes and returns element on the specified index
        /// </summary>
        /// <param name="index">The index of the element to be removed
        /// </param>
        /// <returns>The removed element</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// if the index is invalid</exception>
        public T RemoveAt(int index)
        {
            if (index >= count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid index: " + index);
            }
            // Find the element at the specified index
            int currentIndex = 0;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ListNode currentNode = this.head;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            ListNode? prevNode = null;
            while (currentIndex < index)
            {
                prevNode = currentNode;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                currentNode = currentNode.NextNode;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                currentIndex++;
            }
            // Remove the found element from the list of nodes
#pragma warning disable CS8604 // Possible null reference argument.
            RemoveListNode(currentNode, prevNode);
#pragma warning restore CS8604 // Possible null reference argument.
            // Return the removed element
            return currentNode.Element;
        }
        /// <summary>
        /// Remove the specified node from the list of nodes
        /// </summary>
        /// <param name="node">the node for removal</param>
        /// <param name="prevNode">the predecessor of node</param>
        private void RemoveListNode(ListNode node, ListNode prevNode)
        {
            count--;
            if (count == 0)
            {
                // The list becomes empty -> remove head and tail
                this.head = null;
                this.tail = null;
            }
            else if (prevNode == null)
            {
                // The head node was removed --> update the head
                this.head = node.NextNode;
            }
            else
            {
                // Redirect the pointers to skip the removed node
                prevNode.NextNode = node.NextNode;
            }
            // Fix the tail in case it was removed
            if (object.ReferenceEquals(this.tail, node))
            {
                this.tail = prevNode;
            }
        }

        /// <summary>Searches for given element in the list</summary>
        /// <param name="item">The item to be searched</param>
        /// <returns>
        /// The index of the first occurrence of the element
        /// in the list or -1 when it is not found
        /// </returns>
        public int IndexOf(T item)
        {
            int index = 0;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ListNode currentNode = this.head;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            while (currentNode != null)
            {
                if (object.Equals(currentNode.Element, item))
                {
                    return index;
                }
                currentNode = currentNode.NextNode;
                index++;
            }
            return -1;
        }

        /// <summary>
        /// Checks if the specified element exists in the list
        /// </summary>
        /// <param name="item">The item to be checked</param>
        /// <returns>
        /// True if the element exists or false otherwise
        /// </returns>
        public bool Contains(T item)
        {
            int index = IndexOf(item);
            bool found = (index != -1);
            return found;
        }

        /// <summary>
        /// Gets or sets the element at the specified position
        /// </summary>
        /// <param name="index">
        /// The position of the element [0 … count-1]
        /// </param>
        /// <returns>The item at the specified index</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// When an invalid index is specified
        /// </exception>
        public T this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                {
                    throw new ArgumentOutOfRangeException(
                    "Invalid index: " + index);
                }
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                ListNode currentNode = this.head;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                for (int i = 0; i < index; i++)
                {
#pragma warning disable CS8602 //Dereferencing a possibly null reference.
                    currentNode = currentNode.NextNode;
#pragma warning restore CS8602 //Dereferencing a possibly null reference.              
                }
#pragma warning disable CS8602 //Dereferencing a possibly null reference.
                return currentNode.Element;
#pragma warning restore CS8602 //Dereferencing a possibly null reference.
            }
            set
            {
                if (index >= count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                ListNode currentNode = this.head;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                for (int i = 0; i < index; i++)
                {
#pragma warning disable CS8602 //Dereferencing a possibly null reference.
                    currentNode = currentNode.NextNode;
#pragma warning restore CS8602 //Dereferencing a possibly null reference.
                }
#pragma warning disable CS8602 //Dereferencing a possibly null reference.
                currentNode.Element = value;
#pragma warning restore CS8602 //Dereferencing a possibly null reference.
            }
        }
        /// <summary>
        /// Gets the count of elements in the list
        /// </summary>
        public int Count
        {
            get
            {
                return this.count;
            }
        }
    }
}