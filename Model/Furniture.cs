using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.Model
{
    //Loại
    internal class Furniture : Base
    {
        public Furniture() : base()
        {
        }

        public Furniture(uint id = 0, string name = "") : base(id, name)
        {
        }
    }
}
