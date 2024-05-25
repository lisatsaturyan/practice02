using practice02;
using practice02.PSS.lisatsaturyan.Practice02;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace practice02
{
    public class Sequence<T> : IEnumerable<T>, ISequence<T>
    {
        private List<T> _items = new List<T>();
        private IComparer<object>? comparer;

        public void Add(T item)
        {
            _items.Add(item);
        }

        public bool Remove(T item)
        {
            return _items.Remove(item);
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public int Count => _items.Count;

        public void Sort(IComparer<T> comparer)
        {
            _items.Sort(comparer);
        }

        public T this[int i]
        {
            get => _items[i];
            set => _items[i] = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _items.Count - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> RecordoAdelante
        {
            get
            {
                foreach (var item in _items)
                {
                    yield return item;
                }
            }
        }

        public IEnumerable<T> BackTravel
        {
            get
            {
                for (int i = _items.Count - 1; i >= 0; i--)
                {
                    yield return _items[i];
                }
            }
        }

        public IEnumerable<T> UpPath
        {
            get
            {
                var sortedItems = _items.OrderBy(item => item, comparer);
                foreach (var item in sortedItems)
                {
                    yield return item;
                }
            }
        }

        public IEnumerable<T> DescendingPath
        {
            get
            {
                var sortedItems = new List<T>(_items);
                sortedItems.Sort((x, y) => Comparer<T>.Default.Compare(y, x));
                foreach (var item in sortedItems)
                {
                    yield return item;
                }
            }
        }

        

    }
}
