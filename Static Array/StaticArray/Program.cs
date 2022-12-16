using System.Collections;

namespace StaticArray
{
    public class CustomArrayList<T>
    {
        private T[] array;
        private int count;
        /// <summary>
        /// Returns the current list length
        /// </summary>
         public int Count
        {
            get
            {
                return this.count;
            }
        }

        private const int INITIAL_CAPACITY = 1;

        /// <summary>
        /// Allocation of memory for the array
        /// </summary>
        public CustomArrayList(int capacity = INITIAL_CAPACITY)
        {
            this.array = new T[capacity];
            this.count = 0;
        }

        /// <summary>
        /// Addition of an element to the array
        /// </summary>
        /// <param name="item"> The element you want to add</param>
        void Add(T item)
        {
            GrowIfIsFullSize();
            this.array[this.count] = item;
            this.count++;
        }

        ///<summary>
        /// Insertion of the specified element at given position in this list
        /// </summary>
        /// /// <param name="index">
        /// Index, at which the specified element is to be inserted
        /// </param>
        /// <param name="item">Element to be inserted</param>
        /// <exception cref="System.IndexOutOfRangeException">Index is invalid</exception>
        public void Insert(int index, T item)
        {
            if (index > this.count || index < 0)
            {
                throw new IndexOutOfRangeException("Invalid index: " + index);
            }

            GrowIfIsFullSize();
            Array.Copy(this.array, index, this.array, index + 1, this.count - index);
            this.array[index] = item;
            this.count++;
        }

        ///<summary>
        ///Increase of the size of the array (this.array) if it is full
        /// </summary>
        public void GrowIfIsFullSize()
        {
            if(this.count + 1 > this.array.Length)
            {
                T[] extendedArray = new T[this.array.Length + 1];
                Array.Copy(this.array, extendedArray, this.count);
                this.array = extendedArray;
            }
        }

        public void Clear()
        {
            this.array = new T[INITIAL_CAPACITY];
            this.count = 0;
        }

        /// <summary>
        /// Returns the index of the first occurrence of the specified
        /// element in this list (or -1 if it does not exist).
        /// </summary>
        /// <param name="item">The element you are searching</param>
        /// <returns>
        /// The index of a given element or -1 if it is not found
        /// </returns>
        public int IndexOf(T item)
        { }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}