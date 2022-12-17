using System;
using System.Runtime.InteropServices;
using StaticList;
using LinkedList;

public class Program
{
	static void Main()
	{
        StaticList.CustomArrayList<int> tablica = new CustomArrayList<int>(10);

/*		for (int j = 0; j < 15; j++)
		{
			tablica.Add(j+1);
			Console.WriteLine(tablica[j]);
		}*/

        LinkedList.DynamicList<int> lista = new DynamicList<int>();

        Console.WriteLine("It works!");
    }
	
}
