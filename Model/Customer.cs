using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.Model
{
    internal class Customer : HumanBase
    {
        public Customer() : base() { }

        public Customer(uint id, string name, string phone, string address) 
            : base(id, name, phone, address) { }
    }
}
