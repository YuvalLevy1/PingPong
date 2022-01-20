using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public class ConcurrentHashSet<T> : IEnumerable
    {
        public int Count
        {
            get { return _data.Count; }
        }

        private readonly ConcurrentDictionary<T, object> _data;

        public ConcurrentHashSet(IEnumerable<T> elements = null)
        {
            _data = new ConcurrentDictionary<T, object>();
            if (elements != null)
            {
                UnionWith(elements);
            }
        }

        public void UnionWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other is null");
            }

            foreach (var otherElement in other)
            {
                TryAdd(otherElement);
            }
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            return other.Any(otherElement => _data.ContainsKey(otherElement));
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            int otherCount = 0;
            int thisCount = Count;
            foreach (var otherElement in other)
            {
                otherCount++;
                if (!_data.ContainsKey(otherElement))
                {
                    return false;
                }
            }
            return otherCount == thisCount;
        }

        public bool TryAdd(T item)
        {
            return _data.TryAdd(item, null);
        }

        public void Clear()
        {
            _data.Clear();
        }

        public bool Contains(T item)
        {
            return _data.ContainsKey(item);
        }

        public bool Remove(T item)
        {
            object ignore;
            return _data.TryRemove(item, out ignore);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _data.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
