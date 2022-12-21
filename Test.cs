using System;
using System.Runtime.InteropServices;
using StaticList;
using LinkedList;
using DoublyLinkedList;

public class Program
{
	static void Main()
	{
        StaticList.StaticList<int> tablica = new StaticList<int>(10);

/*		for (int j = 0; j < 15; j++)
		{
			tablica.Add(j+1);
			Console.WriteLine(tablica[j]);
		}*/

        LinkedList.DynamicList<int> lista = new DynamicList<int>();
        DoublyLinkedList.LinkedList<int> listaDynamiczna = new DoublyLinkedList.LinkedList<int>();

        Console.WriteLine("It works!");
    }
	
}
