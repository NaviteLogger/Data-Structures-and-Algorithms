using System;
using System.Collections.Generic;
using ConsoleControl;

namespace BubbleSort
{
    public class BubbleSortClass : IConsoleControlInterface
    {
        public int[] array;
        public int arrSize;
        
        public BubbleSortClass(int size)
        {
            array = new int[size];
            arrSize = array.Length;
        }
        
        public void BubbleSort()
        {
            int temp;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        public void PrintFinal()
        {
            Console.WriteLine("Printing The Sorted Array");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
        }

        public void InitializeArray()
        {
            Random rn = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rn.Next(0, 40);
            }
        }

        public void PrintArray(int[] array)
        {
            Console.WriteLine("Printing The Array");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
        }
    }
}