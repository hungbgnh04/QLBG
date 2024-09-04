using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.Model
{
    internal class JobTitle : Base
    {
        private double salary;

        public double Salary { get => salary; set => salary=value; }

        public JobTitle() : base()
        {
            Salary = 0;
        }

        public JobTitle(uint id, string name, double salary) : base(id, name)
        {
            Salary = salary;
        }
    }
}
