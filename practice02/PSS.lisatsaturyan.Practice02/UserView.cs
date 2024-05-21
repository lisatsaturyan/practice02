using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice02.PSS.lisatsaturyan.Practice02
{
    public class UserView : IUserView, IEquatable<UserView>, IEqualityComparer<UserView>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string StepWord { get; set; }
        public string Category { get; set; }
        public bool IsValid { get; set; }

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
    }
}
