using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// Represents a binary tree node
        /// </summary>
        /// <typeparam name="T">The type of the nodes</typeparam>
#pragma warning disable CS0693 // Type parameter has the same name as the type parameter from outer type
        public class BinaryTreeNode<T> : IComparable<BinaryTreeNode<T>> where T : IComparable<T>
#pragma warning restore CS0693 // Type parameter has the same name as the type parameter from outer type
        {
            // Contains the value of the node
            private T value;
            // Contains the left child of the node
            private BinaryTreeNode<T> leftChild;
            // Contains the right child of the node
            private BinaryTreeNode<T> rightChild;
            /// <summary>Constructs a binary tree node</summary>
            /// <param name="value">the value of the node</param>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            public BinaryTreeNode(T value)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Cannot insert null value!");
                }
                this.value = value;
            }
            /// <summary>The value of the node</summary>
            public T Value
            {
                get
                {
                    return this.value;
                }
                set
                {
                    this.value = value;
                }
            }
            /// <summary>The left child of the node</summary>
            public BinaryTreeNode<T> LeftChild
            {
                get
                {
                    return this.leftChild;
                }
                set
                {
                    this.leftChild = value;
                }
            }
            /// <summary>The right child of the node</summary>
            public BinaryTreeNode<T> RightChild
            {
                get
                {
                    return this.rightChild;
                }
                set
                {
                    this.rightChild = value;
                }
            }

            public BinarySearchTree<T>.BinaryTreeNode<T> Parent 
            { 
                get; 
                internal set; 
            }

            /// <summary>Compares the current node with another node</summary>
            /// <param name="other">the other node</param>
            /// <returns>the result of the comparison</returns>
#pragma warning disable CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
            public int CompareTo(BinaryTreeNode<T> other)
