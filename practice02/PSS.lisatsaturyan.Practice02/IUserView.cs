using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice02.PSS.lisatsaturyan.Practice02
{
    public interface IUserView
    {
        string Id { get; set; } // represents the unique identifier of the object
        string Name { get; set; }
        string StepWord { get; set; }
        string Category { get; set; }
        bool IsValid { get; set; }
    }
}
