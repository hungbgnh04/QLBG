using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.Model
{
    //Nhà sản xuất
    internal class Manufacturer : Base
    {
        public Manufacturer() : base()
        {
        }

        public Manufacturer(uint id = 0, string name = "") : base(id, name)
        {
        }
    }
}
