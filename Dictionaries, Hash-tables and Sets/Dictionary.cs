using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    public class Dictionary<TKey, TValue> 
    {
        private const int InitialCapacity = 16;
        private const float LoadFactor = 0.75f;
        private int capacity;
        private int threshold;
        private LinkedList<KeyValuePair<TKey, TValue>>[] slots;

        public Dictionary()
        {
            this.capacity = InitialCapacity;
            this.threshold = (int)(InitialCapacity * LoadFactor);
            this.slots = new LinkedList<KeyValuePair<TKey, TValue>>[InitialCapacity];
        }

        public Dictionary(int capacity)
        {
            this.capacity = capacity;
            this.threshold = (int)(capacity * LoadFactor);
            this.slots = new LinkedList<KeyValuePair<TKey, TValue>>[capacity];
        }      

        private List<KeyValuePair<TKey, TValue>> _items = new List<KeyValuePair<TKey, TValue>>();

        public void Add(TKey key, TValue value)
        {
            _items.Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        public TValue this[TKey key]
        {
            get
            {
                foreach (var item in _items)
                {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    if (!item.Key.Equals(key))
                    {
                        continue;
                    }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    return item.Value;
                }
                throw new KeyNotFoundException();
            }
            set
            {
                for (int i = 0; i < _items.Count; i++)
                {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    if (_items[i].Key.Equals(key))
                    {
                        _items[i] = new KeyValuePair<TKey, TValue>(key, value);
                        return;
                    }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                }
                _items.Add(new KeyValuePair<TKey, TValue>(key, value));
            }
        }

        public void Remove(TKey key)
        {
            for (int i = 0; i < _items.Count; i++)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (_items[i].Key.Equals(key))
                {
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    _items.RemoveAt(i);
                    return;
                }
            }
            throw new KeyNotFoundException();
        }

        public bool ContainsKey(TKey key)
        {
            foreach (var item in _items)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (item.Key.Equals(key))
                {
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    return true;
                }
            }
            return false;
        }

        public bool ContainsValue(TValue value)
        {
            foreach (var item in _items)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (item.Value.Equals(value))
                {
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            _items.Clear();
        }

        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public List<TKey> Keys
        {
            get
            {
                var keys = new List<TKey>();
                foreach (var item in _items)
                {
                    keys.Add(item.Key);
                }
                return keys;
            }
        }

        public List<TValue> Values
        {
            get
            {
                var values = new List<TValue>();
                foreach (var item in _items)
                {
                    values.Add(item.Value);
                }
                return values;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            foreach (var item in _items)
            {
                result.Append(item.Key);
                result.Append(" -> ");
                result.Append(item.Value);
                result.Append(Environment.NewLine);
            }
            return result.ToString();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public IEnumerable<TKey> GetKeys()
        {
            foreach (var item in _items)
            {
                yield return item.Key;
            }
        }

        public IEnumerable<TValue> GetValues()
        {
            foreach (var item in _items)
            {
                yield return item.Value;
            }
        }

        public IEnumerable<KeyValuePair<TKey, TValue>> GetItems()
        {
            foreach (var item in _items)
            {
                yield return item;
            }
        }
    }
}
