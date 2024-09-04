using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.Model
{
    //Đặc điểm
    internal class Feature : Base
    {
        public Feature() : base()
        {
        }

        public Feature(uint id = 0, string name = "") : base(id, name)
        {
        }
    }
}
