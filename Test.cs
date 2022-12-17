using System;
using System.Runtime.InteropServices;
using StaticList;

public class Program
{
	static void Main()
	{
        StaticList.CustomArrayList<int> tablica = new CustomArrayList<int>(10);
		
        Console.WriteLine("It works!");

		for (int j = 0; j < 15; j++)
		{
			tablica.Add(j+1);
			Console.WriteLine(tablica[j]);
		}
	}
	
}
