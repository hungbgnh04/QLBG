using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.Model
{
    internal class Provider : HumanBase
    {
        public Provider() : base()
        {
        }

        public Provider(uint id, string name, string address, string phone) 
            : base(id, name, address, phone)
        {
        }
    }
}