#pragma warning restore CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
            {
                return this.value.CompareTo(other.value);
            }
        }
        // Contains the root of the tree
        private BinaryTreeNode<T> root;
        /// <summary>Constructs an empty binary search tree</summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public BinarySearchTree()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            this.root = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }
        /// <summary>Inserts a new value in the tree</summary>
        /// <param name="value">the value to be inserted</param>
        public void Insert(T value)
        {
            BinaryTreeNode<T> newNode = new BinaryTreeNode<T>(value);
            if (this.root == null)
            {
                this.root = newNode;
            }
            else
            {
                BinaryTreeNode<T> current = this.root;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                BinaryTreeNode<T> parent = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                while (true)
                {
                    parent = current;
                    if (value.CompareTo(current.Value) < 0)
                    {
                        current = current.LeftChild;
                        if (current == null)
                        {
                            parent.LeftChild = newNode;
                            break;
                        }
                    }
                    else
                    {
                        current = current.RightChild;
                        if (current == null)
                        {
                            parent.RightChild = newNode;
                            break;
                        }
                    }
                }
            }            
        }

        /// <summary>Checks whether the tree contains a value</summary>
        /// <param name="value">the value to be found</param>
        /// <returns>true if the value is found; otherwise false</returns>
        public bool Contains(T value)
        {
            BinaryTreeNode<T> current = this.root;
            while (current != null)
            {
                if (value.CompareTo(current.Value) < 0)
                {
                    current = current.LeftChild;
                }
                else if (value.CompareTo(current.Value) > 0)
                {
                    current = current.RightChild;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>Traverses the tree in in-order manner</summary>
        /// <returns>the in-order traversal of the tree</returns>
        public IEnumerable<T> InOrder()
        {
            if (this.root != null)
            {
                Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
                BinaryTreeNode<T> current = this.root;
                bool goLeftNext = true;
                stack.Push(current);
                while (stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        while (current.LeftChild != null)
                        {
                            stack.Push(current);
                            current = current.LeftChild;
                        }
                    }
                    yield return current.Value;
                    if (current.RightChild != null)
                    {
                        current = current.RightChild;
                        goLeftNext = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }

        /// <summary>Traverses the tree in pre-order manner</summary>
        /// <returns>the pre-order traversal of the tree</returns>
        public IEnumerable<T> PreOrder()
        {
            if (this.root != null)
            {
                Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
                stack.Push(this.root);
                while (stack.Count > 0)
                {
                    BinaryTreeNode<T> current = stack.Pop();
                    yield return current.Value;
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
        }

        /// <summary>Traverses the tree in post-order manner</summary>
        /// <returns>the post-order traversal of the tree</returns>
        public IEnumerable<T> PostOrder()
        {
            if (this.root != null)
            {
                Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
                stack.Push(this.root);
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                BinaryTreeNode<T> previous = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                while (stack.Count > 0)
                {
                    BinaryTreeNode<T> current = stack.Peek();
                    if (previous == null || previous.LeftChild == current || previous.RightChild == current)
                    {
                        if (current.LeftChild != null)
                        {
                            stack.Push(current.LeftChild);
                        }
                        else if (current.RightChild != null)
                        {
                            stack.Push(current.RightChild);
                        }
                        else
                        {
                            _ = stack.Pop();
                            yield return current.Value;
                        }
                    }
                    else if (current.LeftChild == previous)
                    {
                        if (current.RightChild != null)
                        {
                            stack.Push(current.RightChild);
                        }
                        else
                        {
                            _ = stack.Pop();
                            yield return current.Value;
                        }
                    }
                    else if (current.RightChild == previous)
                    {
                        _ = stack.Pop();
                        yield return current.Value;
                    }
                    previous = current;
                }
            }
        }

        /// <summary>Traverses the tree in breadth-first manner</summary>
        /// <returns>the breadth-first traversal of the tree</returns>
        public IEnumerable<T> BreadthFirst()
        {
            if (this.root != null)
            {
                Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
                queue.Enqueue(this.root);
                while (queue.Count > 0)
                {
                    BinaryTreeNode<T> current = queue.Dequeue();
                    yield return current.Value;
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
        }

        /// <summary>Gets the minimum value in the tree</summary>
        /// <returns>the minimum value in the tree</returns>
        public T GetMin()
        {
            BinaryTreeNode<T> current = this.root;
            if (current != null)
            {
                while (current.LeftChild != null)
                {
                    current = current.LeftChild;
                }
            }
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return current.Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        /// <summary>Gets the maximum value in the tree</summary>
        /// <returns>the maximum value in the tree</returns>
        public T GetMax()
        {
            BinaryTreeNode<T> current = this.root;
            if (current != null)
            {
                while (current.RightChild != null)
                {
                    current = current.RightChild;
                }
            }
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return current.Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        /// <summary>Removes a value from the tree</summary>
        /// <param name="value">the value to be removed</param>
        public void Remove(T value)
        {
            BinaryTreeNode<T> current = this.root;
            BinaryTreeNode<T> parent = this.root;
            bool isLeftChild = false;
            while (current.Value.CompareTo(value) != 0)
            {
                parent = current;
                if (value.CompareTo(current.Value) < 0)
                {
                    isLeftChild = true;
                    current = current.LeftChild;
                }
                else
                {
                    isLeftChild = false;
                    current = current.RightChild;
                }
                if (current == null)
                {
                    return;
                }
            }
            if (current.LeftChild == null && current.RightChild == null)
            {
                if (current == this.root)
                {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    this.root = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                }
                else if (isLeftChild)
                {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    parent.LeftChild = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                }
                else
                {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    parent.RightChild = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                }
            }
            else if (current.RightChild == null)
            {
                if (current == this.root)
                {
#pragma warning disable CS8601 // Possible null reference assignment.
                    this.root = current.LeftChild;
#pragma warning restore CS8601 // Possible null reference assignment.
                }
                else if (isLeftChild)
                {
#pragma warning disable CS8601 // Possible null reference assignment.
                    parent.LeftChild = current.LeftChild;
#pragma warning restore CS8601 // Possible null reference assignment.
                }
                else
                {
#pragma warning disable CS8601 // Possible null reference assignment.
                    parent.RightChild = current.LeftChild;
#pragma warning restore CS8601 // Possible null reference assignment.
                }
            }
            else if (current.LeftChild == null)
            {
                if (current == this.root)
                {
                    this.root = current.RightChild;
                }
                else if (isLeftChild)
                {
                    parent.LeftChild = current.RightChild;
                }
                else
                {
                    parent.RightChild = current.RightChild;
                }
            }
            else
            {
                BinaryTreeNode<T> successor = BinarySearchTree<T>.GetSuccessor(current);
                if (current == this.root)
                {
                    this.root = successor;
                }
                else if (isLeftChild)
                {
                    parent.LeftChild = successor;
                }
                else
                {
                    parent.RightChild = successor;
                }
                successor.LeftChild = current.LeftChild;
            }
        }

        /// <summary>Gets the successor of a node</summary>
        /// <param name="node">the node to get the successor of</param>
        /// <returns>the successor of the node</returns>
        private static BinaryTreeNode<T> GetSuccessor(BinaryTreeNode<T> node)
        {
            BinaryTreeNode<T> successorParent = node;
            BinaryTreeNode<T> successor = node;
            BinaryTreeNode<T> current = node.RightChild;
            while (current != null)
            {
                successorParent = successor;
                successor = current;
                current = current.LeftChild;
            }
            if (successor != node.RightChild)
            {
                successorParent.LeftChild = successor.RightChild;
                successor.RightChild = node.RightChild;
            }
            return successor;
        }

        /// <summary>Gets the height of the tree</summary>
        /// <param name="node">the node to get the height of</param>
        /// <returns>the height of the tree</returns>
        private int GetHeight(BinarySearchTree<T>.BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(this.GetHeight(node.LeftChild), this.GetHeight(node.RightChild));
            }
        }

        /// <summary>Gets the balance factor of a node</summary>
        /// <param name="node">the node to get the balance factor of</param>
        /// <returns>the balance factor of the node</returns>
        private int GetBalanceFactor(BinarySearchTree<T>.BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return this.GetHeight(node.LeftChild) - this.GetHeight(node.RightChild);
            }
        }

        /// <summary>Rotates the tree to the left</summary>
        /// <param name="node">the node to rotate the tree to the left of</param>
        /// <returns>the new root of the tree</returns>
        private static BinaryTreeNode<T> RotateLeft(BinaryTreeNode<T> node)
        {
            BinaryTreeNode<T> newRoot = node.RightChild;
            node.RightChild = newRoot.LeftChild;
            newRoot.LeftChild = node;
            return newRoot;
        }

        /// <summary>Rotates the tree to the right</summary>
        /// <param name="node">the node to rotate the tree to the right of</param>
        /// <returns>the new root of the tree</returns>
        private static BinaryTreeNode<T> RotateRight(BinaryTreeNode<T> node)
        {
            BinaryTreeNode<T> newRoot = node.LeftChild;
            node.LeftChild = newRoot.RightChild;
            newRoot.RightChild = node;
            return newRoot;
        }

        /// <summary>Rotates the tree to the left and then to the right</summary>
        /// <param name="node">the node to rotate the tree to the left and then to the right of</param>
        /// <returns>the new root of the tree</returns>
        private static BinaryTreeNode<T> RotateLeftRight(BinaryTreeNode<T> node)
        {
            node.LeftChild = BinarySearchTree<T>.RotateLeft(node.LeftChild);
            return BinarySearchTree<T>.RotateRight(node);
        }

        /// <summary>Rotates the tree to the right and then to the left</summary>
        /// <param name="node">the node to rotate the tree to the right and then to the left of</param>
        /// <returns>the new root of the tree</returns>
        private static BinaryTreeNode<T> RotateRightLeft(BinaryTreeNode<T> node)
        {
            node.RightChild = BinarySearchTree<T>.RotateRight(node.RightChild);
            return BinarySearchTree<T>.RotateLeft(node);
        }

        /// <summary>Gets the node with the minimum value</summary>
        /// <param name="node">the node to get the minimum value of</param>
        /// <returns>the node with the minimum value</returns>
        private BinaryTreeNode<T> GetMinimum(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            else if (node.LeftChild == null)
            {
                return node;
            }
            else
            {
                return this.GetMinimum(node.LeftChild);
            }
        }

        /// <summary>Gets the node with the maximum value</summary>
        /// <param name="node">the node to get the maximum value of</param>
        /// <returns>the node with the maximum value</returns>
        private BinaryTreeNode<T> GetMaximum(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            else if (node.RightChild == null)
            {
                return node;
            }
            else
            {
                return this.GetMaximum(node.RightChild);
            }
        }

        /// <summary>Gets the node with the next highest value</summary>
        /// <param name="node">the node to get the next highest value of</param>
        /// <returns>the node with the next highest value</returns>
        private BinaryTreeNode<T> GetNext(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            else if (node.RightChild != null)
            {
                return this.GetMinimum(node.RightChild);
            }
            else
            {
                BinaryTreeNode<T> current = node;
                BinaryTreeNode<T> parent = node.Parent;
                while (parent != null && current == parent.RightChild)
                {
                    current = parent;
                    parent = parent.Parent;
                }
#pragma warning disable CS8603 // Possible null reference return.
                return parent;
#pragma warning restore CS8603 // Possible null reference return.
            }
        }

        /// <summary>Gets the node with the next lowest value</summary>
        /// <param name="node">the node to get the next lowest value of</param>
        /// <returns>the node with the next lowest value</returns>
        private BinaryTreeNode<T> GetPrevious(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            else if (node.LeftChild != null)
            {
                return this.GetMaximum(node.LeftChild);
            }
            else
            {
                BinaryTreeNode<T> current = node;
                BinaryTreeNode<T> parent = node.Parent;
                while (parent != null && current == parent.LeftChild)
                {
                    current = parent;
                    parent = parent.Parent;
                }
#pragma warning disable CS8603 // Possible null reference return.
                return parent;
#pragma warning restore CS8603 // Possible null reference return.
            }
        }

        /// <summary>Gets the node with the specified value</summary>
        /// <param name="node">the node to get the specified value of</param>
        /// <param name="value">the value to get the node of</param>
        /// <returns>the node with the specified value</returns>
        private BinaryTreeNode<T> GetNode(BinaryTreeNode<T> node, T value)
        {
            if (node == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            else if (node.Value.Equals(value))
            {
                return node;
            }
            else if (node.Value.CompareTo(value) > 0)
            {
                return this.GetNode(node.LeftChild, value);
            }
            else
            {
                return this.GetNode(node.RightChild, value);
            }
        }

        /// <summary>Gets the height of the specified node</summary>
        /// <param name="node">the node to get the height of</param>
        /// <returns>the height of the specified node</returns>
        private int GetHeightOfSpecificNode(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return -1;
            }
            else
            {
                return 1 + Math.Max(this.GetHeightOfSpecificNode(node.LeftChild), this.GetHeightOfSpecificNode(node.RightChild));
            }
        }

        /// <summary>Gets the balance factor of the specified node</summary>
        /// <param name="node">the node to get the balance factor of</param>
        /// <returns>the balance factor of the specified node</returns>
        private int GetBalanceFactorOfSpecificNode(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return this.GetHeightOfSpecificNode(node.LeftChild) - this.GetHeightOfSpecificNode(node.RightChild);
            }
        }

        /// <summary>Gets the number of nodes in the tree</summary>
        /// <param name="node">the node to get the number of nodes of</param>
        /// <returns>the number of nodes in the tree</returns>
        private int GetNumberOfNodes(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return 1 + this.GetNumberOfNodes(node.LeftChild) + this.GetNumberOfNodes(node.RightChild);
            }
        }

        /// <summary>Gets the number of leaves in the tree</summary>
        /// <param name="node">the node to get the number of leaves of</param>
        /// <returns>the number of leaves in the tree</returns>
        private int GetNumberOfLeaves(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else if (node.LeftChild == null && node.RightChild == null)
            {
                return 1;
            }
            else
            {
#pragma warning disable CS8604 // Possible null reference argument.
                return this.GetNumberOfLeaves(node.LeftChild) + this.GetNumberOfLeaves(node.RightChild);
#pragma warning restore CS8604 // Possible null reference argument.
            }
        }

        /// <summary>Gets the number of full nodes in the tree</summary>
        /// <param name="node">the node to get the number of full nodes of</param>
        /// <returns>the number of full nodes in the tree</returns>
        private int GetNumberOfFullNodes(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else if (node.LeftChild != null && node.RightChild != null)
            {
                return 1 + this.GetNumberOfFullNodes(node.LeftChild) + this.GetNumberOfFullNodes(node.RightChild);
            }
            else
            {
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8604 // Possible null reference argument.
                return this.GetNumberOfFullNodes(node.LeftChild) + this.GetNumberOfFullNodes(node.RightChild);
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8604 // Possible null reference argument.
            }
        }

        /// <summary>Gets the number of half nodes in the tree</summary>
        /// <param name="node">the node to get the number of half nodes of</param>
        /// <returns>the number of half nodes in the tree</returns>
        private int GetNumberOfHalfNodes(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else if ((node.LeftChild != null && node.RightChild == null) || (node.LeftChild == null && node.RightChild != null))
            {
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8604 // Possible null reference argument.
                return 1 + this.GetNumberOfHalfNodes(node.LeftChild) + this.GetNumberOfHalfNodes(node.RightChild);
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8604 // Possible null reference argument.
            }
            else
            {
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8604 // Possible null reference argument.
                return this.GetNumberOfHalfNodes(node.LeftChild) + this.GetNumberOfHalfNodes(node.RightChild);
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8604 // Possible null reference argument.
            }
        }

        /// <summary>Gets the number of nodes at the specified level</summary>
        /// <param name="node">the node to get the number of nodes at the specified level of</param>
        /// <param name="level">the level to get the number of nodes at</param>
        /// <returns>the number of nodes at the specified level</returns>
        private int GetNumberOfNodesAtLevel(BinaryTreeNode<T> node, int level)
        {
            if (node == null)
            {
                return 0;
            }
            else if (level == 0)
            {
                return 1;
            }
            else
            {
                return this.GetNumberOfNodesAtLevel(node.LeftChild, level - 1) + this.GetNumberOfNodesAtLevel(node.RightChild, level - 1);
            }
        }

        /// <summary>Gets the number of nodes at the specified level</summary>
        /// <param name="node">the node to get the number of nodes at the specified level of</param>
        /// <param name="level">the level to get the number of nodes at</param>
        /// <returns>the number of nodes at the specified level</returns>
        private int GetNumberOfNodesAtLevel(BinaryTreeNode<T> node, int level, int currentLevel)
        {
            if (node == null)
            {
                return 0;
            }
            else if (level == currentLevel)
            {
                return 1;
            }
            else
            {
                return this.GetNumberOfNodesAtLevel(node.LeftChild, level, currentLevel + 1) + this.GetNumberOfNodesAtLevel(node.RightChild, level, currentLevel + 1);
            }
        }
        
    }
}
