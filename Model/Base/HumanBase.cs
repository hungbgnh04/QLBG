using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.Model
{
    internal class HumanBase : Base
    {
        private string address;
        private string phoneNumber;


        public string Address { get => address; set => address=value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber=value; }

        public HumanBase() : base()
        {
            Address="";
            PhoneNumber="";
        }

        public HumanBase(uint id, string name, string address, string phoneNumber) : base(id, name)
        {
            Address=address;
            PhoneNumber=phoneNumber;
        }
    }
}
