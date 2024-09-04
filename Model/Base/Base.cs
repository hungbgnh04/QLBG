using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.Model
{
    internal class Base
    {
        protected uint id;
        protected string name;

        public uint Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public Base()
        {
            id = 0;
            name = "";
        }

        public Base(uint id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
