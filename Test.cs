using System;
using System.Runtime.InteropServices;
using System.Collections;
using Microsoft.VisualBasic;

using StaticList;
using LinkedList;
using DoublyLinkedList;
using List;
using Tree;
using BinaryTree;
using Dictionary;
using BlockSort;
using BubbleSort;
using ConsoleControl;

public class Program
{
	static void Main()
	{

        StaticList.StaticList<int> tablica = new StaticList<int>(10);

        for (int j = 0; j < 15; j++)
        {
            tablica.Add(j + 1);
            Console.WriteLine(tablica[j]);
        }

        LinkedList.DynamicList<int> lista = new DynamicList<int>();
        DoublyLinkedList.LinkedList<int> listaDynamiczna = new DoublyLinkedList.LinkedList<int>();

        Console.WriteLine("It works!");

        //playing with ArrayList 
        ArrayList ArrayList = new ArrayList();
        _ = ArrayList.Add("Hello");
        _ = ArrayList.Add(5);
        _ = ArrayList.Add(3.14159);
        _ = ArrayList.Add(DateTime.Now);
        for (int i = 0; i < ArrayList.Count; i++)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            object value = ArrayList[i];
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("Index={0}; Value={1}", i, value);
        }

        ArrayList NumerList = new ArrayList();
        _ = NumerList.Add(2);
        _ = NumerList.Add(3.5f);
        _ = NumerList.Add(25u);
        _ = NumerList.Add(" EUR");
        dynamic sum = 0;
        for (int i = 0; i < NumerList.Count; i++)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            dynamic value = NumerList[i];
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            sum += value;
        }
        Console.WriteLine("Sum = " + sum);

        //playing with the lists

        List<int> primes =  InheritedList<int>.GetPrimes(200, 300);
        foreach (var item in primes)
        {
            Console.Write("{0} ", item);
        }

        
        InheritedList<int> firstList = new InheritedList<int>();
        firstList.Add(1);
        firstList.Add(2);
        firstList.Add(3);
        firstList.Add(4);
        firstList.Add(5);
        Console.Write("firstList = ");
        InheritedList<int>.PrintList(firstList);
        
        List<int> secondList = new List<int>();
        secondList.Add(2);
        secondList.Add(4);
        secondList.Add(6);
        Console.Write("secondList = ");
        InheritedList<int>.PrintList(secondList);
        
        List<int> unionList = new List<int>();
        unionList.AddRange(firstList);
        for (int i = unionList.Count - 1; i >= 0; i--)
        {
            if (secondList.Contains(unionList[i]))
            {
                unionList.RemoveAt(i);
            }
        }
        unionList.AddRange(secondList);
        Console.Write("union = ");
        InheritedList<int>.PrintList(unionList);
        
        List<int> intersectList = new List<int>();
        intersectList.AddRange(firstList);
        for (int i = intersectList.Count - 1; i >= 0; i--)
        {
            if (!secondList.Contains(intersectList[i]))
            {
                intersectList.RemoveAt(i);
            }
        }
        Console.Write("intersect = ");
        InheritedList<int>.PrintList(intersectList);


        //converting a list to array and back
        int[] arr = new int[] { 1, 2, 3 };
        List<int> list = new List<int>(arr);
        int[] convertedArray = list.ToArray();
        

        //playing with stacks
        Stack<string> stack = new Stack<string>();
        stack.Push("1. John");
        stack.Push("2. Nicolas");
        stack.Push("3. Mary");
        stack.Push("4. George");
        _ = stack.Pop();
        Console.WriteLine("Stack:" + stack.Peek());
        Console.WriteLine("Top = " + stack.Peek());
        while (stack.Count > 0)
        {
            string personName = stack.Pop();
            Console.WriteLine(personName);
        }

        //brackets check example
        string expression = "1 + (3 + 2 - (2+3)*4 - ((3+1)*(4-2)))";
        Stack<int> BracketsCheckStack = new Stack<int>();
        bool correctBrackets = true;
        for (int BracketsCheckIndex = 0; BracketsCheckIndex < expression.Length; BracketsCheckIndex++)
        {
            char ch = expression[BracketsCheckIndex];
            if (ch == '(')
            {
                BracketsCheckStack.Push(BracketsCheckIndex);
            }
            else if (ch == ')')
            {
                if (BracketsCheckStack.Count == 0)
                {
                    correctBrackets = false;
                    break;
                }
                _ = BracketsCheckStack.Pop();
            }
        }
        if (BracketsCheckStack.Count != 0)
        {
            correctBrackets = false;
        }
        Console.WriteLine("Are the brackets correct? " +correctBrackets);

        //playing with queues
        PriorityQueue<int,string> priorityQueue = new PriorityQueue<int,string>();
        priorityQueue.Enqueue(1, "John");
        priorityQueue.Enqueue(2, "Mary");
        priorityQueue.Enqueue(3, "George");
        priorityQueue.Enqueue(4, "Nicolas");
        priorityQueue.Enqueue(5, "Peter");

        Queue<int> queueReversed = new Queue<int>();
        queueReversed.Enqueue(1);
        queueReversed.Enqueue(2);
        queueReversed.Enqueue(3);
        queueReversed.Enqueue(4);
        queueReversed.Enqueue(5);
        queueReversed.Reverse();
        Console.WriteLine("Queue reversed:");
        foreach (var item in queueReversed)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Queue:" + priorityQueue.Peek());
        Console.WriteLine("Top = " + priorityQueue.Peek());
        while (priorityQueue.Count > 0)
        {           
            string personName= priorityQueue.Dequeue().ToString();
            Console.WriteLine(personName);
        }
        

        Queue<string> queue = new Queue<string>();
        queue.Enqueue("Message One");
        queue.Enqueue("Message Two");
        queue.Enqueue("Message Three");
        queue.Enqueue("Message Four");
        while (queue.Count > 0)
        {
            string msg = queue.Dequeue();
            Console.WriteLine(msg);
        }


        //a sequene using a queue
        int n = 3;
        int p = 16;
        Queue<int> queue2 = new Queue<int>();
        queue2.Enqueue(n);
        int index = 0;
        Console.WriteLine("S =");
        while (queue.Count > 0)
        {
            index++;
            int current = queue2.Dequeue();
            Console.WriteLine(" " + current);
            if (current == p)
            {
                Console.WriteLine();
                Console.WriteLine("Index = " + index);
                return;
            }
            queue2.Enqueue(current + 1);
            queue2.Enqueue(2 * current);
        }
        
       
        
        // Create the tree from the sample
        TreeImplementation.Tree<int> tree =
        new TreeImplementation.Tree<int>(7,
        new TreeImplementation.Tree<int>(19,
        new TreeImplementation.Tree<int>(1),
        new TreeImplementation.Tree<int>(12),
        new TreeImplementation.Tree<int>(31)),
        new TreeImplementation.Tree<int>(21),
        new TreeImplementation.Tree<int>(14,
        new TreeImplementation.Tree<int>(23),
        new TreeImplementation.Tree<int>(6))
        );
        // Traverse and print the tree using Depth-First-Search
        tree.TraverseDFS();



        // Create the binary tree from the sample
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        BinaryTree<int> binaryTree =
        new BinaryTree<int>(14,
        new BinaryTree<int>(19,
        new BinaryTree<int>(23),
        new BinaryTree<int>(6,
        new BinaryTree<int>(10),
        new BinaryTree<int>(21))),
        new BinaryTree<int>(15,
        new BinaryTree<int>(3),
        null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        // Traverse and print the tree in in-order manner
        binaryTree.PrintInOrder();
        Console.WriteLine();
        // Console output:
        // 23 19 10 6 21 14 3 15


        // Playing with the dictionaries
        Dictionary.Dictionary<int, string> dictionary = new Dictionary.Dictionary<int, string>();

        dictionary.Add(1, "Marek");
        dictionary.Add(2, "John");
        dictionary.Add(3, "Jake");

        Console.WriteLine(dictionary.ContainsKey(1));
        Console.WriteLine(dictionary.ContainsValue("Chad"));
        
        foreach(var element in dictionary)
        {
            Console.WriteLine(element);
        }

        dictionary.Remove(1);
        Console.WriteLine(dictionary.ContainsKey(1));
        Console.WriteLine(dictionary.ContainsValue("Marek"));

        dictionary.Clear();
        Console.WriteLine(dictionary.ContainsKey(2));
        Console.WriteLine(dictionary.ContainsValue("John"));

        //BlockSort test
        BlockSort.BlockSortClass arrayToBeSorted = new BlockSort.BlockSortClass(10);
        arrayToBeSorted.initializeArray();
        arrayToBeSorted.printArray();
        arrayToBeSorted.arrBuffer();
        arrayToBeSorted.printFinal();

        Console.WriteLine();

        //BubbleSort test
        BubbleSort.BubbleSortClass arrayToBeSorted2 = new BubbleSort.BubbleSortClass(10);
        arrayToBeSorted2.InitializeArray();
        arrayToBeSorted2.PrintArray(arrayToBeSorted2.array);
        arrayToBeSorted2.BubbleSort();
        arrayToBeSorted2.PrintFinal();
    }

}
