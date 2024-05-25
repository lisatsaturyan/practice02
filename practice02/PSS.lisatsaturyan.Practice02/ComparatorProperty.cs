using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice02.PSS.lisatsaturyan.Practice02
{
    public class ComparatorProperty<T> : IComparer<T>
    {
        private readonly PropertyDescriptor _property;

        public ComparatorProperty(string propertyName)
        {
            _property = GetProperty(propertyName)
                ?? throw new ArgumentException($"Property '{propertyName}' not found on type {typeof(T).Name}");
        }

        public int Compare(T x, T y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            var valueX = _property.GetValue(x);
            var valueY = _property.GetValue(y);

            if (valueX == null && valueY == null) return 0;
            if (valueX == null) return -1;
            if (valueY == null) return 1;

            if (!Comparable(valueX) || !Comparable(valueY))
                throw new ArgumentException("Values are not comparable");

            return Comparer<object>.Default.Compare(valueX, valueY);
        }

        private PropertyDescriptor GetProperty(string name)
        {
            foreach (PropertyDescriptor propDesc in TypeDescriptor.GetProperties(typeof(T)))
            {
                if (propDesc.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return propDesc;
                }
            }
            return null;
        }

        private bool Comparable(object value)
        {
            return value != null && (value is IComparable || value.GetType().IsValueType);
        }
    }
}
