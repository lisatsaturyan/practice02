using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice02
{
    public interface ISequence<T>
    {
        void Add(T item);
        bool Remove(T item);
        bool Contains(T item);
        void Clear();
        int Count { get; }
        void Sort(IComparer<T> comparer);
        T this[int i] { get; set; }
    }
}
