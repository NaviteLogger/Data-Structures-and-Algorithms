using System;
using System.Collections.Generic;

namespace HashDictionary
{
    public class HashDictionary<TKey, TValue>
    {
        /// <summary>
        /// The number of elements in the dictionary.
        /// </summary>
        private readonly int _size;
        private readonly List<KeyValuePair<TKey, TValue>>[] _items;

        /// <summary>
        /// Initializes a new instance of the <see cref="HashDictionary{TKey, TValue}"/> class.
        /// that is empty, has the default initial capacity, and uses the default equality comparer for the key type.
        /// </summary>
        public HashDictionary(int size)
        {
            _size = size;
            _items = new List<KeyValuePair<TKey, TValue>>[size];
        }

        /// <summary>
        /// Gets the number of key/value pairs contained in the <see cref="HashDictionary{TKey, TValue}"/>.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value associated with the specified key.</returns>
        public TValue this[TKey key]
        {
            get
            {
                var index = GetIndex(key);
                var list = _items[index];
                if (list == null)
                {
                    throw new KeyNotFoundException();
                }

                foreach (var item in list)
                {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    if (item.Key.Equals(key))
                    {
                        return item.Value;
                    }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                }

                throw new KeyNotFoundException();
            }
        }

        /// <summary>
        /// Adds the specified key and value to the dictionary.
        /// </summary>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value of the element to add. The value can be null for reference types.</param>
        public void Add(TKey key, TValue value)
        {
            var index = GetIndex(key);
            var list = _items[index];
            if (list == null)
            {
                list = new List<KeyValuePair<TKey, TValue>>();
                _items[index] = list;
            }

            foreach (var item in list)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (item.Key.Equals(key))
                {
                    throw new ArgumentException("An element with the same key already exists in the dictionary.");
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }

            list.Add(new KeyValuePair<TKey, TValue>(key, value));
            Count++;
        }

        /// <summary>
        /// Removes the value with the specified key from the <see cref="HashDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        /// <returns>true if the element is successfully found and removed; otherwise, false. This method returns false if key is not found in the <see cref="HashDictionary{TKey, TValue}"/>.</returns>
        public bool Remove(TKey key)
        {
            var index = GetIndex(key);
            var list = _items[index];
            if (list == null)
            {
                return false;
            }

            for (int i = 0; i < list.Count; i++)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (list[i].Key.Equals(key))
                {
                    list.RemoveAt(i);
                    Count--;
                    return true;
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }

            return false;
        }

        /// <summary>
        /// Determines whether the <see cref="HashDictionary{TKey, TValue}"/> contains the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the <see cref="HashDictionary{TKey, TValue}"/>.</param>
        /// <returns>true if the <see cref="HashDictionary{TKey, TValue}"/> contains an element with the specified key; otherwise, false.</returns>
        public bool ContainsKey(TKey key)
        {
            var index = GetIndex(key);
            var list = _items[index];
            if (list == null)
            {
                return false;
            }

            foreach (var item in list)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (item.Key.Equals(key))
                {
                    return true;
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }

            return false;
        }

        /// <summary>
        /// Gets the index of the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The index of the specified key.</returns>
        private int GetIndex(TKey key)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return Math.Abs(key.GetHashCode()) % _size;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
        
        
    }
}
