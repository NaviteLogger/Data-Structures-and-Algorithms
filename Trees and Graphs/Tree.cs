using System;
using System.Collections.Generic;

namespace Tree
{
    public class TreeImplementation
    {
        /// <summary>Represents a tree node</summary>
        /// <typeparam name="T">the type of the values in nodes
        /// </typeparam>
        public class TreeNode<T>
        {
            // Contains the value of the node
            private T value;
            // Shows whether the current node has a parent or not
            private bool hasParent;
            // Contains the children of the node (zero or more)
            private List<TreeNode<T>> children;
            /// <summary>Constructs a tree node</summary>
            /// <param name="value">the value of the node</param>
            public TreeNode(T value)
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Cannot insert null value!");
                }
                this.value = value;
                this.children = new List<TreeNode<T>>();
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
            /// <summary>The number of node's children</summary>
            public int ChildrenCount
            {
                get
                {
                    return this.children.Count;
                }
            }
            /// <summary>Adds child to the node</summary>
            /// <param name="child">the child to be added</param>
            public void AddChild(TreeNode<T> child)
            {
                if (child == null)
                {
                    throw new ArgumentNullException("Cannot insert null value!");
                }
                if (child.hasParent)
                {
                    throw new ArgumentException("The node already has a parent!");
                }
                child.hasParent = true;
                this.children.Add(child);
            }

            /// <summary>
            /// Gets the child of the node at given index
            /// </summary>
            /// <param name="index">the index of the desired child</param>
            /// <returns>the child on the given position</returns>
            public TreeNode<T> GetChild(int index)
            {
                return this.children[index];
            }
        }

        /// <summary>Represents a tree data structure</summary>
        /// <typeparam name="T">the type of the values in the
        /// tree</typeparam>
        public class Tree<T>
        {
            // The root of the tree
            private TreeNode<T> root;
            /// <summary>Constructs the tree</summary>
            /// <param name="value">the value of the node</param>
            public Tree(T value)
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Cannot insert null value!");
                }
                this.root = new TreeNode<T>(value);
            }
            /// <summary>Constructs the tree</summary>
            /// <param name="value">the value of the root node</param>
            /// <param name="children">the children of the root
            /// node</param>
            public Tree(T value, params Tree<T>[] children) : this(value)
            {
                foreach (Tree<T> child in children)
                {
                    this.root.AddChild(child.root);
                }
            }
            /// <summary>
            /// The root node or null if the tree is empty
            /// </summary>
            public TreeNode<T> Root
            {
                get
                {
                    return this.root;
                }
            }
            /// <summary>Traverses and prints tree in /// Depth-First Search (DFS) manner</summary>
            /// <param name="root">the root of the tree to be
            /// traversed</param>
            /// <param name="spaces">the spaces used for
            /// representation of the parent-child relation</param>
            private void PrintDFS(TreeNode<T> root, string spaces)
            {
                if (this.root == null)
                {
                    return;
                }
                Console.WriteLine(spaces + root.Value);
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                TreeNode<T> child = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                for (int i = 0; i < root.ChildrenCount; i++)
                {
                    child = root.GetChild(i);
                    PrintDFS(child, spaces + " ");
                }
            }
            /// <summary>Traverses and prints the tree in
            /// Depth-First Search (DFS) manner</summary>
            public void TraverseDFS()
            {
                this.PrintDFS(this.root, string.Empty);
            }
        }       
    }
}
