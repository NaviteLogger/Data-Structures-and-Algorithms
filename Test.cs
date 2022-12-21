using System;
using System.Runtime.InteropServices;
using StaticList;
using LinkedList;
using DoublyLinkedList;
using List;
using static DSA.Trees_and_Graphs.TreeImplementation;
using System.Collections;

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
        ArrayList.Add("Hello");
        ArrayList.Add(5);
        ArrayList.Add(3.14159);
        ArrayList.Add(DateTime.Now);
        for (int i = 0; i < ArrayList.Count; i++)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            object value = ArrayList[i];
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("Index={0}; Value={1}", i, value);
        }

        ArrayList NumerList = new ArrayList();
        NumerList.Add(2);
        NumerList.Add(3.5f);
        NumerList.Add(25u);
        NumerList.Add(" EUR");
        dynamic sum = 0;
        for (int i = 0; i < NumerList.Count; i++)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            dynamic value = NumerList[i];
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            sum = sum + value;
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
                BracketsCheckStack.Pop();
            }
        }
        if (BracketsCheckStack.Count != 0)
        {
            correctBrackets = false;
        }
        Console.WriteLine("Are the brackets correct? " +correctBrackets);

        //playing with queues
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
        Tree<int> tree =
        new Tree<int>(7,
        new Tree<int>(19,
        new Tree<int>(1),
        new Tree<int>(12),
        new Tree<int>(31)),
        new Tree<int>(21),
        new Tree<int>(14,
        new Tree<int>(23),
        new Tree<int>(6))
        );
        // Traverse and print the tree using Depth-First-Search
        tree.TraverseDFS();
    }
	
}
