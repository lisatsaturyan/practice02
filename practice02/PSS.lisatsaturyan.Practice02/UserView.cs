using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice02.PSS.lisatsaturyan.Practice02
{
    public class UserView : IUserView, IEquatable<UserView>, IEqualityComparer<UserView>, IComparable<UserView>, ISequence<UserView>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string StepWord { get; set; }
        public string Category { get; set; }
        public bool IsValid { get; set; }

        public int Count => throw new NotImplementedException();

        public UserView this[int i] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public UserView(string id, string name, string stepWord, string category, bool isValid)
        {
            Id = id;
            Name = name;
            StepWord = stepWord;
            Category = category;
            IsValid = isValid;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as UserView);
        }

        public bool Equals(UserView other)
        {
            return other != null && Id == other.Id;
        }

        public bool Equals(UserView x, UserView y)
        {
            if (x == null || y == null)
                return false;

            return x.Id == y.Id;
        }

        public int GetHashCode(UserView obj)
        {
            return obj.Id.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public int CompareTo(UserView other)
        {
            if (ReferenceEquals(other, null))
                return 1; // Non-null object is greater than null

            if (ReferenceEquals(this, null))
                return -1; // Null is always less than non-null

            return string.Compare(Id, other.Id, StringComparison.Ordinal);
        }

        public void Add(UserView item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(UserView item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(UserView item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Sort(IComparer<UserView> comparer)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(UserView left, UserView right)
        {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null);

            return left.Equals(right);
        }

        public static bool operator !=(UserView left, UserView right)
        {
            return !(left == right);
        }

        public static bool operator <(UserView left, UserView right)
        {
            if (ReferenceEquals(left, null))
                return !ReferenceEquals(right, null); // Null is less than any non-null

            return left.CompareTo(right) < 0;
        }

        public static bool operator >(UserView left, UserView right)
        {
            if (ReferenceEquals(left, null))
                return false; // Null is not greater than any object

            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(UserView left, UserView right)
        {
            if (ReferenceEquals(left, null))
                return true; // Null is always less than or equal to any object

            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(UserView left, UserView right)
        {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null); // Null is less than any non-null

            return left.CompareTo(right) >= 0;
        }
    }
}



