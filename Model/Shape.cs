using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.Model
{
    internal class Shape : Base
    {
        public Shape() : base()
        {
        }

        public Shape(uint id = 0, string name = "") : base(id, name)
        {
        }
    }
}
