using System;
using System.Collections.Generic;

namespace BinaryTree
{
    /// <summary>Represents a binary tree</summary>
    /// <typeparam name="T">Type of values in the tree</typeparam>
    public class BinaryTree<T>
    {
        /// <summary>The value stored in the curent node</summary>
        public T Value { get; set; }
        /// <summary>The left child of the current node</summary>
        public BinaryTree<T> LeftChild { get; private set; }
        /// <summary>The right child of the current node</summary>
        public BinaryTree<T> RightChild { get; private set; }
        /// <summary>Constructs a binary tree</summary>
        /// <param name="value">the value of the tree node</param>
        /// <param name="leftChild">the left child of the tree</param>
        /// <param name="rightChild">the right child of the tree
        /// </param>
        public BinaryTree(T value,
        BinaryTree<T> leftChild, BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }
        /// <summary>Constructs a binary tree with no children
        /// </summary>
        /// <param name="value">the value of the tree node</param>
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        public BinaryTree(T value) : this(value, null, null)
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        {
        }
        /// <summary>Traverses the binary tree in pre-order</summary>
        public void PrintInOrder()
        {
            // 1. Visit the left child
            if (this.LeftChild != null)
            {
                this.LeftChild.PrintInOrder();
            }
            // 2. Visit the root of this sub-tree
            Console.Write(this.Value + " ");
            // 3. Visit the right child
            if (this.RightChild != null)
            {
                this.RightChild.PrintInOrder();
            }
        }

        /// <summary>Traverses the binary tree in pre-order</summary>       
        public void PrintPreOrder()
        {
            // 1. Visit the root of this sub-tree
            Console.Write(this.Value + " ");
            // 2. Visit the left child
            if (this.LeftChild != null)
            {
                this.LeftChild.PrintPreOrder();
            }
            // 3. Visit the right child
            if (this.RightChild != null)
            {
                this.RightChild.PrintPreOrder();
            }
        }

        /// <summary>Traverses the binary tree in post-order</summary>
        public void PrintPostOrder()
        {
            // 1. Visit the left child
            if (this.LeftChild != null)
            {
                this.LeftChild.PrintPostOrder();
            }
            // 2. Visit the right child
            if (this.RightChild != null)
            {
                this.RightChild.PrintPostOrder();
            }
            // 3. Visit the root of this sub-tree
            Console.Write(this.Value + " ");
        }

        /// <summary>Traverses the binary tree in breadth-first
        /// search (BFS) manner</summary>
        public void PrintBFS()
        {
            Queue<BinaryTree<T>> queue = new Queue<BinaryTree<T>>();
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                BinaryTree<T> current = queue.Dequeue();
                Console.Write(current.Value + " ");
                if (current.LeftChild != null)
                {
                    queue.Enqueue(current.LeftChild);
                }
                if (current.RightChild != null)
                {
                    queue.Enqueue(current.RightChild);
                }
            }
        }

        /// <summary>Traverses the binary tree in depth-first
        /// search (DFS) manner</summary>
        public void PrintDFS()
        {
            Stack<BinaryTree<T>> stack = new Stack<BinaryTree<T>>();
            stack.Push(this);
            while (stack.Count > 0)
            {
                BinaryTree<T> current = stack.Pop();
                Console.Write(current.Value + " ");
                if (current.RightChild != null)
                {
                    stack.Push(current.RightChild);
                }
                if (current.LeftChild != null)
                {
                    stack.Push(current.LeftChild);
                }
            }
        }

        /// <summary>Traverses the binary tree in DFS manner
        /// using recursion</summary>
        private void PrintDFSRecursive(Stack<BinaryTree<T>> stack)
        {
            if (stack.Count == 0)
            {
                return;
            }
            BinaryTree<T> current = stack.Pop();
            Console.Write(current.Value + " ");
            if (current.RightChild != null)
            {
                stack.Push(current.RightChild);
            }
            if (current.LeftChild != null)
            {
                stack.Push(current.LeftChild);
            }
            this.PrintDFSRecursive(stack);
        }

        /// <summary>Represents a binary tree node</summary>
        /// <typeparam name="T">Specifies the type for the values
        /// in the nodes</typeparam>
#pragma warning disable CS0693 // Type parameter has the same name as the type parameter from outer type
        public class BinaryTreeNode<T> : IComparable<BinaryTreeNode<T>> where T : IComparable<T>
#pragma warning restore CS0693 // Type parameter has the same name as the type parameter from outer type
        {
            // Contains the value of the node
            internal T value;
            // Contains the parent of the node
            internal BinaryTreeNode<T> parent;
            // Contains the left child of the node
            internal BinaryTreeNode<T> leftChild;
            // Contains the right child of the node
            internal BinaryTreeNode<T> rightChild;
            /// <summary>Constructs the tree node</summary>
            /// <param name="value">The value of the tree node</param>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            public BinaryTreeNode(T value)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            {
                if (value == null)
                {
                    // Null values cannot be compared -> do not allow them
                    throw new ArgumentNullException(
                    "Cannot insert null value!");
                }
                this.value = value;
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                this.parent = null;
                this.leftChild = null;
                this.rightChild = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            }
            public override string ToString()
            {
#pragma warning disable CS8603 // Possible null reference return.
                return value.ToString();
#pragma warning restore CS8603 // Possible null reference return.
            }
            public override int GetHashCode()
            {
                return this.value.GetHashCode();
            }
#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
            public override bool Equals(object obj)
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
            {
                BinaryTreeNode<T> other = (BinaryTreeNode<T>)obj;
                return this.CompareTo(other) == 0;
            }
#pragma warning disable CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
            public int CompareTo(BinaryTreeNode<T> other)
#pragma warning restore CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
            {
                return this.value.CompareTo(other.value);
            }
        }
    }
}
