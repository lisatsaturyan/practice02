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
        private readonly string _propertyName;

        public ComparatorProperty(string propertyName)
        {
            _propertyName = propertyName;
        }

        public int Compare(T x, T y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException("Cannot compare null objects");

            var property = GetProperty(_propertyName);

            if (property == null)
                throw new ArgumentException($"Property '{_propertyName}' not found in type {typeof(T).Name}");

            var valueX = property.GetValue(x);
            var valueY = property.GetValue(y);

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
