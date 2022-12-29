using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    public class BubbleSortClass
    {
        private int[] array;
        private int arrSize;
        
        public BubbleSortClass(int size)
        {
            array = new int[size];
            arrSize = array.Length;
        }
        
        public void bubbleSort()
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

        public void printFinal()
        {
            Console.WriteLine("Printing The Sorted Array");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
        }

        public void initializeArray()
        {
            Random rn = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rn.Next(0, 40);
            }
        }
        public void printArray()
        {
            Console.WriteLine("Printing Unsorted Array");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
